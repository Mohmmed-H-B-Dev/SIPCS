using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class SalesTargetsRepository : IRepository<SalesTarget>
    {
        public List<SalesTarget> GetAll()
        {
            var targets = new List<SalesTarget>();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT st.TargetID, st.UserID, st.TargetAmount,
                       st.StartDate, st.EndDate, st.IsAchieved,
                       u.FullName
                FROM SalesTargets st
                INNER JOIN Users u ON st.UserID = u.UserID
                ORDER BY st.StartDate DESC, u.FullName", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                targets.Add(new SalesTarget
                {
                    TargetID = reader.GetInt32(reader.GetOrdinal("TargetID")),
                    UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                    TargetAmount = reader.GetDecimal(reader.GetOrdinal("TargetAmount")),
                    StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                    EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                    IsAchieved = reader.GetBoolean(reader.GetOrdinal("IsAchieved")),
                    FullName = reader.GetString(reader.GetOrdinal("FullName"))
                });
            }

            return targets;
        }

        public SalesTarget? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT st.TargetID, st.UserID, st.TargetAmount,
                       st.StartDate, st.EndDate, st.IsAchieved,
                       u.FullName
                FROM SalesTargets st
                INNER JOIN Users u ON st.UserID = u.UserID
                WHERE st.TargetID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new SalesTarget
                {
                    TargetID = reader.GetInt32(reader.GetOrdinal("TargetID")),
                    UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                    TargetAmount = reader.GetDecimal(reader.GetOrdinal("TargetAmount")),
                    StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                    EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                    IsAchieved = reader.GetBoolean(reader.GetOrdinal("IsAchieved")),
                    FullName = reader.GetString(reader.GetOrdinal("FullName"))
                };
            }

            return null;
        }

        public bool Insert(SalesTarget salesTargets)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO SalesTargets
                    (UserID, TargetAmount, StartDate, EndDate, IsAchieved)
                VALUES
                    (@UserID, @TargetAmount, @StartDate, @EndDate, @IsAchieved)",
                conn);

            cmd.Parameters.AddWithValue("@UserID", salesTargets.UserID);
            cmd.Parameters.AddWithValue("@TargetAmount", salesTargets.TargetAmount);
            cmd.Parameters.AddWithValue("@StartDate", salesTargets.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", salesTargets.EndDate);
            cmd.Parameters.AddWithValue("@IsAchieved", salesTargets.IsAchieved);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(SalesTarget salesTargets)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE SalesTargets
                SET UserID = @UserID,
                    TargetAmount = @TargetAmount,
                    StartDate = @StartDate,
                    EndDate = @EndDate,
                    IsAchieved = @IsAchieved
                WHERE TargetID = @TargetID", conn);

            cmd.Parameters.AddWithValue("@UserID", salesTargets.UserID);
            cmd.Parameters.AddWithValue("@TargetAmount", salesTargets.TargetAmount);
            cmd.Parameters.AddWithValue("@StartDate", salesTargets.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", salesTargets.EndDate);
            cmd.Parameters.AddWithValue("@IsAchieved", salesTargets.IsAchieved);
            cmd.Parameters.AddWithValue("@TargetID", salesTargets.TargetID);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "DELETE FROM SalesTargets WHERE TargetID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}

