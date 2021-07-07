using System;
using StoreModels;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using StoreAppData.Entities;

namespace StoreAppData
{
    // Consider changing to Singleton instead of making every function static
    public class CustomerDL : ICustomerDL
    {
        private const string _customerFilePath = "../StoreAppData/StoredData/Customers.json";
        // Singleton for CustomerDL
        public static CustomerDL _customerDL = new CustomerDL();
        private Entities.JMStoreAppContext _context;
        public bool AddCustomer(StoreModels.Customer item)
        {
            bool val = false;
            try
            {
                string customersFile = File.ReadAllText(_customerFilePath);
                List<StoreModels.Customer> customers = JsonSerializer.Deserialize<List<StoreModels.Customer>>(customersFile);
                customers.Add(item);
                JsonSerializer.Serialize<List<StoreModels.Customer>>(customers);
                string text = JsonSerializer.Serialize(customers, new JsonSerializerOptions(){WriteIndented = true});
                File.WriteAllText(_customerFilePath, text);
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
                string customersFile = File.ReadAllText(_customerFilePath);
                List<StoreModels.Customer> customers = JsonSerializer.Deserialize<List<StoreModels.Customer>>(customersFile);
                foreach (StoreModels.Customer item in customers)
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
            try
            {
                string customersFile = File.ReadAllText(_customerFilePath);
                return JsonSerializer.Deserialize<List<StoreModels.Customer>>(customersFile);
            }
            catch (System.Exception)
            {
                return new List<StoreModels.Customer>();
            }
        }
    }
}