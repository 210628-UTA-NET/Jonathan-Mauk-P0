using System;
using StoreModels;
using StoreAppBL;

namespace StoreUI
{
    class CustomerSearchMenu : IMenu
    {
        public void Menu()
        {
            System.Console.WriteLine("==== Customer Search Menu ====");
            System.Console.WriteLine("Please enter the Customer's name.");
            System.Console.WriteLine("Or enter '0' to return to Main Menu.");
        }

        public MenuOptions YourChoice()
        {
            string info = Console.ReadLine();
            MenuOptions val;
            if (info == "0")
            {
                val = MenuOptions.MainMenu;
            }
            else
            {
                Customer found = CustomerBL.SearchCustomer(info);
                val = MenuOptions.SearchCustomer;
                if(found == null){
                    System.Console.WriteLine("The Customer you are looking for could not be found.");
                    System.Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else
                {
                    System.Console.WriteLine("==============================");
                    System.Console.WriteLine($"Name: {found.Name}");
                    System.Console.WriteLine($"Address: {found.Address}");
                    System.Console.WriteLine($"Email: {found.Email}");
                    System.Console.WriteLine($"Phone Number: {found.PhoneNumber}");
                    System.Console.WriteLine("==============================");
                    System.Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
            }
            return val;
        }
    }
}