
using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class POSInvoiceDetailsRepository : IRepository<POSInvoiceDetails>
    {
        // =====================================================
        // GET ALL
        // =====================================================
        public List<POSInvoiceDetails> GetAll()
        {
            var details = new List<POSInvoiceDetails>();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT InvoiceDetailID, InvoiceID, ProductID,
                       ProductName, SKU, Quantity, UnitPrice,
                       SubTotal, DiscountAmount, TaxRate,
                       TaxAmount, TotalLine, UnitCost
                FROM POS_Invoice_Details
                ORDER BY InvoiceDetailID DESC", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                details.Add(MapDetails(reader));
            }

            return details;
        }

        // =====================================================
        // GET BY ID
        // =====================================================
        public POSInvoiceDetails? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT InvoiceDetailID, InvoiceID, ProductID,
                       ProductName, SKU, Quantity, UnitPrice,
                       SubTotal, DiscountAmount, TaxRate,
                       TaxAmount, TotalLine, UnitCost
                FROM POS_Invoice_Details
                WHERE InvoiceDetailID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return MapDetails(reader);
            }

            return null;
        }

        // =====================================================
        // INSERT
        // =====================================================
        public bool Insert(POSInvoiceDetails detail)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO POS_Invoice_Details
                (
                    InvoiceID, ProductID, ProductName,
                    SKU, Quantity, UnitPrice, SubTotal,
                    DiscountAmount, TaxRate, TaxAmount, UnitCost
                )
                VALUES
                (
                    @InvoiceID, @ProductID, @ProductName,
                    @SKU, @Quantity, @UnitPrice, @SubTotal,
                    @DiscountAmount, @TaxRate, @TaxAmount, @UnitCost
                )", conn);

            cmd.Parameters.AddWithValue("@InvoiceID", detail.InvoiceID);
            cmd.Parameters.AddWithValue("@ProductID", detail.ProductID);
            cmd.Parameters.AddWithValue("@ProductName", detail.ProductName);
            cmd.Parameters.AddWithValue("@SKU", (object?)detail.SKU ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", detail.Quantity);
            cmd.Parameters.AddWithValue("@UnitPrice", detail.UnitPrice);
            cmd.Parameters.AddWithValue("@SubTotal", detail.SubTotal);
            cmd.Parameters.AddWithValue("@DiscountAmount", detail.DiscountAmount);
            cmd.Parameters.AddWithValue("@TaxRate", detail.TaxRate);
            cmd.Parameters.AddWithValue("@TaxAmount", detail.TaxAmount);
            cmd.Parameters.AddWithValue("@UnitCost", detail.UnitCost);

            return cmd.ExecuteNonQuery() > 0;
        }

        // =====================================================
        // UPDATE
        // =====================================================
        public bool Update(POSInvoiceDetails detail)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE POS_Invoice_Details
                SET
                    InvoiceID = @InvoiceID,
                    ProductID = @ProductID,
                    ProductName = @ProductName,
                    SKU = @SKU,
                    Quantity = @Quantity,
                    UnitPrice = @UnitPrice,
                    SubTotal = @SubTotal,
                    DiscountAmount = @DiscountAmount,
                    TaxRate = @TaxRate,
                    TaxAmount = @TaxAmount,
                    UnitCost = @UnitCost
                WHERE InvoiceDetailID = @InvoiceDetailID", conn);

            cmd.Parameters.AddWithValue("@InvoiceID", detail.InvoiceID);
            cmd.Parameters.AddWithValue("@ProductID", detail.ProductID);
            cmd.Parameters.AddWithValue("@ProductName", detail.ProductName);
            cmd.Parameters.AddWithValue("@SKU", (object?)detail.SKU ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", detail.Quantity);
            cmd.Parameters.AddWithValue("@UnitPrice", detail.UnitPrice);
            cmd.Parameters.AddWithValue("@SubTotal", detail.SubTotal);
            cmd.Parameters.AddWithValue("@DiscountAmount", detail.DiscountAmount);
            cmd.Parameters.AddWithValue("@TaxRate", detail.TaxRate);
            cmd.Parameters.AddWithValue("@TaxAmount", detail.TaxAmount);
            cmd.Parameters.AddWithValue("@UnitCost", detail.UnitCost);
            cmd.Parameters.AddWithValue("@InvoiceDetailID", detail.InvoiceDetailID);

            return cmd.ExecuteNonQuery() > 0;
        }

        // =====================================================
        // DELETE
        // =====================================================
        public bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                DELETE FROM POS_Invoice_Details
                WHERE InvoiceDetailID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }

        // =====================================================
        // PRIVATE MAPPING METHOD
        // =====================================================
        private static POSInvoiceDetails MapDetails(SqlDataReader reader)
        {
            return new POSInvoiceDetails
            {
                InvoiceDetailID = reader.GetInt32(reader.GetOrdinal("InvoiceDetailID")),
                InvoiceID = reader.GetInt32(reader.GetOrdinal("InvoiceID")),
                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),

                SKU = reader.IsDBNull(reader.GetOrdinal("SKU"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("SKU")),

                Quantity = reader.GetDecimal(reader.GetOrdinal("Quantity")),
                UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                SubTotal = reader.GetDecimal(reader.GetOrdinal("SubTotal")),
                DiscountAmount = reader.GetDecimal(reader.GetOrdinal("DiscountAmount")),
                TaxRate = reader.GetDecimal(reader.GetOrdinal("TaxRate")),
                TaxAmount = reader.GetDecimal(reader.GetOrdinal("TaxAmount")),
                TotalLine = reader.GetDecimal(reader.GetOrdinal("TotalLine")),
                UnitCost = reader.GetDecimal(reader.GetOrdinal("UnitCost"))
            };
        }
    }
}
