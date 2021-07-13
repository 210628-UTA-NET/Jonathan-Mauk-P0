using System;
using StoreModels;
using StoreAppBL;

namespace StoreUI
{
    class CustomerSearchMenu : AMenu, IMenu
    {
        public void Menu()
        {
            System.Console.WriteLine("==== Customer Search Menu ====");
            System.Console.WriteLine("[2] Search a customer by Id.");
            System.Console.WriteLine("[1] Search a customer by name.");
            System.Console.WriteLine("[0] Return to Customer Options.");
        }

        public MenuOptions YourChoice()
        {
            string info = Console.ReadLine();
            MenuOptions val;
            switch (info)
            {
                case "0":
                    val = MenuOptions.CustomerOptions;
                    break;
                case "1":
                    val = MenuOptions.SearchCustomer;
                    SearchCustomerByName();
                    break;
                default:
                    Console.WriteLine("Your input could not be understood.");
                    val = MenuOptions.SearchCustomer;
                    EnterToContinue();
                    break;
            }
            return val;
        }

        private void SearchCustomerByName()
        {
            Console.WriteLine("Please enter the customer's name.");
            string name = Console.ReadLine();
            Customer found = CustomerBL.SearchCustomer(name);
            if(found == null){
                System.Console.WriteLine("The Customer you are looking for could not be found.");
                EnterToContinue();
            }
            else
            {
                System.Console.WriteLine("==============================");
                System.Console.WriteLine($"Name: {found.Name}");
                System.Console.WriteLine($"Address: {found.Address}");
                System.Console.WriteLine($"Email: {found.Email}");
                System.Console.WriteLine($"Phone Number: {found.PhoneNumber}");
                System.Console.WriteLine("==============================");
                EnterToContinue();
            }
        }
    }
}