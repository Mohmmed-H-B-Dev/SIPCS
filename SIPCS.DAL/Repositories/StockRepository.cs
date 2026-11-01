using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;
using System.Data;

namespace SIPCS.DAL.Repositories
{
    public class StockRepository : IRepository<Stock>
    {
        public static List<Stock> GetAll()
        {
            var stock = new List<Stock>();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            string sql = @"
                SELECT s.StockID, s.WarehouseID, s.ProductID, s.Quantity,
       w.WarehouseName, p.ProductName,p.SKU,p.ReorderLevel
FROM Stock s
INNER JOIN Warehouses w ON s.WarehouseID = w.WarehouseID
INNER JOIN Products p ON s.ProductID = p.ProductID
ORDER BY w.WarehouseName, p.ProductName";


            var cmd = new SqlCommand(sql, conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                stock.Add(new Stock
                {
                    StockID = reader.GetInt32(reader.GetOrdinal("StockID")),
                    WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),
                    ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                    ReorderLevel = reader.GetInt32(reader.GetOrdinal("ReorderLevel")),
                    SKU = reader.GetString(reader.GetOrdinal("SKU"))
                });
            }

            return stock;
        }

        /// <summary>
        /// This Function return a view between a different tables  Products,Stock
        /// </summary>
        /// <param name="WarehouseID"></param>
        /// <returns>DataTable  of a view Products in this Warehouse </returns>
        public static DataTable GetAll(int WarehouseID)
        {
            DataTable stock = new DataTable();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"SELECT        s.StockID, s.WarehouseID, s.ProductID, s.Quantity, w.WarehouseName,
p.ProductName, p.SKU, p.ReorderLevel, p.UnitPrice, Categories.CategoryName
FROM            Stock AS s INNER JOIN
                         Warehouses AS w ON s.WarehouseID = w.WarehouseID INNER JOIN
                         Products AS p ON s.ProductID = p.ProductID INNER JOIN
                         Categories ON p.CategoryID = Categories.CategoryID
WHERE        (s.WarehouseID = @WarehouseID)
ORDER BY w.WarehouseName, p.ProductName


", conn);

            cmd.Parameters.AddWithValue("@WarehouseID", WarehouseID);

            using var reader = cmd.ExecuteReader();

            if(reader.Read())
                stock.Load(reader);

            return stock;
        }

        public static Stock? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT s.StockID, s.WarehouseID, s.ProductID, s.Quantity,
                       w.WarehouseName, p.ProductName, p.SKU, p.ReorderLevel
                FROM Stock s
                INNER JOIN Warehouses w ON s.WarehouseID = w.WarehouseID
                INNER JOIN Products p ON s.ProductID = p.ProductID
                WHERE s.StockID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Stock
                {
                    StockID = reader.GetInt32(reader.GetOrdinal("StockID")),
                    WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),
                    ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                    ReorderLevel = reader.GetInt32(reader.GetOrdinal("ReorderLevel")),
                    SKU = reader.GetString(reader.GetOrdinal("SKU"))
                };
            }

            return null;
        }


        public static Stock? GetById(int idStock, int idWarehouse)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT s.StockID, s.WarehouseID, s.ProductID, s.Quantity,
                       w.WarehouseName, p.ProductName,p.SKU, p.ReorderLevel
                FROM Stock s
                INNER JOIN Warehouses w ON s.WarehouseID = w.WarehouseID
                INNER JOIN Products p ON s.ProductID = p.ProductID
                WHERE s.StockID = @StockID AND s.WarehouseID = @WarehouseID", conn);

            cmd.Parameters.AddWithValue("@StockID", idStock);
            cmd.Parameters.AddWithValue("@WarehouseID", idWarehouse);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Stock
                {
                    StockID = reader.GetInt32(reader.GetOrdinal("StockID")),
                    WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),
                    ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                    ReorderLevel = reader.GetInt32(reader.GetOrdinal("ReorderLevel")),
                    SKU = reader.GetString(reader.GetOrdinal("SKU"))
                };
            }

            return null;
        }

        public static bool Insert(Stock stock)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO Stock (WarehouseID, ProductID, Quantity)
                VALUES (@WarehouseID, @ProductID, @Quantity)", conn);

            cmd.Parameters.AddWithValue("@WarehouseID", stock.WarehouseID);
            cmd.Parameters.AddWithValue("@ProductID", stock.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", stock.Quantity);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool Update(Stock stock)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE Stock
                SET WarehouseID = @WarehouseID,
                    ProductID = @ProductID,
                    Quantity = @Quantity
                WHERE StockID = @StockID", conn);

            cmd.Parameters.AddWithValue("@WarehouseID", stock.WarehouseID);
            cmd.Parameters.AddWithValue("@ProductID", stock.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", stock.Quantity);
            cmd.Parameters.AddWithValue("@StockID", stock.StockID);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "DELETE FROM Stock WHERE StockID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
