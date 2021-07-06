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
            Console.WriteLine("[7] Place Order");
            Console.WriteLine("[6] View Order Inventory");
            Console.WriteLine("[5] Replenish Store Inventory");
            Console.WriteLine("[4] View Store Inventory");
            Console.WriteLine("[3] Search Customer");
            Console.WriteLine("[2] Add Customer");
            Console.WriteLine("[1] List Customers");
            Console.WriteLine("[0] Exit");
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
                case "4":
                    val = MenuOptions.ViewStoreInv;
                    break;
                case "5":
                    val = MenuOptions.ReplenishInventory;
                    break;
                case "6":
                    val = MenuOptions.ViewOrderHistory;
                    break;
                case "7":
                    val = MenuOptions.PlaceOrder;
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