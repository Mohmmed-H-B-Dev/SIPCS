using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class SalesInvoiceDetailsRepository : IRepository<SalesInvoiceDetail>
    {
        public List<SalesInvoiceDetail> GetAll()
        {
            var details = new List<SalesInvoiceDetail>();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT d.InvoiceDetailID, d.InvoiceID, d.ProductID,
                       d.Quantity, d.UnitPrice, d.TotalLine,
                       p.ProductName
                FROM SalesInvoiceDetails d
                INNER JOIN Products p ON d.ProductID = p.ProductID
                ORDER BY d.InvoiceDetailID DESC", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                details.Add(new SalesInvoiceDetail
                {
                    InvoiceDetailID = reader.GetInt32(reader.GetOrdinal("InvoiceDetailID")),
                    InvoiceID = reader.GetInt32(reader.GetOrdinal("InvoiceID")),
                    ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                    TotalCharge = reader.GetDecimal(reader.GetOrdinal("TotalLine")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName"))
                });
            }

            return details;
        }

        public SalesInvoiceDetail? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT d.InvoiceDetailID, d.InvoiceID, d.ProductID,
                       d.Quantity, d.UnitPrice, d.TotalLine,
                       p.ProductName
                FROM SalesInvoiceDetails d
                INNER JOIN Products p ON d.ProductID = p.ProductID
                WHERE d.InvoiceDetailID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new SalesInvoiceDetail
                {
                    InvoiceDetailID = reader.GetInt32(reader.GetOrdinal("InvoiceDetailID")),
                    InvoiceID = reader.GetInt32(reader.GetOrdinal("InvoiceID")),
                    ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                    TotalCharge = reader.GetDecimal(reader.GetOrdinal("TotalLine")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName"))
                };
            }

            return null;
        }

        public bool Insert(SalesInvoiceDetail salesInvoiceDetails)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO SalesInvoiceDetails
                    (InvoiceID, ProductID, Quantity, UnitPrice, TotalLine)
                VALUES
                    (@InvoiceID, @ProductID, @Quantity, @UnitPrice, @TotalLine)",
                conn);

            cmd.Parameters.AddWithValue("@InvoiceID", salesInvoiceDetails.InvoiceID);
            cmd.Parameters.AddWithValue("@ProductID", salesInvoiceDetails.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", salesInvoiceDetails.Quantity);
            cmd.Parameters.AddWithValue("@UnitPrice", salesInvoiceDetails.UnitPrice);
            cmd.Parameters.AddWithValue("@TotalLine", salesInvoiceDetails.TotalLine);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(SalesInvoiceDetail salesInvoiceDetails)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE SalesInvoiceDetails
                SET InvoiceID = @InvoiceID,
                    ProductID = @ProductID,
                    Quantity = @Quantity,
                    UnitPrice = @UnitPrice,
                    TotalLine = @TotalLine
                WHERE InvoiceDetailID = @InvoiceDetailID", conn);

            cmd.Parameters.AddWithValue("@InvoiceID", salesInvoiceDetails.InvoiceID);
            cmd.Parameters.AddWithValue("@ProductID", salesInvoiceDetails.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", salesInvoiceDetails.Quantity);
            cmd.Parameters.AddWithValue("@UnitPrice", salesInvoiceDetails.UnitPrice);
            cmd.Parameters.AddWithValue("@TotalLine", salesInvoiceDetails.TotalLine);
            cmd.Parameters.AddWithValue("@InvoiceDetailID", salesInvoiceDetails.InvoiceDetailID);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "DELETE FROM SalesInvoiceDetails WHERE InvoiceDetailID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
