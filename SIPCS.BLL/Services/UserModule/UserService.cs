using SIPCS.Common.Exceptions;
using SIPCS.Common.Models;
using SIPCS.DAL.Repositories;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SIPCS.BLL.Services.UserModule
{
    /// <summary>
    /// منطق العمل الخاص بالمستخدمين والصلاحيات
    /// </summary>
    public class UserService
    {
        private readonly UserRepository _repo = new();

        public static User? CurrentUser { get; private set; }

        /// <summary>
        /// if the username and password are valid, set CurrentUser to the logged-in user and return true; otherwise, return false.
        /// </summary>
        public bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;
            string hashedPassword = HashPassword(password);

            try
            {


                var user = _repo.Login(username, hashedPassword);

                if (user != null)
                {
                    CurrentUser = user;
                    return true;
                }

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
              throw ExceptionHelper.Convert(ex);
            }
            return false;
        }

        /// <summary>
        /// Logout the current user by setting CurrentUser to null.
        /// </summary>
        public void Logout() => CurrentUser = null;

        public List<User> GetAllUsers() {
            List<User> users = new List<User>();
            try
            {
                if (!IsAdmin())
                    throw new UnauthorizedAccessException("This User Does not have permission.");

                users = _repo.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw ExceptionHelper.Convert(ex);
             

            }
        
            return users;
        }

        public bool AddUser(User user, string plainPassword)
        {
            try
            {
                if (!IsAdmin())
                    throw new UnauthorizedAccessException("You Do not have permission for Add Users.");


                user.PasswordHash = HashPassword(plainPassword);

                 if(_repo.Insert(user))
                     return true;

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw ExceptionHelper.Convert(ex);

            }
               return false;
        }

        public bool UpdateUser(User user) {_repo.Update(user);
            try
            {
                if (!IsAdmin())
                    throw new UnauthorizedAccessException("You Do not have permission for Update Users.");

                if(_repo.Update(user))
                    return true;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw ExceptionHelper.Convert(ex);
            }
            return false;
        }

        /// <summary>
        ///  this Method do Hash password  by SHA256.
        /// </summary>
        private static string HashPassword(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes);
        }

        /// <summary>
        /// Is the current user an admin?
        /// </summary>
        public static bool IsAdmin() =>
            CurrentUser?.RoleName?.ToLower() == "مدير" ||
            CurrentUser?.RoleName?.ToLower() == "admin";
    }
}
