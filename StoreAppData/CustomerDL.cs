using System;
using StoreModels;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace StoreAppData
{
    // Consider changing to Singleton instead of making every function static
    public class CustomerDL : Repository, ICustomerDL
    {
        private const string _customerFilePath = "../StoreAppData/StoredData/Customers.json";
        // Singleton for CustomerDL
        public static CustomerDL _customerDL = new CustomerDL(new Entities.JMStoreAppContext(DatabaseConnection.GetDatabaseOptions()));

        public CustomerDL(Entities.JMStoreAppContext p_context) : base(p_context)
        {
            _context = p_context;
        }
        public bool AddCustomer(StoreModels.Customer item)
        {
            bool val = false;
            try
            {
                _context.Customers.Add(
                    new Entities.Customer()
                    {
                        CustomerName = item.Name,
                        CustomerAddress = item.Address,
                        Email = item.Email,
                        PhoneNumber = item.PhoneNumber 
                    }
                );
                _context.SaveChanges();
                val = true;

            }
            catch (System.Exception)
            {
                val = false;
            }
            return val;
        }

        public static Customer EntityToModel(Entities.Customer eCustomer)
        {
            return new Customer()
            {
                CustomerId = eCustomer.CustomerId,
                Name = eCustomer.CustomerName,
                Address = eCustomer.CustomerAddress,
                Email = eCustomer.Email,
                PhoneNumber = eCustomer.PhoneNumber,
                Orders = OrderDL._orderDL.FindOrdersByCustomer(eCustomer.CustomerId)
            };
        }

        public StoreModels.Customer FindCustomer(string name)
        {
            try
            {
                foreach (StoreModels.Customer item in RetrieveCustomers())
                {
                    if (item.Name == name)
                    {
                        return item;
                    }
                }
                return null;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public StoreModels.Customer FindCustomer(int id)
        {
            return EntityToModel(_context.Customers.Find(id));
        }

        public List<StoreModels.Customer> RetrieveCustomers()
        {
            return _context.Customers.Select(
                rest => EntityToModel(rest)
            ).ToList();
        }
    }
}