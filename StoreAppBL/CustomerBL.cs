using System;
using StoreModels;
using StoreAppData;
using System.Collections.Generic;

namespace StoreAppBL
{
    public class CustomerBL
    {
        public static bool AddCustomer(string name, string address, string email, string phone)
        {
            Customer custo = new Customer(name, address, email, phone);
            return CustomerDL.AddCustomer(custo);
        }

        public static Customer SearchCustomer(string name)
        {
            // foreach (Customer item in CustomerData.CustomerList())
            // {
            //     if (item.Name == name)
            //     {
            //         return item;
            //     }
            // }
            return CustomerDL.FindCustomer(name);
        }

        public static List<Customer> ListCustomers()
        {
            return CustomerDL.RetrieveCustomers();
        }
    }
}
