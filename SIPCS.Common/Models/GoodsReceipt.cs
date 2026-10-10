namespace SIPCS.Common.Models
{
    // ترويسة سند الاستلام
    public class GoodsReceipt
    {
        public int ReceiptID { get; set; }
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        public int WarehouseID { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public int CreatedByUserID { get; set; }

        // للعرض فقط
        public string? WarehouseName { get; set; }
        public string? CreatedByUserName { get; set; }
        public List<GoodsReceiptDetail> Details { get; set; } = new();
    }

    // تفاصيل سند الاستلام
    public class GoodsReceiptDetail
    {
        public int ReceiptDetailID { get; set; }
        public int ReceiptID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }

        // للعرض فقط
        public string? ProductName { get; set; }
        public decimal TotalLine => Quantity * UnitCost;
    }
}
