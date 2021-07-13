using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreModels;

namespace StoreUI 
{
    public class ListCustomerMenu : IMenu
    {
        public ListCustomerMenu()
        {
        }

        public void Menu()
        {
            Console.WriteLine("===== Customer List =====");
            foreach (Customer item in CustomerBL.ListCustomers())
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine("============================");
            }
        }

        public MenuOptions YourChoice()
        {
            Console.WriteLine("Press Enter to return to Customer Options");
            Console.ReadLine();
            return MenuOptions.CustomerOptions;
        }
    }
}