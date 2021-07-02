using System;
using StoreModels;
using StoreUI;
using System.Collections.Generic;

namespace P0
{
    class StoreApp
    {
        static void Main(string[] args)
        {
            IMenu menu = new MainMenu();
            List<string> customers = new List<string>();
            bool stay = true;
            MenuOptions choice = MenuOptions.MainMenu;
            while (stay) {
                Console.Clear();
                menu.Menu();
                choice = menu.YourChoice();
                switch (choice)
                {
                    case MenuOptions.Exit:
                        stay = false;
                        break;
                    case MenuOptions.ListCustomerMenu:
                        menu = new ListCustomerMenu();
                        break;
                    case MenuOptions.AddCustomerMenu:
                        menu = new AddCustomerMenu();
                        break;
                    case MenuOptions.MainMenu:
                        menu = new MainMenu();
                        break;
                    case MenuOptions.SearchCustomer:
                        menu = new CustomerSearchMenu();
                        break;
                    case MenuOptions.ViewStoreInv:
                        menu = new ViewStoreInvMenu();
                        break;
                    case MenuOptions.ViewOrderHistory:
                        menu = new ViewOrderMenu();
                        break;
                    default:
                        Console.WriteLine("Could not understand input.");
                        break;
                }

            } 
        }
    }
}
