using System;
using System.Collections.Generic;
using StoreModels;
using StoreAppBL;

namespace StoreUI
{
    public class ReplenishInventoryMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("===== Replenish Inventory =====");
            Console.WriteLine("[2] Choose store by name.");
            Console.WriteLine("[1] Browse stores");
            Console.WriteLine("[0] Return to Main Menu.");
        }

        public MenuOptions YourChoice()
        {
            string input = Console.ReadLine();
            MenuOptions menu = MenuOptions.ReplenishInventory;
            switch (input)
            {
                case "0":
                    menu = MenuOptions.MainMenu;
                    break;
                case "1":
                    ShowInventory(ShowStores());
                    break;
                case "2":
                    Console.WriteLine("Please enter the store's name.");
                    string input2 = Console.ReadLine();
                    StoreFront store = StoreFrontBL._storeFrontBL.FindStore(input2);
                    if (store != null)
                    {
                        ShowInventory(store);
                    }
                    else
                    {
                        Console.WriteLine("Store could not be found.\nPress Enter to continue.");
                        Console.ReadLine();
                    }
                    break;
                default:
                    Console.WriteLine("Input could not be understood.");
                    break;
            }
            return menu;
        }

        private StoreFront ShowStores()
        {
            Console.Clear();
            List<StoreFront> storeFronts = StoreFrontBL._storeFrontBL.RetrieveStores();
            storeFronts.Reverse();
            StoreFront store = null;
            Console.WriteLine("Please choose a store.");
            while (store == null) 
            {
                foreach (StoreFront item in storeFronts)
                {
                    Console.WriteLine($"[{item.Id}] {item.Name}\t {item.Address}");
                }
                string input2 = Console.ReadLine();
                try
                {
                    store = StoreFrontBL._storeFrontBL.FindStore(Int32.Parse(input2));
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Input could not be understood.");
                }
            }
            return store;
        }

        private void ShowInventory(StoreFront store)
        {
            List<LineItems> inventory = StoreFrontBL._storeFrontBL.FindStore(store.Id).Inventory;

            foreach (LineItems item in inventory)
            {
                Console.WriteLine($"[{item.Id}] {item.Product.Name}\t {item.Count}");
            }

            string input2 = Console.ReadLine();
            try
            {
                StoreFrontBL._storeFrontBL.FindStoreInventory(Int32.Parse(input2));
            }
            catch (System.Exception)
            {
                Console.WriteLine("Input could not be understood.");
                return;
            }
            
            Console.WriteLine("Enter the number of items being added to the stock.");
            string input3 = Console.ReadLine();
            try
            {
                if (StoreFrontBL._storeFrontBL.ReplenishInventory(Int32.Parse(input2), Int32.Parse(input3)))
                {
                    Console.WriteLine("The Inventory has been replenished.");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Input could not be understood.");
            }
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}