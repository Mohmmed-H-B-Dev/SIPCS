
using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class POSPaymentTransactionsRepository : IRepository<POSPaymentTransaction>
    {
        // =====================================================
        // GET ALL
        // =====================================================
        public List<POSPaymentTransaction> GetAll()
        {
            var payments = new List<POSPaymentTransaction>();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT PaymentTransactionID, InvoiceID,
                       PaymentMethod, Amount, PaymentStatus,
                       TransactionReference, PaymentProvider,
                       CardLast4, PaymentDate, ProcessedByUserID,
                       Notes, CreatedDate
                FROM POS_Payment_Transactions
                ORDER BY PaymentDate DESC", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                payments.Add(MapPayment(reader));
            }

            return payments;
        }

        // =====================================================
        // GET BY ID
        // =====================================================
        public POSPaymentTransaction? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT PaymentTransactionID, InvoiceID,
                       PaymentMethod, Amount, PaymentStatus,
                       TransactionReference, PaymentProvider,
                       CardLast4, PaymentDate, ProcessedByUserID,
                       Notes, CreatedDate
                FROM POS_Payment_Transactions
                WHERE PaymentTransactionID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return MapPayment(reader);
            }

            return null;
        }

        // =====================================================
        // INSERT
        // =====================================================
        public bool Insert(POSPaymentTransaction payment)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO POS_Payment_Transactions
                (
                    InvoiceID, PaymentMethod, Amount,
                    PaymentStatus, TransactionReference,
                    PaymentProvider, CardLast4, PaymentDate,
                    ProcessedByUserID, Notes
                )
                VALUES
                (
                    @InvoiceID, @PaymentMethod, @Amount,
                    @PaymentStatus, @TransactionReference,
                    @PaymentProvider, @CardLast4, @PaymentDate,
                    @ProcessedByUserID, @Notes
                )", conn);

            cmd.Parameters.AddWithValue("@InvoiceID", payment.InvoiceID);
            cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
            cmd.Parameters.AddWithValue("@Amount", payment.Amount);
            cmd.Parameters.AddWithValue("@PaymentStatus", payment.PaymentStatus);

            cmd.Parameters.AddWithValue("@TransactionReference",
                (object?)payment.TransactionReference ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@PaymentProvider",
                (object?)payment.PaymentProvider ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@CardLast4",
                (object?)payment.CardLast4 ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);

            cmd.Parameters.AddWithValue("@ProcessedByUserID",
                (object?)payment.ProcessedByUserID ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@Notes",
                (object?)payment.Notes ?? DBNull.Value);

            return cmd.ExecuteNonQuery() > 0;
        }

        // =====================================================
        // UPDATE
        // =====================================================
        public bool Update(POSPaymentTransaction payment)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE POS_Payment_Transactions
                SET
                    InvoiceID = @InvoiceID,
                    PaymentMethod = @PaymentMethod,
                    Amount = @Amount,
                    PaymentStatus = @PaymentStatus,
                    TransactionReference = @TransactionReference,
                    PaymentProvider = @PaymentProvider,
                    CardLast4 = @CardLast4,
                    PaymentDate = @PaymentDate,
                    ProcessedByUserID = @ProcessedByUserID,
                    Notes = @Notes
                WHERE PaymentTransactionID = @PaymentTransactionID", conn);

            cmd.Parameters.AddWithValue("@InvoiceID", payment.InvoiceID);
            cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
            cmd.Parameters.AddWithValue("@Amount", payment.Amount);
            cmd.Parameters.AddWithValue("@PaymentStatus", payment.PaymentStatus);

            cmd.Parameters.AddWithValue("@TransactionReference",
                (object?)payment.TransactionReference ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@PaymentProvider",
                (object?)payment.PaymentProvider ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@CardLast4",
                (object?)payment.CardLast4 ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);

            cmd.Parameters.AddWithValue("@ProcessedByUserID",
                (object?)payment.ProcessedByUserID ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@Notes",
                (object?)payment.Notes ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@PaymentTransactionID",
                payment.PaymentTransactionID);

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
                DELETE FROM POS_Payment_Transactions
                WHERE PaymentTransactionID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }

        // =====================================================
        // PRIVATE MAPPING METHOD
        // =====================================================
        private static POSPaymentTransaction MapPayment(SqlDataReader reader)
        {
            return new POSPaymentTransaction
            {
                PaymentTransactionID = reader.GetInt32(
                    reader.GetOrdinal("PaymentTransactionID")),

                InvoiceID = reader.GetInt32(
                    reader.GetOrdinal("InvoiceID")),

                PaymentMethod = reader.GetString(
                    reader.GetOrdinal("PaymentMethod")),

                Amount = reader.GetDecimal(
                    reader.GetOrdinal("Amount")),

                PaymentStatus = reader.GetString(
                    reader.GetOrdinal("PaymentStatus")),

                TransactionReference = reader.IsDBNull(
                    reader.GetOrdinal("TransactionReference"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("TransactionReference")),

                PaymentProvider = reader.IsDBNull(
                    reader.GetOrdinal("PaymentProvider"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("PaymentProvider")),

                CardLast4 = reader.IsDBNull(
                    reader.GetOrdinal("CardLast4"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("CardLast4")),

                PaymentDate = reader.GetDateTime(
                    reader.GetOrdinal("PaymentDate")),

                ProcessedByUserID = reader.IsDBNull(
                    reader.GetOrdinal("ProcessedByUserID"))
                    ? null
                    : reader.GetInt32(reader.GetOrdinal("ProcessedByUserID")),

                Notes = reader.IsDBNull(reader.GetOrdinal("Notes"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("Notes")),

                CreatedDate = reader.GetDateTime(
                    reader.GetOrdinal("CreatedDate"))
            };
        }
    }
}
