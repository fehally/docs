using System;
using System.Data;
using System.Data.SqlClient;

namespace NatyBeautyDAL
{
    public static class ConnectionDB
    {
        /// <summary>
        /// Method to get the configuration and format the connection string
        /// </summary>
        /// <returns>Database connection string</returns>
        private static string GetConnectionString()
        {
            try
            {
                string DBName = EncryptionHelper.Decrypt(DBSettings.Default.DBName);
                string DBUser = EncryptionHelper.Decrypt(DBSettings.Default.DBUser);
                string DBPass = EncryptionHelper.Decrypt(DBSettings.Default.DBPassword);
                string DBServer = EncryptionHelper.Decrypt(DBSettings.Default.DBServer);

                string connstring = string.Format("user id={0};" +
                                       @"password={1};server={2};" +
                                       "Trusted_Connection=no;" +
                                       "database={3}; " +
                                       "connection timeout=30; TrustServerCertificate=True", DBUser, DBPass, DBServer, DBName);

                return connstring;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to execute a generic Select Command
        /// </summary>
        /// <param name="commandString">Command string to be executed in the database. I.e: "select * from tableName where id = @id"</param>
        /// <param name="parameters">SqlParameters to be added into the command string.</param>
        /// <returns>Returns a DataTable variable that contains the result of a select command.</returns>
        public static DataTable ExecuteSelectCommand(string commandString, SqlParameter[] parameters)
        {
            try
            {
                if (string.IsNullOrEmpty(commandString))
                    return null;

                using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand myCommand = new SqlCommand(commandString, sqlConnection))
                    {
                        myCommand.Parameters.AddRange(parameters);
                        sqlConnection.Open();

                        using (SqlDataReader reader = myCommand.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw; 
            }
        }

        /// <summary>
        /// Method to execute a generic Insert or Delete Command
        /// </summary>
        /// <param name="commandString">Command string to be executed in the database. I.e: "delete from tableName where id = @id"</param>
        /// <param name="parameters">SqlParameters to be added into the command string.</param>
        /// <returns>Returns a boolean variable that indicates if the command was executed succesfully or not.</returns>
        public static bool ExecuteInsertOrDeleteOrUpdateCommand(string commandString, SqlParameter[] parameters)
        {
            try
            {
                if (string.IsNullOrEmpty(commandString))
                    return false;

                using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand myCommand = new SqlCommand(commandString, sqlConnection))
                    {
                        myCommand.Parameters.AddRange(parameters);
                        sqlConnection.Open();
                        myCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to execute an Image Insert
        /// </summary>
        /// <param name="commandString">Insert command string to be executed in the database.</param>
        /// <param name="parameters">SqlParameters to be added into the command string.</param>
        /// <returns>Returns a boolean variable that indicates if the command was executed succesfully or not.</returns>
        public static bool ExecuteImageInsert(string commandString, SqlParameter[] parameters)
        {
            try
            {
                if (string.IsNullOrEmpty(commandString))
                    return false;

                using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand myCommand = new SqlCommand(commandString, sqlConnection))
                    {
                        myCommand.Parameters.AddRange(parameters);
                        sqlConnection.Open();
                        myCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
