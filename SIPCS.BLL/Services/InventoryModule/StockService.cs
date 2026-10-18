using Microsoft.Data.SqlClient;
using SIPCS.Common.Exceptions;
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
        private readonly StockRepository _StockRepo = new();

        /// <summary>
        /// Get all stock items || optionally filtered by warehouse ID.
        /// </summary>
        public List<Stock> GetAllStock(int? warehouseId = null)
        {
            var list = new List<Stock>();
         

             try {
                if (warehouseId.HasValue)
                    list = _StockRepo.GetAll(warehouseId.Value);
                else
                    list = _StockRepo.GetAll();
            }
            catch (Exception ex) {
                // Handle exception (e.g., log it)
                throw  ExceptionHelper.Convert(ex);
            }


        
            return list;
        }

        /// <summary>
        /// Get all stock items that are below their reorder level.
        /// </summary>
        public List<Stock> GetLowStockItems()
        {
            return GetAllStock().Where(s => s.IsLowStock).ToList();
        }

        /// <summary>
        /// Record goods receive and update inventory.......
        /// Added a feature for transfers between branches, allowing for the documentation of transfers from one branch to another.
        /// </summary>
        /// 
        public bool ReceiveGoods(GoodsReceipt receipt, int WarehouseID, int UserID, string SupplierName)
        {
            try
            {
               // هنا لازم نضيف من المستودع الفلاني الى المستودع الفلاني
                return GoodsReceiptsRepository.ReceiveGoods(receipt, WarehouseID, UserID, SupplierName);
            }
            catch (Exception ex)
            {
                throw ExceptionHelper.Convert(ex);
            }

        }


    }

        //  public bool ReceiveGoods(GoodsReceipt receipt)
        //{
        //    using var conn = DatabaseHelper.GetConnection();
        //    conn.Open();
        //    using var transaction = conn.BeginTransaction();

        //    مراحعه الاحراء في قاعدة البيانات عن طريق تنفيذ استعلامات SQL مباشرة لتسجيل سند الاستلام وتحديث المخزون.
        //    ReceiveGoods
        //        عشان يتم تحديث البيانات لكل فرع ولكل مخزن لوحدة

        //    try
        //    {
        //        // 1. Insert Goods Receipt header
        //        var headerCmd = new SqlCommand(@"
        //            INSERT INTO GoodsReceipts (ReceiptDate, WarehouseID, SupplierName, CreatedByUserID)
        //            VALUES (@Date, @WarehouseID, @Supplier, @UserID);
        //            SELECT SCOPE_IDENTITY();", conn, transaction);

        //        headerCmd.Parameters.AddWithValue("@Date", receipt.ReceiptDate);
        //        headerCmd.Parameters.AddWithValue("@WarehouseID", receipt.WarehouseID);
        //        headerCmd.Parameters.AddWithValue("@Supplier", receipt.SupplierName);
        //        headerCmd.Parameters.AddWithValue("@UserID", receipt.CreatedByUserID);

        //        int newReceiptId = Convert.ToInt32(headerCmd.ExecuteScalar());

        //        // 2. لكل صنف في السند
        //        foreach (var detail in receipt.Details)
        //        {
        //            // أدخل تفاصيل السند
        //            var detailCmd = new SqlCommand(@"
        //                INSERT INTO GoodsReceiptDetails (ReceiptID, ProductID, Quantity, UnitCost)
        //                VALUES (@ReceiptID, @ProductID, @Qty, @Cost)", conn, transaction);
        //            detailCmd.Parameters.AddWithValue("@ReceiptID", newReceiptId);
        //            detailCmd.Parameters.AddWithValue("@ProductID", detail.ProductID);
        //            detailCmd.Parameters.AddWithValue("@Qty", detail.Quantity);
        //            detailCmd.Parameters.AddWithValue("@Cost", detail.UnitCost);
        //            detailCmd.ExecuteNonQuery();

        //            // حدّث كمية المخزون (إضافة للكمية الموجودة)
        //            var stockCmd = new SqlCommand(@"
        //                IF EXISTS (SELECT 1 FROM Stock WHERE ProductID=@ProductID AND WarehouseID=@WarehouseID)
        //                    UPDATE Stock SET Quantity = Quantity + @Qty
        //                    WHERE ProductID=@ProductID AND WarehouseID=@WarehouseID
        //                ELSE
        //                    INSERT INTO Stock (WarehouseID, ProductID, Quantity)
        //                    VALUES (@WarehouseID, @ProductID, @Qty)", conn, transaction);
        //            stockCmd.Parameters.AddWithValue("@ProductID", detail.ProductID);
        //            stockCmd.Parameters.AddWithValue("@WarehouseID", receipt.WarehouseID);
        //            stockCmd.Parameters.AddWithValue("@Qty", detail.Quantity);
        //            stockCmd.ExecuteNonQuery();
        //        }

        //        transaction.Commit();
        //        return true;
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //}
    }
