using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;
using SIPCS.DAL.Repositories;

namespace SIPCS.BLL.Services.InventoryModule
{
    /// <summary>
    /// منطق عمل المخزون والجرد
    /// </summary>
    public class StockService
    {
        private readonly ProductRepository _productRepo = new();

        /// <summary>
        /// جلب جميع أصناف المخزون مع الكميات
        /// </summary>
        public List<Stock> GetAllStock(int? warehouseId = null)
        {
            var list = new List<Stock>();
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string sql = @"
                SELECT s.StockID, s.WarehouseID, s.ProductID, s.Quantity,
                       p.ProductName, p.SKU, p.ReorderLevel, w.WarehouseName
                FROM Stock s
                INNER JOIN Products p ON s.ProductID = p.ProductID
                INNER JOIN Warehouses w ON s.WarehouseID = w.WarehouseID";

            if (warehouseId.HasValue)
                sql += " WHERE s.WarehouseID = @WarehouseID";

            sql += " ORDER BY p.ProductName";

            var cmd = new SqlCommand(sql, conn);
            if (warehouseId.HasValue)
                cmd.Parameters.AddWithValue("@WarehouseID", warehouseId.Value);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Stock
                {
                    StockID       = reader.GetInt32(0),
                    WarehouseID   = reader.GetInt32(1),
                    ProductID     = reader.GetInt32(2),
                    Quantity      = reader.GetInt32(3),
                    ProductName   = reader.GetString(4),
                    SKU           = reader.GetString(5),
                    ReorderLevel  = reader.GetInt32(6),
                    WarehouseName = reader.GetString(7)
                });
            }
            return list;
        }

        /// <summary>
        /// الأصناف التي وصلت لحد إعادة الطلب (تنبيه نقص المخزون)
        /// </summary>
        public List<Stock> GetLowStockItems()
        {
            return GetAllStock().Where(s => s.IsLowStock).ToList();
        }

        /// <summary>
        /// تسجيل سند استلام بضاعة جديدة وتحديث المخزون
        /// </summary>
        public bool ReceiveGoods(GoodsReceipt receipt)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var transaction = conn.BeginTransaction();

            try
            {
                // 1. أدخل ترويسة سند الاستلام
                var headerCmd = new SqlCommand(@"
                    INSERT INTO GoodsReceipts (ReceiptDate, WarehouseID, SupplierName, CreatedByUserID)
                    VALUES (@Date, @WarehouseID, @Supplier, @UserID);
                    SELECT SCOPE_IDENTITY();", conn, transaction);

                headerCmd.Parameters.AddWithValue("@Date",        receipt.ReceiptDate);
                headerCmd.Parameters.AddWithValue("@WarehouseID", receipt.WarehouseID);
                headerCmd.Parameters.AddWithValue("@Supplier",    receipt.SupplierName);
                headerCmd.Parameters.AddWithValue("@UserID",      receipt.CreatedByUserID);

                int newReceiptId = Convert.ToInt32(headerCmd.ExecuteScalar());

                // 2. لكل صنف في السند
                foreach (var detail in receipt.Details)
                {
                    // أدخل تفاصيل السند
                    var detailCmd = new SqlCommand(@"
                        INSERT INTO GoodsReceiptDetails (ReceiptID, ProductID, Quantity, UnitCost)
                        VALUES (@ReceiptID, @ProductID, @Qty, @Cost)", conn, transaction);
                    detailCmd.Parameters.AddWithValue("@ReceiptID",  newReceiptId);
                    detailCmd.Parameters.AddWithValue("@ProductID",  detail.ProductID);
                    detailCmd.Parameters.AddWithValue("@Qty",        detail.Quantity);
                    detailCmd.Parameters.AddWithValue("@Cost",       detail.UnitCost);
                    detailCmd.ExecuteNonQuery();

                    // حدّث كمية المخزون (إضافة للكمية الموجودة)
                    var stockCmd = new SqlCommand(@"
                        IF EXISTS (SELECT 1 FROM Stock WHERE ProductID=@ProductID AND WarehouseID=@WarehouseID)
                            UPDATE Stock SET Quantity = Quantity + @Qty
                            WHERE ProductID=@ProductID AND WarehouseID=@WarehouseID
                        ELSE
                            INSERT INTO Stock (WarehouseID, ProductID, Quantity)
                            VALUES (@WarehouseID, @ProductID, @Qty)", conn, transaction);
                    stockCmd.Parameters.AddWithValue("@ProductID",  detail.ProductID);
                    stockCmd.Parameters.AddWithValue("@WarehouseID", receipt.WarehouseID);
                    stockCmd.Parameters.AddWithValue("@Qty",        detail.Quantity);
                    stockCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
