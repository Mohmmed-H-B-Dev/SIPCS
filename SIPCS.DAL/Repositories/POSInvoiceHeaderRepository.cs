
using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class POSInvoiceHeaderRepository : IRepository<POSInvoiceHeader>
    {
        // =====================================================
        // GET ALL
        // =====================================================
        public List<POSInvoiceHeader> GetAll()
        {
            var invoices = new List<POSInvoiceHeader>();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT InvoiceID, InvoiceNumber, InvoiceDate,
                       CustomerID, UserID, WarehouseID,
                       SubTotal, DiscountAmount, TaxAmount,
                       GrandTotal, InvoiceStatus, Notes, CreatedDate
                FROM POS_Invoice_Header
                ORDER BY InvoiceDate DESC", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                invoices.Add(MapInvoice(reader));
            }

            return invoices;
        }

        // =====================================================
        // GET BY ID
        // =====================================================
        public POSInvoiceHeader? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT InvoiceID, InvoiceNumber, InvoiceDate,
                       CustomerID, UserID, WarehouseID,
                       SubTotal, DiscountAmount, TaxAmount,
                       GrandTotal, InvoiceStatus, Notes, CreatedDate
                FROM POS_Invoice_Header
                WHERE InvoiceID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return MapInvoice(reader);
            }

            return null;
        }

        // =====================================================
        // INSERT
        // =====================================================
        public bool Insert(POSInvoiceHeader invoice)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO POS_Invoice_Header
                (
                    InvoiceNumber, InvoiceDate, CustomerID,
                    UserID, WarehouseID, SubTotal,
                    DiscountAmount, TaxAmount, GrandTotal,
                    InvoiceStatus, Notes
                )
                VALUES
                (
                    @InvoiceNumber, @InvoiceDate, @CustomerID,
                    @UserID, @WarehouseID, @SubTotal,
                    @DiscountAmount, @TaxAmount, @GrandTotal,
                    @InvoiceStatus, @Notes
                )", conn);

            cmd.Parameters.AddWithValue("@InvoiceNumber", invoice.InvoiceNumber);
            cmd.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate);
            cmd.Parameters.AddWithValue("@CustomerID", (object?)invoice.CustomerID ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UserID", invoice.UserID);
            cmd.Parameters.AddWithValue("@WarehouseID", invoice.WarehouseID);
            cmd.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);
            cmd.Parameters.AddWithValue("@DiscountAmount", invoice.DiscountAmount);
            cmd.Parameters.AddWithValue("@TaxAmount", invoice.TaxAmount);
            cmd.Parameters.AddWithValue("@GrandTotal", invoice.GrandTotal);
            cmd.Parameters.AddWithValue("@InvoiceStatus", invoice.InvoiceStatus);
            cmd.Parameters.AddWithValue("@Notes", (object?)invoice.Notes ?? DBNull.Value);

            return cmd.ExecuteNonQuery() > 0;
        }

        // =====================================================
        // UPDATE
        // =====================================================
        public bool Update(POSInvoiceHeader invoice)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE POS_Invoice_Header
                SET
                    InvoiceNumber = @InvoiceNumber,
                    InvoiceDate = @InvoiceDate,
                    CustomerID = @CustomerID,
                    UserID = @UserID,
                    WarehouseID = @WarehouseID,
                    SubTotal = @SubTotal,
                    DiscountAmount = @DiscountAmount,
                    TaxAmount = @TaxAmount,
                    GrandTotal = @GrandTotal,
                    InvoiceStatus = @InvoiceStatus,
                    Notes = @Notes
                WHERE InvoiceID = @InvoiceID", conn);

            cmd.Parameters.AddWithValue("@InvoiceNumber", invoice.InvoiceNumber);
            cmd.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate);
            cmd.Parameters.AddWithValue("@CustomerID", (object?)invoice.CustomerID ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UserID", invoice.UserID);
            cmd.Parameters.AddWithValue("@WarehouseID", invoice.WarehouseID);
            cmd.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);
            cmd.Parameters.AddWithValue("@DiscountAmount", invoice.DiscountAmount);
            cmd.Parameters.AddWithValue("@TaxAmount", invoice.TaxAmount);
            cmd.Parameters.AddWithValue("@GrandTotal", invoice.GrandTotal);
            cmd.Parameters.AddWithValue("@InvoiceStatus", invoice.InvoiceStatus);
            cmd.Parameters.AddWithValue("@Notes", (object?)invoice.Notes ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceID", invoice.InvoiceID);

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
                DELETE FROM POS_Invoice_Header
                WHERE InvoiceID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }

        // =====================================================
        // PRIVATE MAPPING METHOD
        // =====================================================
        private static POSInvoiceHeader MapInvoice(SqlDataReader reader)
        {
            return new POSInvoiceHeader
            {
                InvoiceID = reader.GetInt32(reader.GetOrdinal("InvoiceID")),
                InvoiceNumber = reader.GetString(reader.GetOrdinal("InvoiceNumber")),
                InvoiceDate = reader.GetDateTime(reader.GetOrdinal("InvoiceDate")),

                CustomerID = reader.IsDBNull(reader.GetOrdinal("CustomerID"))
                    ? null
                    : reader.GetInt32(reader.GetOrdinal("CustomerID")),

                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),

                SubTotal = reader.GetDecimal(reader.GetOrdinal("SubTotal")),
                DiscountAmount = reader.GetDecimal(reader.GetOrdinal("DiscountAmount")),
                TaxAmount = reader.GetDecimal(reader.GetOrdinal("TaxAmount")),
                GrandTotal = reader.GetDecimal(reader.GetOrdinal("GrandTotal")),

                InvoiceStatus = POSInvoiceHeader.GetTypeOfStatus(reader.GetString(reader.GetOrdinal("InvoiceStatus"))),

                Notes = reader.IsDBNull(reader.GetOrdinal("Notes"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("Notes")),

                CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"))
            };
        }
    }
}
