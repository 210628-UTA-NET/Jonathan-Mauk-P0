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
        }

        public string YourChoice()
        {
            string info = Console.ReadLine();
            switch (info)
            {
                case "0":
                    break;
                case "1":
                    info = "List_Cust_Menu";
                    break;
                case "2":
                    info = "Add_Cust_Menu";
                    break;
                default:
                    info = "unknown";
                    break;
            }
            return info;
        }
    }
}