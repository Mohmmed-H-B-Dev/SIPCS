using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class RolesRepository : IRepository<Role>
    {
        public List<Role> GetAll()
        {
            var roles = new List<Role>();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

             using var cmd = new SqlCommand(@"
                SELECT RoleID, RoleName, Description
                FROM Roles
                ORDER BY RoleName", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                roles.Add(new Role
                {
                    RoleID = reader.GetInt32(reader.GetOrdinal("RoleID")),
                    RoleName = reader.GetString(reader.GetOrdinal("RoleName")),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("Description"))
                });
            }

            return roles;
        }

        public Role? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand(@"
                SELECT RoleID, RoleName, Description
                FROM Roles
                WHERE RoleID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Role
                {
                    RoleID = reader.GetInt32(reader.GetOrdinal("RoleID")),
                    RoleName = reader.GetString(reader.GetOrdinal("RoleName")),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("Description"))
                };
            }

            return null;
        }

        public bool Insert(Role roles)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

           using  var cmd = new SqlCommand(@"
                INSERT INTO Roles (RoleName, Description)
                VALUES (@RoleName, @Description)", conn);

            cmd.Parameters.AddWithValue("@RoleName", roles.RoleName);
            cmd.Parameters.AddWithValue("@Description",
                (object?)roles.Description ?? DBNull.Value);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Role roles)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

           using  var cmd = new SqlCommand(@"
                UPDATE Roles
                SET RoleName = @RoleName,
                    Description = @Description
                WHERE RoleID = @RoleID", conn);

            cmd.Parameters.AddWithValue("@RoleName", roles.RoleName);
            cmd.Parameters.AddWithValue("@Description",
                (object?)roles.Description ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoleID", roles.RoleID);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

           using  var cmd = new SqlCommand(
                "DELETE FROM Roles WHERE RoleID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
