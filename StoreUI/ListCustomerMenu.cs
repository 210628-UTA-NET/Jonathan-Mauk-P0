using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreModels;

namespace StoreUI 
{
    class ListCustomerMenu : AMenu, IMenu
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
            Console.Write("To return to Customer Options ");
            EnterToContinue();
            return MenuOptions.CustomerOptions;
        }
    }
}