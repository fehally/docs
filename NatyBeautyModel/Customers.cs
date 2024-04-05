using NatyBeautyDAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace NatyBeautyModel
{
    public class Customers
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string LastName {  get; set; }
        public string Phone1 {  get; set; }
        public string Phone2 { get; set; }
        public string Email {  get; set; }
        public DateTime Birthdate {  get; set; }
        public string Comments {  get; set; }
    }

    public class CustomersServices
    {
        /// <summary>
        /// Create new customer in the Customers Table.
        /// </summary>
        /// <param name="customer">Customer object to be created on DB.</param>
        /// <returns>Returns if the customer have been created or not, true or false.</returns>
        public static bool CreateCustomer(Customers customer)
        {
            try
            {
                string commandString = "INSERT INTO Customers (Name, LastName, Phone1, Phone2, Email, Birthdate, Comments) VALUES (@Name, @LastName, @Phone1, @Phone2, @Email, @Birthdate, @Comments)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", SqlDbType.VarChar) { Value = customer.Name },
                    new SqlParameter("@LastName", SqlDbType.VarChar) { Value = customer.LastName },
                    new SqlParameter("@Phone1", SqlDbType.VarChar) { Value = customer.Phone1 },
                    new SqlParameter("@Phone2", SqlDbType.VarChar) { Value = customer.Phone2 },
                    new SqlParameter("@Email", SqlDbType.VarChar) { Value = customer.Email },
                    new SqlParameter("@Birthdate", SqlDbType.Date) { Value = customer.Birthdate.Date },
                    new SqlParameter("@Comments", SqlDbType.VarChar) { Value = customer.Comments }
                };

                bool customerCreated = ConnectionDB.ExecuteInsertOrDeleteOrUpdateCommand(commandString, parameters);

                return customerCreated;
            }
            catch (Exception ex)
            {
                LoggerUtil.LogException(ex, "NatyBeautyModel::CustomersServices::CreateCustomer - " + ex.Message);
                return false;

            }
        }

        /// <summary>
        /// Get all customer from Customers Table.
        /// </summary>
        /// <returns>DataTable with all the customers from Customers Table.</returns>
        public static DataTable GetAllCustomers()
        {
            try
            {
                string commandString = "select * from Customers";

                DataTable dt = ConnectionDB.ExecuteSelectCommand(commandString, new SqlParameter[0]);

                return dt;
            }
            catch (Exception ex)
            {
                LoggerUtil.LogException(ex, "NatyBeautyModel::CustomersServices::GetAllCustomers - " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Update a customer in the Customers Table.
        /// </summary>
        /// <param name="customer">Customer information to be updated on DB.</param>
        /// <returns>Returns if the customer have been updated or not, true or false.</returns>
        public static bool UpdateCustomer(Customers customer)
        {
            try
            {
                string commandString = "UPDATE Customers SET Name = @Name, LastName = @LastName, Phone1 = @Phone1, Phone2 = @Phone2, Email = @Email, Birthdate = @Birthdate, Comments = @Comments WHERE ID = @ID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", SqlDbType.VarChar) { Value = customer.Name },
                    new SqlParameter("@LastName", SqlDbType.VarChar) { Value = customer.LastName },
                    new SqlParameter("@Phone1", SqlDbType.VarChar) { Value = customer.Phone1 },
                    new SqlParameter("@Phone2", SqlDbType.VarChar) { Value = customer.Phone2 },
                    new SqlParameter("@Email", SqlDbType.VarChar) { Value = customer.Email },
                    new SqlParameter("@Birthdate", SqlDbType.Date) { Value = customer.Birthdate.Date },
                    new SqlParameter("@Comments", SqlDbType.VarChar) { Value = customer.Comments },
                    new SqlParameter("@ID", SqlDbType.Int) { Value = customer.ID }
                };

                bool customerUpdated = ConnectionDB.ExecuteInsertOrDeleteOrUpdateCommand(commandString, parameters);

                return customerUpdated;
            }
            catch (Exception ex)
            {
                LoggerUtil.LogException(ex, "NatyBeautyModel::CustomersServices::UpdateCustomer - " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Delete a customer in the Customers Table.
        /// </summary>
        /// <param name="customer">Customer to be deleted from the DB.</param>
        /// <returns>Returns if the customer have been deleted or not, true or false.</returns>
        public static bool DeleteCustomer(Customers customer)
        {
            try
            {
                string commandString = "DELETE FROM Customers WHERE ID = @ID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", SqlDbType.Int) { Value = customer.ID }
                };

                bool customerDeleted = ConnectionDB.ExecuteInsertOrDeleteOrUpdateCommand(commandString, parameters);

                return customerDeleted;
            }
            catch (Exception ex)
            {
                LoggerUtil.LogException(ex, "NatyBeautyModel::CustomersServices::DeleteCustomer - " + ex.Message);
                return false;
            }
        }
    }
}
