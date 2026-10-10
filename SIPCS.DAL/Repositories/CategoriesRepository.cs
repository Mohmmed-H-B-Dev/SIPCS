using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class CategoriesRepository : IRepository<Category>
    {
        public List<Category> GetAll()
        {
            var categories = new List<Category>();
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT CategoryID, CategoryName
                FROM Categories
                ORDER BY CategoryName", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                categories.Add(new Category
                {
                    CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                    CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"))
                });
            }

            return categories;
        }

        public Category? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT CategoryID, CategoryName
                FROM Categories
                WHERE CategoryID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Category
                {
                    CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                    CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"))
                };
            }

            return null;
        }

        public bool Insert(Category category)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO Categories (CategoryName)
                VALUES (@CategoryName)", conn);

            cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Category category)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE Categories
                SET CategoryName = @CategoryName
                WHERE CategoryID = @CategoryID", conn);

            cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "DELETE FROM Categories WHERE CategoryID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
