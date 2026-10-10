using System.Security.Cryptography;
using System.Text;
using SIPCS.Common.Models;
using SIPCS.DAL.Repositories;

namespace SIPCS.BLL.Services.UserModule
{
    /// <summary>
    /// منطق العمل الخاص بالمستخدمين والصلاحيات
    /// </summary>
    public class UserService
    {
        private readonly UserRepository _repo = new();

        // المستخدم الحالي المسجل دخوله
        public static User? CurrentUser { get; private set; }

        /// <summary>
        /// تسجيل الدخول - يرجع true إن نجح
        /// </summary>
        public bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            string hashedPassword = HashPassword(password);
            var user = _repo.Login(username, hashedPassword);

            if (user != null)
            {
                CurrentUser = user;
                return true;
            }
            return false;
        }

        public void Logout() => CurrentUser = null;

        public List<User> GetAllUsers() => _repo.GetAll();

        public bool AddUser(User user, string plainPassword)
        {
            user.PasswordHash = HashPassword(plainPassword);
            return _repo.Insert(user);
        }

        public bool UpdateUser(User user) => _repo.Update(user);

        /// <summary>
        /// تشفير كلمة المرور بخوارزمية SHA256
        /// </summary>
        private static string HashPassword(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes);
        }

        /// <summary>
        /// هل المستخدم الحالي مدير؟
        /// </summary>
        public static bool IsAdmin() =>
            CurrentUser?.RoleName?.ToLower() == "مدير" ||
            CurrentUser?.RoleName?.ToLower() == "admin";
    }
}
