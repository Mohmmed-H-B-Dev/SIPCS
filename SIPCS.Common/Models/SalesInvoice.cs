using SIPCS.Common.Enums;
using System.Data;

namespace SIPCS.Common.Models
{
    // ترويسة فاتورة المبيعات
    public class SalesInvoice
    {

        public static string GetNamePayment(PaymentType t)
        {
           return t switch
            {
                PaymentType.Cash => "Cash",
                PaymentType.Card => "Card",
                PaymentType.Credit => "Credit",
                _ => "Unknown",
            };

        }
        public static PaymentType  GetTypeOfPayment(string str)
        {
            return str switch
            {
                "Cash" => PaymentType.Cash,
                "Card" => PaymentType.Card,
                "Credit" => PaymentType.Credit,
                _ => PaymentType.Unknown,
            };
              
           

        }
        public int InvoiceID { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public int WarehouseID { get; set; }

        public string? WarehouseName { get; set; } // Show only for display purposes
        public decimal SubTotal { get; set; }       // الإجمالي قبل الضريبة
        public decimal TaxAmount { get; set; }      // قيمة الضريبة
        public decimal DiscountAmount { get; set; } // قيمة الخصم
        public decimal GrandTotal { get; set; }     // الإجمالي النهائي
        public PaymentType PaymentType { get; set; }

        //Show only properties for display purposes
        public string? CustomerName { get; set; }
        public string? UserName { get; set; }
        //Details of the sales invoice for the items sold
        public List<SalesInvoiceDetail> Details { get; set; } = new();
    }

    // تفاصيل فاتورة المبيعات
    public class SalesInvoiceDetail
    {
        public int InvoiceDetailID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalLine => Quantity * UnitPrice;
        public decimal TotalCharge { get; set; }
        // للعرض فقط
        public string? ProductName { get; set; }
    }
}
