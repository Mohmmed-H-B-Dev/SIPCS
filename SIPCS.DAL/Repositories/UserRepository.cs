using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public List<User> GetAll()
        {
            var users = new List<User>();
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT u.UserID, u.Username, u.FullName, u.RoleID,
                       u.IsActive, u.CreatedDate, r.RoleName
                FROM Users u
                INNER JOIN Roles r ON u.RoleID = r.RoleID
                ORDER BY u.FullName", conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User
                {
                    UserID      = reader.GetInt32(reader.GetOrdinal("UserID")),
                    Username    = reader.GetString(reader.GetOrdinal("Username")),
                    FullName    = reader.GetString(reader.GetOrdinal("FullName")),
                    RoleID      = reader.GetInt32(reader.GetOrdinal("RoleID")),
                    IsActive    = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                    CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")  ),
                    RoleName    = reader.GetString(reader.GetOrdinal("RoleName"))
                });
            }
            return users;
        }

        public User? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            var cmd = new SqlCommand(
                "SELECT u.*, r.RoleName FROM Users u INNER JOIN Roles r ON u.RoleID = r.RoleID WHERE u.UserID = @ID",
                conn);
            cmd.Parameters.AddWithValue("@ID", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    UserID      = reader.GetInt32(0),
                    Username    = reader.GetString(1),
                    PasswordHash = reader.GetString(2),
                    FullName    = reader.GetString(3),
                    RoleID      = reader.GetInt32(4),
                    IsActive    = reader.GetBoolean(5),
                    CreatedDate = reader.GetDateTime(6),
                    RoleName    = reader.GetString(7)
                };
            }
            return null;
        }

        /// <summary>
        /// تسجيل الدخول - يرجع المستخدم إن وُجد وإلا null
        /// </summary>
        public User? Login(string username, string passwordHash)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            var cmd = new SqlCommand(@"
                SELECT u.UserID, u.Username, u.FullName, u.RoleID,
                       u.IsActive, u.CreatedDate, r.RoleName
                FROM Users u
                INNER JOIN Roles r ON u.RoleID = r.RoleID
                WHERE u.Username = @Username
                  AND u.PasswordHash = @PasswordHash
                  AND u.IsActive = 1", conn);

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    UserID   = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    FullName = reader.GetString(2),
                    RoleID   = reader.GetInt32(3),
                    IsActive = reader.GetBoolean(4),
                    CreatedDate = reader.GetDateTime(5),
                    RoleName = reader.GetString(6)
                };
            }
            return null;
        }

        public bool Insert(User user)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            var cmd = new SqlCommand(@"
                INSERT INTO Users (Username, PasswordHash, FullName, RoleID, IsActive, CreatedDate)
                VALUES (@Username, @PasswordHash, @FullName, @RoleID, @IsActive, @CreatedDate)",
                conn);
            cmd.Parameters.AddWithValue("@Username",     user.Username);
            cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@FullName",     user.FullName);
            cmd.Parameters.AddWithValue("@RoleID",       user.RoleID);
            cmd.Parameters.AddWithValue("@IsActive",     user.IsActive);
            cmd.Parameters.AddWithValue("@CreatedDate",  user.CreatedDate);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(User user)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            var cmd = new SqlCommand(@"
                UPDATE Users
                SET FullName = @FullName, RoleID = @RoleID, IsActive = @IsActive
                WHERE UserID = @UserID", conn);
            cmd.Parameters.AddWithValue("@FullName", user.FullName);
            cmd.Parameters.AddWithValue("@RoleID",   user.RoleID);
            cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
            cmd.Parameters.AddWithValue("@UserID",   user.UserID);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            var cmd = new SqlCommand("UPDATE Users SET IsActive = 0 WHERE UserID = @ID", conn);
            cmd.Parameters.AddWithValue("@ID", id);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
