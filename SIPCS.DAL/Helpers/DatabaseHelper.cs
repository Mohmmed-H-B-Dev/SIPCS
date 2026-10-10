using Microsoft.Data.SqlClient;

namespace SIPCS.DAL.Helpers
{
    /// <summary>
    /// مساعد الاتصال بقاعدة البيانات - نقطة الاتصال الوحيدة
    /// </summary>
    public static class DatabaseHelper
    {
        // 🔧 عدّل هذا الاتصال ليناسب بيئتك
        private static string _connectionString =
          "Server=.;Database=SIPCS_DB;User Id=sa;Password=sa123456;TrustServerCertificate=True;";

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// يفتح اتصالاً جديداً بقاعدة البيانات
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// يتحقق أن الاتصال بقاعدة البيانات يعمل
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                using var conn = GetConnection();
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
