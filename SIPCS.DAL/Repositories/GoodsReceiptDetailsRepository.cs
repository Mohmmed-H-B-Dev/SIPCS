using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class GoodsReceiptDetailsRepository : IRepository<GoodsReceiptDetail>
    {
        public List<GoodsReceiptDetail> GetAll()
        {
            var details = new List<GoodsReceiptDetail>();
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT d.ReceiptDetailID, d.ReceiptID, d.ProductID,
                       d.Quantity, d.UnitCost,
                       p.ProductName
                FROM GoodsReceiptDetails d
                INNER JOIN Products p ON d.ProductID = p.ProductID
                ORDER BY d.ReceiptDetailID DESC", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                details.Add(new GoodsReceiptDetail
                {
                    ReceiptDetailID = reader.GetInt32(reader.GetOrdinal("ReceiptDetailID")),
                    ReceiptID = reader.GetInt32(reader.GetOrdinal("ReceiptID")),
                    ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    UnitCost = reader.GetDecimal(reader.GetOrdinal("UnitCost")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName"))
                });
            }

            return details;
        }

        public GoodsReceiptDetail? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT d.ReceiptDetailID, d.ReceiptID, d.ProductID,
                       d.Quantity, d.UnitCost,
                       p.ProductName
                FROM GoodsReceiptDetails d
                INNER JOIN Products p ON d.ProductID = p.ProductID
                WHERE d.ReceiptDetailID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new GoodsReceiptDetail
                {
                    ReceiptDetailID = reader.GetInt32(reader.GetOrdinal("ReceiptDetailID")),
                    ReceiptID = reader.GetInt32(reader.GetOrdinal("ReceiptID")),
                    ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    UnitCost = reader.GetDecimal(reader.GetOrdinal("UnitCost")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName"))
                };
            }

            return null;
        }

        public bool Insert(GoodsReceiptDetail   goodsReceiptDetails)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO GoodsReceiptDetails
                    (ReceiptID, ProductID, Quantity, UnitCost)
                VALUES
                    (@ReceiptID, @ProductID, @Quantity, @UnitCost)",
                conn);

            cmd.Parameters.AddWithValue("@ReceiptID", goodsReceiptDetails.ReceiptID);
            cmd.Parameters.AddWithValue("@ProductID", goodsReceiptDetails.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", goodsReceiptDetails.Quantity);
            cmd.Parameters.AddWithValue("@UnitCost", goodsReceiptDetails.UnitCost);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(GoodsReceiptDetail goodsReceiptDetails)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE GoodsReceiptDetails
                SET ReceiptID = @ReceiptID,
                    ProductID = @ProductID,
                    Quantity = @Quantity,
                    UnitCost = @UnitCost
                WHERE ReceiptDetailID = @ReceiptDetailID", conn);

            cmd.Parameters.AddWithValue("@ReceiptID", goodsReceiptDetails.ReceiptID);
            cmd.Parameters.AddWithValue("@ProductID", goodsReceiptDetails.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", goodsReceiptDetails.Quantity);
            cmd.Parameters.AddWithValue("@UnitCost", goodsReceiptDetails.UnitCost);
            cmd.Parameters.AddWithValue("@ReceiptDetailID", goodsReceiptDetails.ReceiptDetailID);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "DELETE FROM GoodsReceiptDetails WHERE ReceiptDetailID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
