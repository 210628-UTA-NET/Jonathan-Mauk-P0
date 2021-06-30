using System;

namespace StoreUI
{
    class MainMenu : IMenu
    {
        public MainMenu()
        {
            
        }

        public void Menu()
        {
            Console.WriteLine("====Main Menu====");
            Console.WriteLine("Welcome! Please make a selection");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("[1] List Customers");
            Console.WriteLine("[2] Add Customer");
            Console.WriteLine("[3] Search Customer");
        }

        public MenuOptions YourChoice()
        {
            string info = Console.ReadLine();
            MenuOptions val = MenuOptions.MainMenu;
            switch (info)
            {
                case "0":
                val = MenuOptions.Exit;
                    break;
                case "1":
                    val = MenuOptions.ListCustomerMenu;
                    break;
                case "2":
                    val = MenuOptions.AddCustomerMenu;
                    break;
                case "3":
                    val = MenuOptions.SearchCustomer;
                    break;
                default:
                    Console.WriteLine("Unable todetermine input.");
                    val = MenuOptions.MainMenu;
                    break;
            }
            return val;
        }
    }
}