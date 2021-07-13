using System;
using StoreAppBL;

namespace StoreUI
{
    class AddCustomerMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("====Add Customer Menu====");
            Console.WriteLine("Welcome! Please enter the customer's information");
            Console.WriteLine("[1] Add a customer");
            Console.WriteLine("[0] Return to Customer Options");
        }

        public MenuOptions YourChoice()
        {
            string info = Console.ReadLine();
            switch (info)
            {
                case "0":
                    return MenuOptions.CustomerOptions;
                case "1":
                    AddCustomer();
                    break;
                default:
                    Console.WriteLine("Your input could not be understood.");
                    break;
            }

            System.Console.WriteLine("Press Enter to return to Main Menu.");
            Console.ReadLine();
            
            return MenuOptions.MainMenu;
        }

        private void AddCustomer() 
        {
            Console.WriteLine("Enter the customer's name.");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the customer's address.");
            string address = Console.ReadLine(); 
            Console.WriteLine("Enter the customer's email.");
            string email = Console.ReadLine(); 
            Console.WriteLine("Enter the customer's phone number.");
            string phoneNumber = Console.ReadLine(); 
            
            if (CustomerBL.AddCustomer(name, address, email, phoneNumber))
            {
                System.Console.WriteLine("The Customer was Successfully added!");
            }
            else
            {
                System.Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                System.Console.WriteLine("ERROR: The Customer could not be added.");
                System.Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
        }
    }
}