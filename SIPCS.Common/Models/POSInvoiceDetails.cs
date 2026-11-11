
namespace SIPCS.Common.Models
{
    // تفاصيل فاتورة نقاط البيع
    public class POSInvoiceDetails
    {
        // المعرف الفريد لسطر الفاتورة
        public int InvoiceDetailID { get; set; }

        // رقم الفاتورة الرئيسية
        public int InvoiceID { get; set; }

        // المنتج المباع
        public int ProductID { get; set; }

        // اسم المنتج وقت البيع
        public string ProductName { get; set; } = string.Empty;

        // رمز المنتج أو الباركود
        public string? SKU { get; set; }

        // الكمية المباعة
        public decimal Quantity { get; set; }

        // سعر الوحدة وقت البيع
        public decimal UnitPrice { get; set; }

        // إجمالي السطر قبل الخصم والضريبة
        public decimal SubTotal { get; set; }

        // الخصم الممنوح على الصنف
        public decimal DiscountAmount { get; set; }

        // نسبة الضريبة
        public decimal TaxRate { get; set; } = 15;

        // قيمة الضريبة
        public decimal TaxAmount { get; set; }

        // إجمالي السطر بعد الخصم والضريبة
        // نفس المعادلة الموجودة في قاعدة البيانات
        public decimal TotalLine => SubTotal - DiscountAmount + TaxAmount;

        // تكلفة الوحدة وقت البيع
        public decimal UnitCost { get; set; }

        // خصائص للعرض فقط
        public string? ProductDescription { get; set; }
    }
}

