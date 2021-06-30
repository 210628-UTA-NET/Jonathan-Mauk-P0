using System;
using StoreModels;
using System.Collections.Generic;

namespace StoreAppData
{
    /// <summary>
    /// Responsible for accessing the database
    /// </summary>
    public interface ICustomerDL
    {
        /// <summary>
        /// Finds a Customer from the database 
        /// </summary>
        /// <returns>The Customer being searched for</returns>
        Customer FindCustomer(string name);

        /// <summary>
        /// Retrieves all Customers from the database
        /// </summary>
        /// <returns>A list of all Customers in the database</returns>
        List<Customer> RetrieveCustomers();

        /// <summary>
        /// Add a Customer to the database
        /// </summary>
        /// <param name="item">The Customer to be added to the database</param>
        /// <returns>True if the Customer was successfully added</returns>
        bool AddCustomer(Customer item);
    }
}
