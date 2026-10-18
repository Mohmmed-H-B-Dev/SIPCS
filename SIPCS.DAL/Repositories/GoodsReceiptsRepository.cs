using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;
using System.Data;

namespace SIPCS.DAL.Repositories
{
    public class GoodsReceiptsRepository : IRepository<GoodsReceipt>
    {
        public List<GoodsReceipt> GetAll()
        {
            var receipts = new List<GoodsReceipt>();
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

           using var cmd = new SqlCommand(@"
                SELECT gr.ReceiptID, gr.ReceiptDate, gr.WarehouseID,
                       gr.SupplierName, gr.CreatedByUserID,
                       w.WarehouseName, u.FullName AS CreatedByName
                FROM GoodsReceipts gr
                INNER JOIN Warehouses w ON gr.WarehouseID = w.WarehouseID
                INNER JOIN Users u ON gr.CreatedByUserID = u.UserID
                ORDER BY gr.ReceiptDate DESC", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                receipts.Add(new GoodsReceipt
                {
                    ReceiptID = reader.GetInt32(reader.GetOrdinal("ReceiptID")),
                    ReceiptDate = reader.GetDateTime(reader.GetOrdinal("ReceiptDate")),
                    WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),
                    SupplierName = reader.GetString(reader.GetOrdinal("SupplierName")),
                    CreatedByUserID = reader.GetInt32(reader.GetOrdinal("CreatedByUserID")),
                    WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName")),
                    CreatedByUserName = reader.GetString(reader.GetOrdinal("CreatedByName"))
                });
            }

            return receipts;
        }

        public GoodsReceipt? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

           using var cmd = new SqlCommand(@"
                SELECT gr.ReceiptID, gr.ReceiptDate, gr.WarehouseID,
                       gr.SupplierName, gr.CreatedByUserID,
                       w.WarehouseName, u.FullName AS CreatedByName
                FROM GoodsReceipts gr
                INNER JOIN Warehouses w ON gr.WarehouseID = w.WarehouseID
                INNER JOIN Users u ON gr.CreatedByUserID = u.UserID
                WHERE gr.ReceiptID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new GoodsReceipt
                {
                    ReceiptID = reader.GetInt32(reader.GetOrdinal("ReceiptID")),
                    ReceiptDate = reader.GetDateTime(reader.GetOrdinal("ReceiptDate")),
                    WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),
                    SupplierName = reader.GetString(reader.GetOrdinal("SupplierName")),
                    CreatedByUserID = reader.GetInt32(reader.GetOrdinal("CreatedByUserID")),
                    WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName")),
                    CreatedByUserName = reader.GetString(reader.GetOrdinal("CreatedByName"))
                };
            }

            return null;
        }

        public bool Insert(GoodsReceipt goodsReceipts)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

          using  var cmd = new SqlCommand(@"
                INSERT INTO GoodsReceipts
                    (ReceiptDate, WarehouseID, SupplierName, CreatedByUserID)
                VALUES
                    (@ReceiptDate, @WarehouseID, @SupplierName, @CreatedByUserID)",
                conn);

            cmd.Parameters.AddWithValue("@ReceiptDate", goodsReceipts.ReceiptDate);
            cmd.Parameters.AddWithValue("@WarehouseID", goodsReceipts.WarehouseID);
            cmd.Parameters.AddWithValue("@SupplierName", goodsReceipts.SupplierName);
            cmd.Parameters.AddWithValue("@CreatedByUserID", goodsReceipts.CreatedByUserID);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(GoodsReceipt goodsReceipts)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

          using  var cmd = new SqlCommand(@"
                UPDATE GoodsReceipts
                SET ReceiptDate = @ReceiptDate,
                    WarehouseID = @WarehouseID,
                    SupplierName = @SupplierName,
                    CreatedByUserID = @CreatedByUserID
                WHERE ReceiptID = @ReceiptID", conn);

            cmd.Parameters.AddWithValue("@ReceiptDate", goodsReceipts.ReceiptDate);
            cmd.Parameters.AddWithValue("@WarehouseID", goodsReceipts.WarehouseID);
            cmd.Parameters.AddWithValue("@SupplierName", goodsReceipts.SupplierName);
            cmd.Parameters.AddWithValue("@CreatedByUserID", goodsReceipts.CreatedByUserID);
            cmd.Parameters.AddWithValue("@ReceiptID", goodsReceipts.ReceiptID);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

           using var cmd = new SqlCommand(
                "DELETE FROM GoodsReceipts WHERE ReceiptID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }


        public static bool ReceiveGoods(GoodsReceipt receipt,int WarehouseID,int UserID,string SupplierName)
        {
            DataTable dt=new DataTable();
            dt.Columns.Add("ProductID", typeof(int));
            dt.Columns.Add("Quantity",typeof(int));
            dt.Columns.Add("UnitCost",typeof(decimal));

            foreach (var item in receipt.Details)
            {
                dt.Rows.Add(item.ProductID, item.Quantity, item.UnitCost);
            }

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            using   var cmd = new SqlCommand(
                "sp_ReceiveGoods", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@WarehouseID", WarehouseID);

            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@SupplierName", SupplierName);
           SqlParameter tvpParm= cmd.Parameters.AddWithValue("@TempTable", dt);
            tvpParm.SqlDbType =SqlDbType.Structured;
            tvpParm.TypeName="[TempGoodsReceiptDetails]";


            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
