using System;
using System.Collections.Generic;
using StoreModels;
using StoreAppBL;

namespace StoreUI
{
    class ViewStoreInvMenu : AMenu, IMenu
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("==== View Store Inventory ====");
            Console.WriteLine("Please choose an option.");
            Console.WriteLine("[2] Browse stores");
            Console.WriteLine("[1] Choose store by name");
            Console.WriteLine("[0] Go back to Inventory Options");
        }

        public MenuOptions YourChoice()
        {
            string input = Console.ReadLine();
            MenuOptions val = MenuOptions.ViewStoreInv;
            StoreFront store = null;
            switch (input)
            {
                case "1":
                    Console.WriteLine("Please enter the store name you wish to view.");
                    string storename = Console.ReadLine();
                    store = StoreFrontBL._storeFrontBL.FindStore(storename);
                    if (store != null)
                    {
                        ListStoreInventory(store);
                    }
                    else
                    {
                        Console.WriteLine("The Store you searched for could not be found");
                    }
                    EnterToContinue();
                    break;
                case "2":
                    store = ChooseStore();
                    if (store != null)
                    {
                        ListStoreInventory(store);
                    }
                    else
                    {
                        Console.WriteLine("The Store you searched for could not be found");
                    }
                    EnterToContinue();
                    break;
                case "0":
                    val = MenuOptions.InventoryOptions;
                    break;
                default:
                    Console.WriteLine("Your Input could not be understood.");
                    break;
            }
            return val;
        }

        private StoreFront ChooseStore()
        {
            Console.Clear();
            StoreFront store = null;
            Console.WriteLine("Please choose the store you wish to view.");
            List<StoreFront> stores = StoreFrontBL._storeFrontBL.RetrieveStores();
            foreach (StoreFront storeFront in stores)
            {
                Console.WriteLine($"[{storeFront.Id}] Name: {storeFront.Name}\t Address: {storeFront.Address}");
            }
            string input2 = Console.ReadLine();
            try
            {
                store = StoreFrontBL._storeFrontBL.FindStore(Int32.Parse(input2));
            }
            catch (System.Exception)
            {
                store = null;
            }
            return store;
        }

        private void ListStoreInventory(StoreFront store)
        {
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine($"Name: {store.Name}");
            Console.WriteLine($"Address: {store.Address}");
            Console.WriteLine("Items: ");
            foreach (LineItems item in store.Inventory)
            {
                Console.WriteLine("---- " + item.ToString());
            }
            Console.WriteLine("========================");
        }
    }
}