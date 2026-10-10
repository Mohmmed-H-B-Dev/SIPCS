using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class EmployeeCommissionsRepository : IRepository<EmployeeCommission>
    {
        public List<EmployeeCommission> GetAll()
        {
            var commissions = new List<EmployeeCommission>();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT ec.CommissionID, ec.InvoiceID, ec.UserID,
                       ec.CommissionAmount, ec.IsPaid, ec.CreatedDate,
                       u.FullName,
                       s.InvoiceDate
                FROM EmployeeCommissions ec
                INNER JOIN Users u ON ec.UserID = u.UserID
                INNER JOIN SalesInvoices s ON ec.InvoiceID = s.InvoiceID
                ORDER BY ec.CreatedDate DESC", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                commissions.Add(new EmployeeCommission
                {
                    CommissionID = reader.GetInt32(reader.GetOrdinal("CommissionID")),
                    InvoiceID = reader.GetInt32(reader.GetOrdinal("InvoiceID")),
                    UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                    CommissionAmount = reader.GetDecimal(reader.GetOrdinal("CommissionAmount")),
                    IsPaid = reader.GetBoolean(reader.GetOrdinal("IsPaid")),
                    CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                    FullName = reader.GetString(reader.GetOrdinal("FullName")),
                    InvoiceDate = reader.GetDateTime(reader.GetOrdinal("InvoiceDate"))
                });
            }

            return commissions;
        }

        public EmployeeCommission? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT ec.CommissionID, ec.InvoiceID, ec.UserID,
                       ec.CommissionAmount, ec.IsPaid, ec.CreatedDate,
                       u.FullName,
                       s.InvoiceDate
                FROM EmployeeCommissions ec
                INNER JOIN Users u ON ec.UserID = u.UserID
                INNER JOIN SalesInvoices s ON ec.InvoiceID = s.InvoiceID
                WHERE ec.CommissionID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new EmployeeCommission
                {
                    CommissionID = reader.GetInt32(reader.GetOrdinal("CommissionID")),
                    InvoiceID = reader.GetInt32(reader.GetOrdinal("InvoiceID")),
                    UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                    CommissionAmount = reader.GetDecimal(reader.GetOrdinal("CommissionAmount")),
                    IsPaid = reader.GetBoolean(reader.GetOrdinal("IsPaid")),
                    CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                    FullName = reader.GetString(reader.GetOrdinal("FullName")),
                    InvoiceDate = reader.GetDateTime(reader.GetOrdinal("InvoiceDate"))
                };
            }

            return null;
        }

        public bool Insert(EmployeeCommission employeeCommissions)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO EmployeeCommissions
                    (InvoiceID, UserID, CommissionAmount, IsPaid, CreatedDate)
                VALUES
                    (@InvoiceID, @UserID, @CommissionAmount, @IsPaid, @CreatedDate)",
                conn);

            cmd.Parameters.AddWithValue("@InvoiceID", employeeCommissions.InvoiceID);
            cmd.Parameters.AddWithValue("@UserID", employeeCommissions.UserID);
            cmd.Parameters.AddWithValue("@CommissionAmount", employeeCommissions.CommissionAmount);
            cmd.Parameters.AddWithValue("@IsPaid", employeeCommissions.IsPaid);
            cmd.Parameters.AddWithValue("@CreatedDate", employeeCommissions.CreatedDate);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(EmployeeCommission employeeCommissions)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE EmployeeCommissions
                SET InvoiceID = @InvoiceID,
                    UserID = @UserID,
                    CommissionAmount = @CommissionAmount,
                    IsPaid = @IsPaid
                WHERE CommissionID = @CommissionID", conn);

            cmd.Parameters.AddWithValue("@InvoiceID", employeeCommissions.InvoiceID);
            cmd.Parameters.AddWithValue("@UserID", employeeCommissions.UserID);
            cmd.Parameters.AddWithValue("@CommissionAmount", employeeCommissions.CommissionAmount);
            cmd.Parameters.AddWithValue("@IsPaid", employeeCommissions.IsPaid);
            cmd.Parameters.AddWithValue("@CommissionID", employeeCommissions.CommissionID);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "DELETE FROM EmployeeCommissions WHERE CommissionID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
