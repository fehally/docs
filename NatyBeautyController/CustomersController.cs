using NatyBeautyModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatyBeautyController
{
    public static class CustomersController
    {
        /// <summary>
        /// Create a new Customer on the DB.
        /// </summary>
        /// <param name="name">New Customer's name.</param>
        /// <param name="lastName">New Customer's lastName.</param>
        /// <param name="phone1">New Customer's phone1.</param>
        /// <param name="phone2">New Customer's phone2.</param>
        /// <param name="email">New Customer's email.</param>
        /// <param name="birthdate">New Customer's birthdate.</param>
        /// <param name="comments">New Customer's comments.</param>
        /// <returns>Returns True (Creation success) or False (Creation error).</returns>
        public static bool CreateCustomer(string name, string lastName, string phone1, string phone2, string email, DateTime birthdate, string comments)
        {
            Customers customer = new Customers()
            {
                Name = name,
                LastName = lastName,
                Phone1 = phone1,
                Phone2 = phone2,
                Email = email,
                Birthdate = birthdate,
                Comments = comments
            };

            return CustomersServices.CreateCustomer(customer);
        }

        /// <summary>
        /// Get all Customers from Database.
        /// </summary>
        /// <returns>DataTable with all the Customers from Customer Table.</returns>
        public static DataTable GetAllCustomers()
        {
            return CustomersServices.GetAllCustomers();
        }

        /// <summary>
        /// Update a Customer in the Customers Table.
        /// </summary>
        /// <param name="name">Customer's name to be updated.</param>
        /// <param name="lastName">Customer's lastName to be updated.</param>
        /// <param name="phone1">Customer's phone1 to be updated.</param>
        /// <param name="phone2">Customer's phone2 to be updated.</param>
        /// <param name="email">Customer's email to be updated.</param>
        /// <param name="birthdate">Customer's birthdate to be updated.</param>
        /// <param name="comments">Customer's comments to be updated.</param>
        /// <returns>Returns if the Customer have been updated or not, true or false.</returns>
        public static bool UpdateCustomer(int id, string name, string lastName, string phone1, string phone2, string email, DateTime birthdate, string comments)
        {
            Customers customer = new Customers()
            {
                Name = name,
                LastName = lastName,
                Phone1 = phone1,
                Phone2 = phone2,
                Email = email,
                Birthdate = birthdate,
                Comments = comments,
                ID = id
            };

            return CustomersServices.UpdateCustomer(customer);
        }

        /// <summary>
        /// Delete a Customer in the Customers Table.
        /// </summary>
        /// <param name="id">Customer's id to be deleted.</param>
        /// <returns>Returns if the Customer have been deleted or not, true or false.</returns>
        public static bool DeleteCustomer(int id)
        {
            Customers customer = new Customers()
            {
                ID = id
            };

            return CustomersServices.DeleteCustomer(customer);
        }
    }
}
