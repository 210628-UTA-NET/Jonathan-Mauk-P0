using System;

namespace StoreUI
{
    class CustomerOptionsMenu : AMenu, IMenu
    {
        public void Menu()
        {
            Console.Clear();

            Console.WriteLine("[3] Add a Customer");
            Console.WriteLine("[2] Search for a Customer");
            Console.WriteLine("[1] List Customers");
            Console.WriteLine("[0] Return to Main Menu");
        }

        public MenuOptions YourChoice()
        {
            string input = Console.ReadLine();
            MenuOptions choice = MenuOptions.CustomerOptions;
            switch (input)
            {
                case "0":
                    choice = MenuOptions.MainMenu;
                    break;
                case "1":
                    choice = MenuOptions.ListCustomerMenu;
                    break;
                case "2":
                    choice = MenuOptions.SearchCustomer;
                    break;
                case "3":
                    choice = MenuOptions.AddCustomerMenu;
                    break;
                default:
                    Console.WriteLine("Input could not be understood.");
                    EnterToContinue();
                    break;
            }
            return choice;
        }
    }
}