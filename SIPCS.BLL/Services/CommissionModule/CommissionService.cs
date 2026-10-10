using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.BLL.Services.CommissionModule
{
    /// <summary>
    /// منطق احتساب وإدارة عمولات الموظفين
    /// </summary>
    public class CommissionService
    {
        /// <summary>
        /// احتساب عمولة الموظف عند إتمام الفاتورة
        /// </summary>
        public void CalculateCommission(int invoiceId, int userId, decimal grandTotal,
            SqlConnection conn, SqlTransaction transaction)
        {
            // جلب دور الموظف
            var roleCmd = new SqlCommand(
                "SELECT RoleID FROM Users WHERE UserID = @UserID", conn, transaction);
            roleCmd.Parameters.AddWithValue("@UserID", userId);
            var roleId = roleCmd.ExecuteScalar();
            if (roleId == null) return;

            // جلب قاعدة العمولة لهذا الدور
            var ruleCmd = new SqlCommand(
                "SELECT TargetType, CommissionValue FROM CommissionRules WHERE RoleID = @RoleID",
                conn, transaction);
            ruleCmd.Parameters.AddWithValue("@RoleID", roleId);

            using var reader = ruleCmd.ExecuteReader();
            if (!reader.Read()) return;

            int targetType    = reader.GetInt32(0);
            decimal ruleValue = reader.GetDecimal(1);
            reader.Close();

            // احسب مبلغ العمولة
            decimal commissionAmount = targetType == 1
                ? Math.Round(grandTotal * ruleValue / 100, 2)  // نسبة مئوية
                : ruleValue;                                     // مبلغ ثابت

            // سجّل العمولة
            var insertCmd = new SqlCommand(@"
                INSERT INTO EmployeeCommissions (InvoiceID, UserID, CommissionAmount, IsPaid, CreatedDate)
                VALUES (@InvID, @UserID, @Amount, 0, @Date)", conn, transaction);
            insertCmd.Parameters.AddWithValue("@InvID",  invoiceId);
            insertCmd.Parameters.AddWithValue("@UserID", userId);
            insertCmd.Parameters.AddWithValue("@Amount", commissionAmount);
            insertCmd.Parameters.AddWithValue("@Date",   DateTime.Now);
            insertCmd.ExecuteNonQuery();
        }

        /// <summary>
        /// جلب تقرير عمولات الموظفين لفترة محددة
        /// </summary>
        public List<EmployeeCommission> GetCommissionsReport(DateTime from, DateTime to)
        {
            var list = new List<EmployeeCommission>();
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            var cmd = new SqlCommand(@"
                SELECT ec.CommissionID, ec.InvoiceID, ec.UserID,
                       ec.CommissionAmount, ec.IsPaid, ec.CreatedDate,
                       u.FullName, i.InvoiceDate
                FROM EmployeeCommissions ec
                INNER JOIN Users u ON ec.UserID = u.UserID
                INNER JOIN SalesInvoices i ON ec.InvoiceID = i.InvoiceID
                WHERE ec.CreatedDate BETWEEN @From AND @To
                ORDER BY ec.CreatedDate DESC", conn);
            cmd.Parameters.AddWithValue("@From", from.Date);
            cmd.Parameters.AddWithValue("@To",   to.Date.AddDays(1).AddSeconds(-1));

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new EmployeeCommission
                {
                    CommissionID     = reader.GetInt32(0),
                    InvoiceID        = reader.GetInt32(1),
                    UserID           = reader.GetInt32(2),
                    CommissionAmount = reader.GetDecimal(3),
                    IsPaid           = reader.GetBoolean(4),
                    CreatedDate      = reader.GetDateTime(5),
                    UserName         = reader.GetString(6),
                    InvoiceDate      = reader.GetDateTime(7)
                });
            }
            return list;
        }

        /// <summary>
        /// تسجيل صرف العمولات المعلقة لموظف معين
        /// </summary>
        public bool PayCommissions(int userId)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            var cmd = new SqlCommand(
                "UPDATE EmployeeCommissions SET IsPaid = 1 WHERE UserID = @UserID AND IsPaid = 0",
                conn);
            cmd.Parameters.AddWithValue("@UserID", userId);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
