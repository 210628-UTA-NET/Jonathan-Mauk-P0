using System;
using StoreModels;
using StoreAppData;

namespace StoreAppBL
{
    public class CustomerBL
    {
        public static void AddCustomer(string name, string address, string email, string phone)
        {
            Customer custo = new Customer(name, address, email, phone);
            //CustomerData.AddCustomer(custo);
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
            // return null;
            throw new NotImplementedException("Customer Search is not Implemented");
        }
    }
}
