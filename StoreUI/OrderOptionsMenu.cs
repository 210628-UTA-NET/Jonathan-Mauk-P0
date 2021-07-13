using System;

namespace StoreUI
{
    class OrderOptionsMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("[2] View order history");
            Console.WriteLine("[1] Place an order");
            Console.WriteLine("[0] Return to Main Menu");
        }

        public MenuOptions YourChoice()
        {
            string input = Console.ReadLine();
            MenuOptions choice = MenuOptions.InventoryOptions;
            switch (input)
            {
                case "0":
                    choice = MenuOptions.MainMenu;
                    break;
                case "1":
                    choice = MenuOptions.PlaceOrder;
                    break;
                case "2":
                    choice = MenuOptions.ViewOrderHistory;
                    break;
                default:
                    Console.WriteLine("Input could not be understood.");
                    break;
            }
            return choice;
        }
    }
}