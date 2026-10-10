using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class QuotationDetailsRepository : IRepository<QuotationDetail>
    {
        public List<QuotationDetail> GetAll()
        {
            var details = new List<QuotationDetail>();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT d.QuotationDetailID, d.QuotationID, d.ProductID,
                       d.Quantity, d.UnitPrice,
                       p.ProductName
                FROM QuotationDetails d
                INNER JOIN Products p ON d.ProductID = p.ProductID
                ORDER BY d.QuotationDetailID DESC", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                details.Add(new QuotationDetail
                {
                    QuotationDetailID = reader.GetInt32(reader.GetOrdinal("QuotationDetailID")),
                    QuotationID = reader.GetInt32(reader.GetOrdinal("QuotationID")),
                    ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName"))
                });
            }

            return details;
        }

        public QuotationDetail? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT d.QuotationDetailID, d.QuotationID, d.ProductID,
                       d.Quantity, d.UnitPrice,
                       p.ProductName
                FROM QuotationDetails d
                INNER JOIN Products p ON d.ProductID = p.ProductID
                WHERE d.QuotationDetailID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new QuotationDetail
                {
                    QuotationDetailID = reader.GetInt32(reader.GetOrdinal("QuotationDetailID")),
                    QuotationID = reader.GetInt32(reader.GetOrdinal("QuotationID")),
                    ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName"))
                };
            }

            return null;
        }
            
        public bool Insert(QuotationDetail  quotationDetail)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO QuotationDetails
                    (QuotationID, ProductID, Quantity, UnitPrice)
                VALUES
                    (@QuotationID, @ProductID, @Quantity, @UnitPrice)",
                conn);

            cmd.Parameters.AddWithValue("@QuotationID", quotationDetail.QuotationID);
            cmd.Parameters.AddWithValue("@ProductID", quotationDetail.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", quotationDetail.Quantity);
            cmd.Parameters.AddWithValue("@UnitPrice", quotationDetail.UnitPrice);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(QuotationDetail quotationDetails)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE QuotationDetails
                SET QuotationID = @QuotationID,
                    ProductID = @ProductID,
                    Quantity = @Quantity,
                    UnitPrice = @UnitPrice
                WHERE QuotationDetailID = @QuotationDetailID", conn);

            cmd.Parameters.AddWithValue("@QuotationID", quotationDetails.QuotationID);
            cmd.Parameters.AddWithValue("@ProductID", quotationDetails.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", quotationDetails.Quantity);
            cmd.Parameters.AddWithValue("@UnitPrice", quotationDetails.UnitPrice);
            cmd.Parameters.AddWithValue("@QuotationDetailID", quotationDetails.QuotationDetailID);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "DELETE FROM QuotationDetails WHERE QuotationDetailID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
