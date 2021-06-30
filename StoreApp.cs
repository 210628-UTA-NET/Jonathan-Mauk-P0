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
            AddCustomerMenu addCustomerMenu;
            List<string> customers = new List<string>();
            bool stay = true;
            MenuOptions choice = MenuOptions.MainMenu;
            while (stay) {
                menu.Menu();
                choice = menu.YourChoice();
                switch (choice)
                {
                    case MenuOptions.Exit:
                        stay = false;
                        break;
                    case MenuOptions.ListCustomerMenu:
                        menu = new ListCustomerMenu(customers);
                        break;
                    case MenuOptions.AddCustomerMenu:
                        menu = new AddCustomerMenu();
                        break;
                    case MenuOptions.MainMenu:
                        menu = new MainMenu();
                        break;
                    case MenuOptions.AddCustomer:
                        addCustomerMenu = menu as AddCustomerMenu;
                        Customer customer = new Customer();
                        customer.Name = addCustomerMenu.Name;
                        customer.Address = addCustomerMenu.Address;
                        customer.Email = addCustomerMenu.Email;
                        customer.PhoneNumber = addCustomerMenu.PhoneNumber;
                        customers.Add(customer.ToString());
                        Console.WriteLine("Customer has been added");
                        menu = new MainMenu();
                        break;
                        
                    default:
                        Console.WriteLine("Could not understand input.");
                        break;
                }

            } 
        }
    }
}
