using System;
using StoreModels;
using StoreAppBL;

namespace StoreUI
{
    class ViewStoreInvMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("==== View Store Inventory ====");
            Console.WriteLine("Please choose an option.");
            Console.WriteLine("[1] View a store's inventory.");
            Console.WriteLine("[0] Go back to main menu");
        }

        public MenuOptions YourChoice()
        {
            string input = Console.ReadLine();
            MenuOptions val = MenuOptions.ViewStoreInv;
            switch (input)
            {
                case "1":
                    Console.WriteLine();
                    Console.WriteLine("Please enter the store name you wish to view.");
                    string storename = Console.ReadLine();
                    StoreFront store = StoreFrontBL._storeFrontBL.FindStore(storename);
                    if (store != null)
                    {
                        Console.WriteLine("========================");
                        Console.WriteLine($"Name: {store.Name}");
                        Console.WriteLine($"Address: {store.Address}");
                        Console.WriteLine("Items: ");
                        foreach (LineItems item in store.Inventory)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine("========================");
                    }
                    else
                    {
                        Console.WriteLine("The Store you searched for could not be found");
                    }
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    break;
                case "0":
                    val = MenuOptions.MainMenu;
                    break;
                default:
                    Console.WriteLine("Your Input could not be understood.");
                    break;
            }
            return val;
        }
    }
}