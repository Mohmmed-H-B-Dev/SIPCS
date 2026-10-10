using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;
using SIPCS.BLL.Services.CommissionModule;

namespace SIPCS.BLL.Services.POSModule
{
    /// <summary>
    /// منطق عمل نقطة البيع (POS)
    /// </summary>
    public class SalesService
    {
        private readonly CommissionService _commissionService = new();

        /// <summary>
        /// إتمام عملية البيع وخصم الكمية من المخزون واحتساب العمولة
        /// </summary>
        public bool ProcessSale(SalesInvoice invoice)
        {
            // تحقق من توفر الكميات أولاً
            ValidateStock(invoice);

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var transaction = conn.BeginTransaction();

            try
            {
                // 1. احسب الإجماليات
                invoice.SubTotal    = invoice.Details.Sum(d => d.TotalLine);
                invoice.TaxAmount   = Math.Round(invoice.SubTotal * 0.15m, 2); // 15% ضريبة
                invoice.GrandTotal  = invoice.SubTotal + invoice.TaxAmount - invoice.DiscountAmount;

                // 2. أدخل الفاتورة
                var invCmd = new SqlCommand(@"
                    INSERT INTO SalesInvoices
                        (InvoiceDate, CustomerID, UserID, WarehouseID,
                         SubTotal, TaxAmount, DiscountAmount, GrandTotal, PaymentType)
                    VALUES (@Date,@CustID,@UserID,@WH,@Sub,@Tax,@Disc,@Grand,@Pay);
                    SELECT SCOPE_IDENTITY();", conn, transaction);

                invCmd.Parameters.AddWithValue("@Date",   invoice.InvoiceDate);
                invCmd.Parameters.AddWithValue("@CustID", invoice.CustomerID);
                invCmd.Parameters.AddWithValue("@UserID", invoice.UserID);
                invCmd.Parameters.AddWithValue("@WH",     invoice.WarehouseID);
                invCmd.Parameters.AddWithValue("@Sub",    invoice.SubTotal);
                invCmd.Parameters.AddWithValue("@Tax",    invoice.TaxAmount);
                invCmd.Parameters.AddWithValue("@Disc",   invoice.DiscountAmount);
                invCmd.Parameters.AddWithValue("@Grand",  invoice.GrandTotal);
                invCmd.Parameters.AddWithValue("@Pay",    (int)invoice.PaymentType);

                int invoiceId = Convert.ToInt32(invCmd.ExecuteScalar());

                // 3. أدخل التفاصيل واخصم من المخزون
                foreach (var detail in invoice.Details)
                {
                    var detCmd = new SqlCommand(@"
                        INSERT INTO SalesInvoiceDetails (InvoiceID, ProductID, Quantity, UnitPrice, TotalLine)
                        VALUES (@InvID, @ProdID, @Qty, @Price, @Total)", conn, transaction);
                    detCmd.Parameters.AddWithValue("@InvID",  invoiceId);
                    detCmd.Parameters.AddWithValue("@ProdID", detail.ProductID);
                    detCmd.Parameters.AddWithValue("@Qty",    detail.Quantity);
                    detCmd.Parameters.AddWithValue("@Price",  detail.UnitPrice);
                    detCmd.Parameters.AddWithValue("@Total",  detail.TotalLine);
                    detCmd.ExecuteNonQuery();

                    // اخصم من المخزون
                    var stockCmd = new SqlCommand(
                        "UPDATE Stock SET Quantity = Quantity - @Qty WHERE ProductID=@ProdID AND WarehouseID=@WH",
                        conn, transaction);
                    stockCmd.Parameters.AddWithValue("@Qty",    detail.Quantity);
                    stockCmd.Parameters.AddWithValue("@ProdID", detail.ProductID);
                    stockCmd.Parameters.AddWithValue("@WH",     invoice.WarehouseID);
                    stockCmd.ExecuteNonQuery();
                }

                // 4. احسب عمولة الموظف
                _commissionService.CalculateCommission(invoiceId, invoice.UserID, invoice.GrandTotal, conn, transaction);

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

        private void ValidateStock(SalesInvoice invoice)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            foreach (var detail in invoice.Details)
            {
                var cmd = new SqlCommand(
                    "SELECT Quantity FROM Stock WHERE ProductID=@PID AND WarehouseID=@WH",
                    conn);
                cmd.Parameters.AddWithValue("@PID", detail.ProductID);
                cmd.Parameters.AddWithValue("@WH",  invoice.WarehouseID);
                var qty = cmd.ExecuteScalar();
                int available = qty == null ? 0 : Convert.ToInt32(qty);
                if (available < detail.Quantity)
                    throw new Exception($"الكمية غير كافية للمنتج: {detail.ProductName}. المتوفر: {available}");
            }
        }
    }
}
