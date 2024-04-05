using System;
using System.Data;
using NatyBeautyModel;
using NatyBeautyDAL;

namespace NatyBeautyController
{
    public static class UsersController
    {
        /// <summary>
        /// Validate Login on Database.
        /// </summary>
        /// <param name="login">User login to be validated on the DB.</param>
        /// <param name="password">User password to be validated on the DB.</param>
        /// <returns>Returns True (validation success) or False (validation error).</returns>
        public static bool ValidateLogin(string login, string password)
        {
            return UsersServices.ValidateCredentials(login, password);            
        }

        /// <summary>
        /// Create a new user on the DB.
        /// </summary>
        /// <param name="name">New user's name.</param>
        /// <param name="login">New user's login.</param>
        /// <param name="password">New user's password.</param>
        /// <param name="admin">New user's admin flag.</param>
        /// <returns>Returns True (Creation success) or False (Creation error).</returns>
        public static bool CreateUsers(string name, string login, string password, bool admin ) 
        {
            Users user = new Users()
            {
                Name = name,
                Login = login,
                Password = password,
                Admin = admin
            };
            
            return UsersServices.CreateUsers(user);
        }

        /// <summary>
        /// Get all users from Database.
        /// </summary>
        /// <returns>DataTable with all the users from Users Table.</returns>
        public static DataTable GetAllUsers()
        {
            return UsersServices.GetAllUsers();
        }

        /// <summary>
        /// Update an user in the Users Table.
        /// </summary>
        /// <param name="id">User's id to be updated.</param>
        /// <param name="name">User's name to be updated.</param>
        /// <param name="login">User's login to be updated.</param>
        /// <param name="password">User's password to be updated.</param>
        /// <param name="admin">User's admin to be updated.</param>
        /// <returns>Returns if the user have been updated or not, true or false.</returns>
        public static bool UpdateUser(int id, string name, string login, string password, bool admin)
        {
            Users user = new Users()
            {
                Name = name,
                Login = login,
                Password = password,
                Admin = admin, 
                ID = id
            };

            return UsersServices.UpdateUser(user);
        }

        /// <summary>
        /// Delete an user in the Users Table.
        /// </summary>
        /// <param name="id">User's id to be deleted.</param>
        /// <returns>Returns if the user have been deleted or not, true or false.</returns>
        public static bool DeleteUser(int id)
        {
            Users user = new Users()
            {
                ID = id
            };

            return UsersServices.DeleteUser(user);
        }

        /// <summary>
        /// Decrypt the password to be updated into the display.
        /// </summary>
        /// <param name="password">Password to be decrypted (must be cypher string).</param>
        /// <returns>Plain text password.</returns>
        public static string DecryptPass(string password)
        {
            try 
            {
                return EncryptionHelper.Decrypt(password);
            }
            catch (Exception ex)
            {
                LoggerUtil.LogException(ex, "NatyBeautyController::UsersController::DecryptPass - " + ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Validate if logged user is an administrator.
        /// </summary>
        /// <returns>True or false based on if the logged user is an administrator or not.</returns>
        public static bool ValidateCurrentUserIsAdmin()
        {
            return LoggedUser.CurrentUser.Admin;
        }

        /// <summary>
        /// Logout current User.
        /// </summary>
        public static void LogoutUser()
        {
            LoggedUser.CurrentUser = null;
        }
    }
}
