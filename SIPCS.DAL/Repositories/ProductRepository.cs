using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        public List<Product> GetAll()
        {
            var list = new List<Product>();
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            var cmd = new SqlCommand(@"
                SELECT p.ProductID, p.SKU, p.ProductName, p.CategoryID,
                       p.CostPrice, p.UnitPrice, p.ReorderLevel, c.CategoryName
                FROM Products p
                INNER JOIN Categories c ON p.CategoryID = c.CategoryID
                ORDER BY p.ProductName", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Product
                {
                    ProductID    = reader.GetInt32(0),
                    SKU          = reader.GetString(1),
                    ProductName  = reader.GetString(2),
                    CategoryID   = reader.GetInt32(3),
                    CostPrice    = reader.GetDecimal(4),
                    UnitPrice    = reader.GetDecimal(5),
                    ReorderLevel = reader.GetInt32(6),
                    CategoryName = reader.GetString(7)
                });
            }
            return list;
        }

        public Product? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            var cmd = new SqlCommand(
                "SELECT p.*, c.CategoryName FROM Products p INNER JOIN Categories c ON p.CategoryID = c.CategoryID WHERE p.ProductID = @ID",
                conn);
            cmd.Parameters.AddWithValue("@ID", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Product
                {
                    ProductID    = reader.GetInt32(0),
                    SKU          = reader.GetString(1),
                    ProductName  = reader.GetString(2),
                    CategoryID   = reader.GetInt32(3),
                    CostPrice    = reader.GetDecimal(4),
                    UnitPrice    = reader.GetDecimal(5),
                    ReorderLevel = reader.GetInt32(6),
                    CategoryName = reader.GetString(7)
                };
            }
            return null;
        }

        public Product? GetBySKU(string sku)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            var cmd = new SqlCommand(
                "SELECT p.*, c.CategoryName FROM Products p INNER JOIN Categories c ON p.CategoryID = c.CategoryID WHERE p.SKU = @SKU",
                conn);
            cmd.Parameters.AddWithValue("@SKU", sku);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Product
                {
                    ProductID    = reader.GetInt32(0),
                    SKU          = reader.GetString(1),
                    ProductName  = reader.GetString(2),
                    CategoryID   = reader.GetInt32(3),
                    CostPrice    = reader.GetDecimal(4),
                    UnitPrice    = reader.GetDecimal(5),
                    ReorderLevel = reader.GetInt32(6),
                    CategoryName = reader.GetString(7)
                };
            }
            return null;
        }

        public bool Insert(Product p)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            var cmd = new SqlCommand(@"
                INSERT INTO Products (SKU, ProductName, CategoryID, CostPrice, UnitPrice, ReorderLevel)
                VALUES (@SKU, @ProductName, @CategoryID, @CostPrice, @UnitPrice, @ReorderLevel)",
                conn);
            cmd.Parameters.AddWithValue("@SKU",          p.SKU);
            cmd.Parameters.AddWithValue("@ProductName",  p.ProductName);
            cmd.Parameters.AddWithValue("@CategoryID",   p.CategoryID);
            cmd.Parameters.AddWithValue("@CostPrice",    p.CostPrice);
            cmd.Parameters.AddWithValue("@UnitPrice",    p.UnitPrice);
            cmd.Parameters.AddWithValue("@ReorderLevel", p.ReorderLevel);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Product p)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            var cmd = new SqlCommand(@"
                UPDATE Products
                SET SKU=@SKU, ProductName=@ProductName, CategoryID=@CategoryID,
                    CostPrice=@CostPrice, UnitPrice=@UnitPrice, ReorderLevel=@ReorderLevel
                WHERE ProductID=@ProductID", conn);
            cmd.Parameters.AddWithValue("@SKU",          p.SKU);
            cmd.Parameters.AddWithValue("@ProductName",  p.ProductName);
            cmd.Parameters.AddWithValue("@CategoryID",   p.CategoryID);
            cmd.Parameters.AddWithValue("@CostPrice",    p.CostPrice);
            cmd.Parameters.AddWithValue("@UnitPrice",    p.UnitPrice);
            cmd.Parameters.AddWithValue("@ReorderLevel", p.ReorderLevel);
            cmd.Parameters.AddWithValue("@ProductID",    p.ProductID);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            var cmd = new SqlCommand("DELETE FROM Products WHERE ProductID = @ID", conn);
            cmd.Parameters.AddWithValue("@ID", id);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
