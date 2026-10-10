namespace SIPCS.Common.Models
{
    public class Stock
    {
        public int StockID { get; set; }
        public int WarehouseID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        // للعرض فقط
        public string? ProductName { get; set; }
        public string? WarehouseName { get; set; }
        public string? SKU { get; set; }
        public int ReorderLevel { get; set; }

        // هل الكمية أقل من حد إعادة الطلب؟
        public bool IsLowStock => Quantity <= ReorderLevel;
    }
}
