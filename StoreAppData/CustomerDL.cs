using System;
using StoreModels;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace StoreAppData
{
    public class CustomerDL// : ICustomerDL
    {
        private const string _customerFilePath = "../StoreAppData/StoredData/Customers.json";
        public static bool AddCustomer(Customer item)
        {
            bool val = false;
            try
            {
                string customersFile = File.ReadAllText(_customerFilePath);
                List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(customersFile);
                customers.Add(item);
                JsonSerializer.Serialize<List<Customer>>(customers);
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

        public static Customer FindCustomer(string name)
        {
            try
            {
                string customersFile = File.ReadAllText(_customerFilePath);
                List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(customersFile);
                foreach (Customer item in customers)
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

        public static List<Customer> RetrieveCustomers()
        {
            try
            {
                string customersFile = File.ReadAllText(_customerFilePath);
                return JsonSerializer.Deserialize<List<Customer>>(customersFile);
            }
            catch (System.Exception)
            {
                return new List<Customer>();
            }
        }
    }
}