using System;
using StoreModels;
using System.Collections.Generic;

namespace StoreAppData
{
    public abstract class Repository
    {
        protected Entities.JMStoreAppContext _context;
        public Repository(Entities.JMStoreAppContext p_context) {  }
    }

    /// <summary>
    /// Responsible for accessing the Customer table of the database
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

    public interface IStoreFrontDL
    {
        /// <summary>
        /// Finds a store based upon the name given
        /// </summary>
        /// <param name="name">The name of the store to be found</param>
        /// <returns>The Store object that is being searched for</returns>
        StoreFront FindStore(string name);
        /// <summary>
        /// Finds a store based upon the id given
        /// </summary>
        /// <param name="id">The id of the store to be found</param>
        /// <returns>The Store object that is being searched for</returns>
        StoreFront FindStore(int id);

        /// <summary>
        /// Retrieves a List of all stores.
        /// </summary>
        /// <returns>A list containing all of the storefronts</returns>
        List<StoreFront> RetrieveStoreFronts();
    }

    public interface IProductDL
    {
        /// <summary>
        /// Finds a Product based upon the id given
        /// </summary>
        /// <param name="id">The product id</param>
        /// <returns>The product that matches the id given</returns>
        Products FindProduct(int id);

        /// <summary>
        /// Retrieves a list of all products stored on the database
        /// </summary>
        /// <returns>List containing all products stored on the database</returns>
        List<Products> RetrieveProducts();
    }

    public interface ILineItemDL
    {
        /// <summary>
        /// Finds a LineItem based upon the id given
        /// </summary>
        /// <param name="id">The LineItem id</param>
        /// <returns>The LineItem that matches the id given</returns>
        LineItems FindLineItem(int id);

        /// <summary>
        /// Finds all LineItems belonging to a specified foreign key
        /// </summary>
        /// <param name="fkid">The id number of the foreign key</param>
        /// <returns></returns>
        List<LineItems> RetrieveLineItems(int fkid);
    }
}
