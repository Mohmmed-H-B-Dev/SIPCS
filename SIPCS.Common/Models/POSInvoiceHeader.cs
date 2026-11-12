
using SIPCS.Common.Enums;

namespace SIPCS.Common.Models
{
    // رأس فاتورة نقاط البيع
    public class POSInvoiceHeader
    {
        // تحويل حالة الفاتورة من Enum إلى نص لحفظها في قاعدة البيانات
        public static string GetNameOfStatus(POSInvoiceStatus status)
        {
            return status switch
            {
                POSInvoiceStatus.Draft => "Draft",
                POSInvoiceStatus.Completed => "Completed",
                POSInvoiceStatus.Cancelled => "Cancelled",
                POSInvoiceStatus.Returned => "Returned",
                _ => "Unknown"
            };
        }

        // تحويل حالة الفاتورة من نص إلى Enum
        public static POSInvoiceStatus GetTypeOfStatus(string str)
        {
            return str switch
            {
                "Draft" => POSInvoiceStatus.Draft,
                "Completed" => POSInvoiceStatus.Completed,
                "Cancelled" => POSInvoiceStatus.Cancelled,
                "Returned" => POSInvoiceStatus.Returned,
                _ => POSInvoiceStatus.Unknown
            };
        }

        // المعرف الداخلي للفاتورة
        public int InvoiceID { get; set; }

        // رقم الفاتورة الظاهر للمستخدم
        public string InvoiceNumber { get; set; } = string.Empty;

        // تاريخ إصدار الفاتورة
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        // العميل (قد يكون غير مسجل)
        public int? CustomerID { get; set; }

        // الموظف أو الكاشير
        public int UserID { get; set; }

        // المخزن
        public int WarehouseID { get; set; }

        // الإجماليات المالية
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal GrandTotal { get; set; }

        // حالة الفاتورة
        public POSInvoiceStatus InvoiceStatus { get; set; } = POSInvoiceStatus.Draft;

        // ملاحظات إضافية
        public string? Notes { get; set; }
        
		 
		 
	 
	 
		 
        // تاريخ إنشاء السجل
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // خصائص للعرض فقط
        public string? CustomerName { get; set; }
        public string? UserName { get; set; }
        public string? WarehouseName { get; set; }

        // تفاصيل المنتجات الموجودة داخل الفاتورة
        public List<POSInvoiceDetails> Details { get; set; } = new();

        // عمليات الدفع المرتبطة بالفاتورة
        public List<POSPaymentTransaction> Payments { get; set; } = new();

    }
}
