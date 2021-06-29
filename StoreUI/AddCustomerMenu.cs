using System;

namespace StoreUI
{
    class AddCustomerMenu : IMenu
    {
        public AddCustomerMenu()
        {
            
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void Menu()
        {
            Console.WriteLine("====Add Customer Menu====");
            Console.WriteLine("Welcome! Please enter the customer's information");
        }

        public string YourChoice()
        {
            string info = "";
            Console.WriteLine("Enter the customer's name or enter 0 to return to the main menu.");
            info += Console.ReadLine(); 
            if (info == "0") {
                info = "MainMenu";
                return info;
            }
            Name = info;
            info = "AddCustomer";
            Console.WriteLine("Enter the customer's address.");
            Address = Console.ReadLine(); 
            Console.WriteLine("Enter the customer's email.");
            Email = Console.ReadLine(); 
            Console.WriteLine("Enter the customer's phone number.");
            PhoneNumber = Console.ReadLine(); 
            return info;
        }
    }
}