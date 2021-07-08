using System;
using StoreModels;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace StoreAppData
{
    // Consider changing to Singleton instead of making every function static
    public class CustomerDL : ICustomerDL
    {
        private const string _customerFilePath = "../StoreAppData/StoredData/Customers.json";
        // Singleton for CustomerDL
        public static CustomerDL _customerDL = new CustomerDL(new Entities.JMStoreAppContext(DatabaseConnection.GetDatabaseOptions()));
        private Entities.JMStoreAppContext _context;

        public CustomerDL(Entities.JMStoreAppContext p_context)
        {
            _context = p_context;
        }
        public bool AddCustomer(StoreModels.Customer item)
        {
            bool val = false;
            try
            {
                /*string customersFile = File.ReadAllText(_customerFilePath);
                List<StoreModels.Customer> customers = JsonSerializer.Deserialize<List<StoreModels.Customer>>(customersFile);
                customers.Add(item);
                JsonSerializer.Serialize<List<StoreModels.Customer>>(customers);
                string text = JsonSerializer.Serialize(customers, new JsonSerializerOptions(){WriteIndented = true});
                File.WriteAllText(_customerFilePath, text);
                val = true;*/
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

        public List<StoreModels.Customer> RetrieveCustomers()
        {
            //Method Syntax way
            return _context.Customers.Select(
                rest => 
                    new Customer()
                    {
                        CustomerId = rest.CustomerId,
                        Name = rest.CustomerName,
                        Address = rest.CustomerAddress,
                        Email = rest.Email,
                        PhoneNumber = rest.PhoneNumber
                    }
            ).ToList();
        }
    }
}