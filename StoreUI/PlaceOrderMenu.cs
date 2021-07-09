using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreModels;

namespace StoreUI
{
    public class PlaceOrderMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("===== Place Order =====");
            Console.WriteLine("[1] Begin placing order.");
            Console.WriteLine("[0] Return to Main Menu.");
        }

        public MenuOptions YourChoice()
        {
            MenuOptions option = MenuOptions.PlaceOrder;
            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    option = MenuOptions.MainMenu;
                    break;
                case "1":
                    PlaceOrder();
                    break;
                default:
                    Console.WriteLine("Input could not be understood.");
                    break;
            }
            return option;
        }

        private void PlaceOrder()
        {
            Console.WriteLine("Please enter the Customer's Name.");
            string input = Console.ReadLine();
            Customer customer = CustomerBL.SearchCustomer(input);
            StoreFront store;
            OrderBL _curOrder = new OrderBL();
            if (customer != null)
            {
                store = GetStoreFront();
                _curOrder.BeginOrder(customer, store);
                bool checkout = false;
                while (!checkout)
                {
                    checkout = ShowCurrentOrder(_curOrder);
                }
                if (_curOrder.FinalizeOrder())
                {
                    Console.WriteLine("Your Order has been place.");
                }
                else
                {
                    Console.WriteLine("Your Order could not be placed.");
                }
            }
            else
            {
                Console.WriteLine("The Customer could not be found.");
            }
            
            Console.WriteLine("Press Enter to continue ...");
            Console.ReadLine();            
        }

        private StoreFront GetStoreFront() 
        {
            StoreFront store = null;
            bool repeat = true;
            string input;
            string input2;
            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("===== Choose Store =====");
                Console.WriteLine("[1] Choose store by name.");
                Console.WriteLine("[0] Browse stores.");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Please Enter the store's name.");
                        input2 = Console.ReadLine();
                        store = StoreFrontBL._storeFrontBL.FindStore(input2);
                        repeat = false;
                        break;
                    case "0":
                        List<StoreFront> storeFronts = StoreFrontBL._storeFrontBL.RetrieveStores();
                        storeFronts.Reverse();
                        Console.WriteLine("Please choose a store.");
                        foreach (StoreFront item in storeFronts)
                        {
                            Console.WriteLine($"[{item.Id}] {item.Name}\t {item.Address}");
                        }
                        input2 = Console.ReadLine();
                        try
                        {
                            store = StoreFrontBL._storeFrontBL.FindStore(Int32.Parse(input2));
                            repeat = false;
                        }
                        catch (System.Exception)
                        {
                            Console.WriteLine("Input could not be understood.");
                        }
                        break;
                    default:
                        Console.WriteLine("Input could not be understood.");
                        break;
                }
                if (store == null)
                {
                    Console.WriteLine("Store could not be found.");
                    Console.WriteLine("Press Enter to try again.");
                    Console.ReadLine();
                    repeat = true;
                }
            }
            return store;
        }

        private bool ShowCurrentOrder(OrderBL p_order)
        {
            bool val = false;
            Console.Clear();
            Console.WriteLine("===== Current Order =====");
            Console.WriteLine("Store Name:    " + p_order.CurrentOrder.Location.Name);
            Console.WriteLine("Store Address: " + p_order.CurrentOrder.Location.Address);
            Console.WriteLine("Total Price: $" + p_order.CurrentOrder.TotalPrice);
            Console.WriteLine("Cart:");
            foreach (LineItems item in p_order.CurrentOrder.LineItems)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("=========================");
            Console.WriteLine("[1] Add items to cart.");
            Console.WriteLine("[0] Checkout.");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ShowInventory(p_order);
                    break;
                case "0":
                    val = true;
                    break;
                default:
                    break;
            }
            return val;
        }

        public void ShowInventory(OrderBL p_order)
        {
            Console.WriteLine($"===== {p_order.CurrentOrder.Location.Name} Inventory =====");
            Console.WriteLine($"Please choose a product to order.");
            foreach (LineItems item in p_order.CurrentOrder.Location.Inventory)
            {
                Console.WriteLine($"[{item.Id}] " + item.ToString());
            }

            string input = Console.ReadLine();
            try
            {
                p_order.IsChoice(Int32.Parse(input));
            }
            catch (System.Exception)
            {
                Console.WriteLine("Input could not be understood");
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                return;
            }
            
            Console.WriteLine("Enter the amount of items you wish to order.");
            string input2 = Console.ReadLine();
            try
            {
                if(!p_order.AddOrderItem(Int32.Parse(input), Int32.Parse(input2)))
                {
                    Console.WriteLine("Not enough items in stock.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Product added to cart.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Input could not be understood");
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                return;
            }

        }
    }
}