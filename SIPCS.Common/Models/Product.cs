namespace SIPCS.Common.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string SKU { get; set; } = string.Empty;        // الباركود
        public string ProductName { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public decimal CostPrice { get; set; }   // سعر التكلفة
        public decimal UnitPrice { get; set; }   // سعر البيع
        public int ReorderLevel { get; set; }    // حد إعادة الطلب

        // للعرض فقط
        public string? CategoryName { get; set; }
        public int CurrentStock { get; set; }
    }
}
