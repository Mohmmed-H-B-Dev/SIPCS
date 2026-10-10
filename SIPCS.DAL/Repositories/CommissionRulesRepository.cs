using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.Common.Enums;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class CommissionRulesRepository : IRepository<CommissionRule>
    {
        public List<CommissionRule> GetAll()
        {
            var rules = new List<CommissionRule>();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT cr.RuleID, cr.RoleID, cr.TargetType,
                       cr.CommissionValue, cr.MinimumTargetAmount,
                       cr.TargetPeriod, cr.CommissionType,
                       r.RoleName
                FROM CommissionRules cr
                INNER JOIN Roles r ON cr.RoleID = r.RoleID
                ORDER BY r.RoleName", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                rules.Add(new CommissionRule
                {
                    RuleID = reader.GetInt32(reader.GetOrdinal("RuleID")),
                    RoleID = reader.GetInt32(reader.GetOrdinal("RoleID")),
                    TargetType = (CommissionTargetType)reader.GetInt32(reader.GetOrdinal("TargetType")),
                    CommissionValue = reader.GetDecimal(reader.GetOrdinal("CommissionValue")),
                    MinimumTargetAmount = reader.GetDecimal(reader.GetOrdinal("MinimumTargetAmount")),
                    TargetPeriod = (TargetPeriodType)reader.GetInt32(reader.GetOrdinal("TargetPeriod")),
                    CommissionType = reader.GetString(reader.GetOrdinal("CommissionType")),
                    RoleName = reader.GetString(reader.GetOrdinal("RoleName"))
                });
            }

            return rules;
        }

        public CommissionRule? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT cr.RuleID, cr.RoleID, cr.TargetType,
                       cr.CommissionValue, cr.MinimumTargetAmount,
                       cr.TargetPeriod, cr.CommissionType,
                       r.RoleName
                FROM CommissionRules cr
                INNER JOIN Roles r ON cr.RoleID = r.RoleID
                WHERE cr.RuleID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new CommissionRule
                {
                    RuleID = reader.GetInt32(reader.GetOrdinal("RuleID")),
                    RoleID = reader.GetInt32(reader.GetOrdinal("RoleID")),
                    TargetType = (CommissionTargetType)reader.GetInt32(reader.GetOrdinal("TargetType")),
                    CommissionValue = reader.GetDecimal(reader.GetOrdinal("CommissionValue")),
                    MinimumTargetAmount = reader.GetDecimal(reader.GetOrdinal("MinimumTargetAmount")),
                    TargetPeriod = (TargetPeriodType)reader.GetInt32(reader.GetOrdinal("TargetPeriod")),
                    CommissionType = reader.GetString(reader.GetOrdinal("CommissionType")),
                    RoleName = reader.GetString(reader.GetOrdinal("RoleName"))
                };
            }

            return null;
        }

        public bool Insert(CommissionRule commissionRules)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO CommissionRules
                    (RoleID, TargetType, CommissionValue,
                     MinimumTargetAmount, TargetPeriod, CommissionType)
                VALUES
                    (@RoleID, @TargetType, @CommissionValue,
                     @MinimumTargetAmount, @TargetPeriod, @CommissionType)",
                conn);

            cmd.Parameters.AddWithValue("@RoleID", commissionRules.RoleID);
            cmd.Parameters.AddWithValue("@TargetType", commissionRules.GetNameCommissionTargetType(commissionRules.TargetType));
            cmd.Parameters.AddWithValue("@CommissionValue", commissionRules.CommissionValue);
            cmd.Parameters.AddWithValue("@MinimumTargetAmount", commissionRules.MinimumTargetAmount);
            cmd.Parameters.AddWithValue("@TargetPeriod", commissionRules.GetNameTargetPeriodType(commissionRules.TargetPeriod));
            cmd.Parameters.AddWithValue("@CommissionType", commissionRules.CommissionType);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(CommissionRule commissionRules)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE CommissionRules
                SET RoleID = @RoleID,
                    TargetType = @TargetType,
                    CommissionValue = @CommissionValue,
                    MinimumTargetAmount = @MinimumTargetAmount,
                    TargetPeriod = @TargetPeriod,
                    CommissionType = @CommissionType
                WHERE RuleID = @RuleID", conn);

            cmd.Parameters.AddWithValue("@RoleID", commissionRules.RoleID);
            cmd.Parameters.AddWithValue("@TargetType", commissionRules.GetNameCommissionTargetType(commissionRules.TargetType));
            cmd.Parameters.AddWithValue("@CommissionValue", commissionRules.CommissionValue);
            cmd.Parameters.AddWithValue("@MinimumTargetAmount", commissionRules.MinimumTargetAmount);
            cmd.Parameters.AddWithValue("@TargetPeriod", commissionRules.GetNameTargetPeriodType(commissionRules.TargetPeriod));
            cmd.Parameters.AddWithValue("@CommissionType", commissionRules.CommissionType);
            cmd.Parameters.AddWithValue("@RuleID", commissionRules.RuleID);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "DELETE FROM CommissionRules WHERE RuleID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
