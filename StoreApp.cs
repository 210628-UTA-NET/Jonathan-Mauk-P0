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
            string choice = "";
            while (stay) {
                menu.Menu();
                choice = menu.YourChoice();
                switch (choice)
                {
                    case "0":
                        stay = false;
                        break;
                    case "List_Cust_Menu":
                        menu = new ListCustomerUI(customers);
                        break;
                    case "Add_Cust_Menu":
                        menu = new AddCustomerMenu();
                        break;
                    case "MainMenu":
                        menu = new MainMenu();
                        break;
                    case "AddCustomer":
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
