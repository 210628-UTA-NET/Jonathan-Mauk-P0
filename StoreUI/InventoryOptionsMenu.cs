using System;

namespace StoreUI
{
    class InventoryOptionsMenu : AMenu, IMenu
    {
        public void Menu()
        {
            Console.WriteLine("[2] View a store's inventory");
            Console.WriteLine("[1] Replenish a store's inventory");
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
                    choice = MenuOptions.ReplenishInventory;
                    break;
                case "2":
                    choice = MenuOptions.ViewStoreInv;
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