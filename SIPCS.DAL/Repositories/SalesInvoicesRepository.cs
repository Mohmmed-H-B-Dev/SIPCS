using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class SalesInvoicesRepository : IRepository<SalesInvoice>
    {
        public List<SalesInvoice> GetAll()
        {
            var invoices = new List<SalesInvoice>();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT s.InvoiceID, s.InvoiceDate, s.CustomerID,
                       s.UserID, s.WarehouseID, s.SubTotal,
                       s.TaxAmount, s.DiscountAmount, s.GrandTotal,
                       s.PaymentType,
                       c.CustomerName,
                       u.FullName AS UserName,
                       w.WarehouseName
                FROM SalesInvoices s
                INNER JOIN Customers c ON s.CustomerID = c.CustomerID
                INNER JOIN Users u ON s.UserID = u.UserID
                INNER JOIN Warehouses w ON s.WarehouseID = w.WarehouseID
                ORDER BY s.InvoiceDate DESC", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                invoices.Add(new SalesInvoice
                {
                    InvoiceID = reader.GetInt32(reader.GetOrdinal("InvoiceID")),
                    InvoiceDate = reader.GetDateTime(reader.GetOrdinal("InvoiceDate")),
                    CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                    UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                    WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),
                    SubTotal = reader.GetDecimal(reader.GetOrdinal("SubTotal")),
                    TaxAmount = reader.GetDecimal(reader.GetOrdinal("TaxAmount")),
                    DiscountAmount = reader.GetDecimal(reader.GetOrdinal("DiscountAmount")),
                    GrandTotal = reader.GetDecimal(reader.GetOrdinal("GrandTotal")),
                    PaymentType = SalesInvoice.GetTypeOfPayment(reader.GetString(reader.GetOrdinal("PaymentType"))),
                    CustomerName = reader.GetString(reader.GetOrdinal("CustomerName")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName"))
                });
            }

            return invoices;
        }

        public SalesInvoice? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT s.InvoiceID, s.InvoiceDate, s.CustomerID,
                       s.UserID, s.WarehouseID, s.SubTotal,
                       s.TaxAmount, s.DiscountAmount, s.GrandTotal,
                       s.PaymentType,
                       c.CustomerName,
                       u.FullName AS UserName,
                       w.WarehouseName
                FROM SalesInvoices s
                INNER JOIN Customers c ON s.CustomerID = c.CustomerID
                INNER JOIN Users u ON s.UserID = u.UserID
                INNER JOIN Warehouses w ON s.WarehouseID = w.WarehouseID
                WHERE s.InvoiceID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new SalesInvoice
                {
                    InvoiceID = reader.GetInt32(reader.GetOrdinal("InvoiceID")),
                    InvoiceDate = reader.GetDateTime(reader.GetOrdinal("InvoiceDate")),
                    CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                    UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                    WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),
                    SubTotal = reader.GetDecimal(reader.GetOrdinal("SubTotal")),
                    TaxAmount = reader.GetDecimal(reader.GetOrdinal("TaxAmount")),
                    DiscountAmount = reader.GetDecimal(reader.GetOrdinal("DiscountAmount")),
                    GrandTotal = reader.GetDecimal(reader.GetOrdinal("GrandTotal")),
                    PaymentType =SalesInvoice.GetTypeOfPayment( reader.GetString(reader.GetOrdinal("PaymentType"))),
                    CustomerName = reader.GetString(reader.GetOrdinal("CustomerName")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName"))
                };
            }

            return null;
        }

        public bool Insert(SalesInvoice salesInvoices)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO SalesInvoices
                    (InvoiceDate, CustomerID, UserID, WarehouseID,
                     SubTotal, TaxAmount, DiscountAmount, GrandTotal, PaymentType)
                VALUES
                    (@InvoiceDate, @CustomerID, @UserID, @WarehouseID,
                     @SubTotal, @TaxAmount, @DiscountAmount, @GrandTotal, @PaymentType)",
                conn);

            cmd.Parameters.AddWithValue("@InvoiceDate", salesInvoices.InvoiceDate);
            cmd.Parameters.AddWithValue("@CustomerID", salesInvoices.CustomerID);
            cmd.Parameters.AddWithValue("@UserID", salesInvoices.UserID);
            cmd.Parameters.AddWithValue("@WarehouseID", salesInvoices.WarehouseID);
            cmd.Parameters.AddWithValue("@SubTotal", salesInvoices.SubTotal);
            cmd.Parameters.AddWithValue("@TaxAmount", salesInvoices.TaxAmount);
            cmd.Parameters.AddWithValue("@DiscountAmount", salesInvoices.DiscountAmount);
            cmd.Parameters.AddWithValue("@GrandTotal", salesInvoices.GrandTotal);
            cmd.Parameters.AddWithValue("@PaymentType", SalesInvoice.GetNamePayment(salesInvoices.PaymentType) );

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(SalesInvoice salesInvoices)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE SalesInvoices
                SET InvoiceDate = @InvoiceDate,
                    CustomerID = @CustomerID,
                    UserID = @UserID,
                    WarehouseID = @WarehouseID,
                    SubTotal = @SubTotal,
                    TaxAmount = @TaxAmount,
                    DiscountAmount = @DiscountAmount,
                    GrandTotal = @GrandTotal,
                    PaymentType = @PaymentType
                WHERE InvoiceID = @InvoiceID", conn);

            cmd.Parameters.AddWithValue("@InvoiceDate", salesInvoices.InvoiceDate);
            cmd.Parameters.AddWithValue("@CustomerID", salesInvoices.CustomerID);
            cmd.Parameters.AddWithValue("@UserID", salesInvoices.UserID);
            cmd.Parameters.AddWithValue("@WarehouseID", salesInvoices.WarehouseID);
            cmd.Parameters.AddWithValue("@SubTotal", salesInvoices.SubTotal);
            cmd.Parameters.AddWithValue("@TaxAmount", salesInvoices.TaxAmount);
            cmd.Parameters.AddWithValue("@DiscountAmount", salesInvoices.DiscountAmount);
            cmd.Parameters.AddWithValue("@GrandTotal", salesInvoices.GrandTotal);
            cmd.Parameters.AddWithValue("@PaymentType", SalesInvoice.GetNamePayment(salesInvoices.PaymentType));
            cmd.Parameters.AddWithValue("@InvoiceID", salesInvoices.InvoiceID);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "DELETE FROM SalesInvoices WHERE InvoiceID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
