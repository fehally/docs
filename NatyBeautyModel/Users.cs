using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using NatyBeautyDAL;

namespace NatyBeautyModel
{
    public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
    }

    public class UsersServices
    {
        /// <summary>
        /// Validate users Credentials.
        /// </summary>
        /// <param name="login">User login to be verified on DB.</param>
        /// <param name="password">User password to be verified on DB.</param>
        /// <returns>Returns the result of the validation, true or false.</returns>
        public static bool ValidateCredentials(string login, string password)
        {
            try
            {
                string commandString = "SELECT * FROM Users WHERE login = @login AND password = @password";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@login", SqlDbType.VarChar) { Value = login },
                    new SqlParameter("@password", SqlDbType.VarChar) { Value = NatyBeautyDAL.EncryptionHelper.Encrypt(password) }
                };

                DataTable dt = ConnectionDB.ExecuteSelectCommand(commandString, parameters);

                if (dt != null)
                {
                    LoggedUser.CurrentUser = Utils.ObjectsGenerator.CreateObject<Users>(dt.Rows[0]);
                    return dt.Rows.Count > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                LoggerUtil.LogException(ex, "NatyBeautyModel::UsersServices::ValidateCredentials - " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Create new users in the Users Table.
        /// </summary>
        /// <param name="user">User object to be verified and then created on DB.</param>
        /// <returns>Returns if the user have been created or not, true or false.</returns>
        public static bool CreateUsers(Users user)
        {
            try
            {
                bool usersExist = ValidateCredentials(user.Login, user.Password);

                if (usersExist)
                    return false;

                string commandString = "INSERT INTO Users (Name, Login, Password, Admin) VALUES (@Name, @Login, @Password, @Admin)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", SqlDbType.VarChar) { Value = user.Name },
                    new SqlParameter("@Login", SqlDbType.VarChar) { Value = user.Login },
                    new SqlParameter("@Password", SqlDbType.VarChar) { Value = NatyBeautyDAL.EncryptionHelper.Encrypt(user.Password) },
                    new SqlParameter("@Admin", SqlDbType.Bit) { Value = user.Admin }
                };

                bool userCreated = ConnectionDB.ExecuteInsertOrDeleteOrUpdateCommand(commandString, parameters);

                return userCreated;
            }
            catch (Exception ex)
            {
                LoggerUtil.LogException(ex, "NatyBeautyModel::UsersServices::CreateCredentials - " + ex.Message);
                return false;

            }
        }

        /// <summary>
        /// Get all users from Users Table.
        /// </summary>
        /// <returns>DataTable with all the users from Users Table.</returns>
        public static DataTable GetAllUsers()
        {
            try
            {
                string commandString = "select * from Users";

                DataTable dt = ConnectionDB.ExecuteSelectCommand(commandString, new SqlParameter[0]);

                return dt;
            }
            catch (Exception ex)
            {
                LoggerUtil.LogException(ex, "NatyBeautyModel::UsersServices::GetAllUsers - " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Update an user in the Users Table.
        /// </summary>
        /// <param name="user">User information to be updated on DB.</param>
        /// <returns>Returns if the user have been updated or not, true or false.</returns>
        public static bool UpdateUser(Users user)
        {
            try
            {
                string commandString = "UPDATE Users SET Name = @Name, Login = @Login, Password = @Password, Admin = @Admin WHERE ID = @ID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", SqlDbType.VarChar) { Value = user.Name },
                    new SqlParameter("@Login", SqlDbType.VarChar) { Value = user.Login },
                    new SqlParameter("@Password", SqlDbType.VarChar) { Value = NatyBeautyDAL.EncryptionHelper.Encrypt(user.Password) },
                    new SqlParameter("@Admin", SqlDbType.Bit) { Value = user.Admin },
                    new SqlParameter("@ID", SqlDbType.Int) { Value = user.ID }
                };

                bool userUpdated = ConnectionDB.ExecuteInsertOrDeleteOrUpdateCommand(commandString, parameters);
                
                return userUpdated;
            }
            catch(Exception ex)
            {
                LoggerUtil.LogException(ex, "NatyBeautyModel::UsersServices::UpdateUser - " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Delete an user in the Users Table.
        /// </summary>
        /// <param name="user">User to be deleted from the DB.</param>
        /// <returns>Returns if the user have been deleted or not, true or false.</returns>
        public static bool DeleteUser(Users user)
        {
            try
            {
                string commandString = "DELETE FROM Users WHERE ID = @ID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", SqlDbType.Int) { Value = user.ID }
                };

                bool userDeleted = ConnectionDB.ExecuteInsertOrDeleteOrUpdateCommand(commandString, parameters);

                return userDeleted;
            }
            catch (Exception ex)
            {
                LoggerUtil.LogException(ex, "NatyBeautyModel::UsersServices::DeleteUser - " + ex.Message);
                return false;
            }
        }
    }

    public static class LoggedUser
    {
        public static Users CurrentUser { get; set; }
    }
}
