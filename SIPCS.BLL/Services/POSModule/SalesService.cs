using Microsoft.Data.SqlClient;
using SIPCS.BLL.Services.CommissionModule;
using SIPCS.Common.Exceptions;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;
using SIPCS.DAL.Repositories;
using System.Data;
using System.Net.NetworkInformation;

namespace SIPCS.BLL.Services.POSModule
{
    /// <summary>
    /// منطق عمل نقطة البيع (POS)
    /// </summary>
    public class SalesService
    {
        enum enInvoiceStatus
        {
            New = 1,
            ToReturned = 2

        }

        public int WarehouseID { set; get; }
        public int CustomerID { set; get; }
        public string Notes { set; get; } = string.Empty;

        enInvoiceStatus InvoiceStatus { set; get; } = enInvoiceStatus.New;
        public SalesService(int warehouseID, int customerID, string notes)
        {
            WarehouseID = warehouseID;
            CustomerID = customerID;
            Notes = notes;
            InvoiceStatus=enInvoiceStatus.ToReturned;
        }
        public SalesService()
        {
            WarehouseID = -1;
            CustomerID = -1;
            Notes = string.Empty;
        }
        public  List<Common.Models.TVP.PaymentMethodTableType> paymentMethods = new List<Common.Models.TVP.PaymentMethodTableType>();
        public  List<Common.Models.TVP.InvoiceDetailTableType> invoiceDetails = new List<Common.Models.TVP.InvoiceDetailTableType>();
        POSInvoiceHeader Pre_invoice = new POSInvoiceHeader();
        //   private readonly CommissionService _commissionService = new();

        /// <summary>
        /// إتمام عملية البيع وخصم الكمية من المخزون واحتساب العمولة
        /// </summary>
        public bool ProcessSale(SalesInvoice invoice)
        {
            // تحقق من توفر الكميات أولاً
            // _commissionService.ValidateStock(invoice);

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var transaction = conn.BeginTransaction();

            try
            {
                // 1. احسب الإجماليات
                //   invoice.SubTotal    = invoice.Details.Sum(d => d.TotalLine);
                //  invoice.TaxAmount   = Math.Round(invoice.SubTotal * 0.15m, 2); // 15% ضريبة
                //    invoice.GrandTotal  = invoice.SubTotal + invoice.TaxAmount - invoice.DiscountAmount;

                // 2. أدخل الفاتورة
                var invCmd = new SqlCommand(@"
                    INSERT INTO SalesInvoices
                        (InvoiceDate, CustomerID, UserID, WarehouseID,
                         SubTotal, TaxAmount, DiscountAmount, GrandTotal, PaymentType)
                    VALUES (@Date,@CustID,@UserID,@WH,@Sub,@Tax,@Disc,@Grand,@Pay);
                    SELECT SCOPE_IDENTITY();", conn, transaction);

                invCmd.Parameters.AddWithValue("@Date", invoice.InvoiceDate);
                invCmd.Parameters.AddWithValue("@CustID", invoice.CustomerID);
                invCmd.Parameters.AddWithValue("@UserID", invoice.UserID);
                invCmd.Parameters.AddWithValue("@WH", invoice.WarehouseID);
                invCmd.Parameters.AddWithValue("@Sub", invoice.SubTotal);
                invCmd.Parameters.AddWithValue("@Tax", invoice.TaxAmount);
                invCmd.Parameters.AddWithValue("@Disc", invoice.DiscountAmount);
                invCmd.Parameters.AddWithValue("@Grand", invoice.GrandTotal);
                invCmd.Parameters.AddWithValue("@Pay", (int)invoice.PaymentType);

                int invoiceId = Convert.ToInt32(invCmd.ExecuteScalar());

                // 3. أدخل التفاصيل واخصم من المخزون
                foreach (var detail in invoice.Details)
                {
                    var detCmd = new SqlCommand(@"
                        INSERT INTO SalesInvoiceDetails (InvoiceID, ProductID, Quantity, UnitPrice, TotalLine)
                        VALUES (@InvID, @ProdID, @Qty, @Price, @Total)", conn, transaction);
                    detCmd.Parameters.AddWithValue("@InvID", invoiceId);
                    detCmd.Parameters.AddWithValue("@ProdID", detail.ProductID);
                    detCmd.Parameters.AddWithValue("@Qty", detail.Quantity);
                    detCmd.Parameters.AddWithValue("@Price", detail.UnitPrice);
                    detCmd.Parameters.AddWithValue("@Total", detail.TotalLine);
                    detCmd.ExecuteNonQuery();

                    // اخصم من المخزون
                    var stockCmd = new SqlCommand(
                        "UPDATE Stock SET Quantity = Quantity - @Qty WHERE ProductID=@ProdID AND WarehouseID=@WH",
                        conn, transaction);
                    stockCmd.Parameters.AddWithValue("@Qty", detail.Quantity);
                    stockCmd.Parameters.AddWithValue("@ProdID", detail.ProductID);
                    stockCmd.Parameters.AddWithValue("@WH", invoice.WarehouseID);
                    stockCmd.ExecuteNonQuery();
                }

                // 4. احسب عمولة الموظف
                CommissionService.CalculateCommission(invoiceId, invoice.UserID, invoice.GrandTotal, conn, transaction);

                transaction.Commit();
                invoice.InvoiceID = invoiceId;
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private bool _AddInvoiceDetails(int WarehouseID, int CustomerID, string Notes)
        {
            POSInvoiceHeader detail = new POSInvoiceHeader();
            detail.CustomerID=CustomerID;
            detail.Notes=Notes;
            detail.WarehouseID = WarehouseID;
            detail.InvoiceDate=DateTime.Now;
            detail.InvoiceStatus = SIPCS.Common.Enums.POSInvoiceStatus.Completed;
            detail.UserID=SIPCS.BLL.Services.UserModule.UserService.CurrentUser.UserID;

            try
            {
                Pre_invoice=POSInvoiceHeaderRepository.Insert(invoiceDetails, paymentMethods, detail);

                if (Pre_invoice != null && Pre_invoice.InvoiceID > 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw SIPCS.Common.Exceptions.ExceptionHelper.Convert(ex);
            }

            return false;
        }

        public bool SaveInvoiceDetails()
        {
            switch (InvoiceStatus)
            {
                case enInvoiceStatus.New:
                    if (_AddInvoiceDetails(WarehouseID, CustomerID, Notes))
                    {
                        this.CustomerID=-1;
                        this.Notes=string.Empty;
                        return true;
                    }
                    break;
                case enInvoiceStatus.ToReturned:
                    //  return POSInvoiceHeaderRepository.ReturnInvoice(Pre_invoice.InvoiceID, WarehouseID, CustomerID, Notes);

                    break;
                default:
                    throw new InvalidOperationException("Invalid invoice status.");
            }

            return false;

        }
    }
}
