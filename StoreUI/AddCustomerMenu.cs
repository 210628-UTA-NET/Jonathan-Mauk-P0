using System;
using StoreAppBL;

namespace StoreUI
{
    class AddCustomerMenu : IMenu
    {
        public AddCustomerMenu()
        {
            
        }
        public void Menu()
        {
            Console.WriteLine("====Add Customer Menu====");
            Console.WriteLine("Welcome! Please enter the customer's information");
        }

        public MenuOptions YourChoice()
        {
            string info = "";
            Console.WriteLine("Enter the customer's name or enter 0 to return to the main menu.");
            info += Console.ReadLine(); 
            if (info == "0") {
                return MenuOptions.MainMenu;
            }
            string name = info;
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
                System.Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                System.Console.WriteLine("The Customer could not be added.");
                System.Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            System.Console.WriteLine("Press Enter to return to Main Menu.");
            Console.ReadLine();
            
            return MenuOptions.MainMenu;
        }
    }
}