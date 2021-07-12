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
            return CustomerDL._customerDL.AddCustomer(custo);
        }

        public static Customer SearchCustomer(string name)
        {
            return CustomerDL._customerDL.FindCustomer(name);
        }

        public static Customer SearchCustomer(int id)
        {
            return CustomerDL._customerDL.FindCustomer(id);
        }

        public static List<Customer> ListCustomers()
        {
            return CustomerDL._customerDL.RetrieveCustomers();
        }
    }
}
