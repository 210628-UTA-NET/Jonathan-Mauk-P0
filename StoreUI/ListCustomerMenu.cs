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
            Console.WriteLine("Here is a list of the Customers.");
            foreach (Customer item in CustomerBL.ListCustomers())
            {
                Console.WriteLine(item.ToString());
            }
        }

        public MenuOptions YourChoice()
        {
            Console.WriteLine("Press Enter to return to the main menu");
            Console.ReadLine();
            return MenuOptions.MainMenu;
        }
    }
}