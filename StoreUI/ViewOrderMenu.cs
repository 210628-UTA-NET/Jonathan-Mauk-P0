using System;
using StoreModels;
using StoreAppBL;

namespace StoreUI
{
    class ViewOrderMenu : AMenu, IMenu
    {
        public void Menu()
        {
            Console.WriteLine("===== View Orders =====");
            Console.WriteLine("[2] View a customer's order history.");
            Console.WriteLine("[1] View a storefront's order history.");
            Console.WriteLine("[0] Return to Order Options.");
        }

        public MenuOptions YourChoice()
        {
            MenuOptions val = MenuOptions.ViewOrderHistory;
            string input = Console.ReadLine();
            string name;
            switch (input)
            {
                case "0":
                    val = MenuOptions.OrderOptions;
                    break;
                case "1":
                    Console.WriteLine("Enter the storefront's name.");
                    name = Console.ReadLine();
                    StoreFront store = StoreFrontBL._storeFrontBL.FindStore(name);
                    if (store != null)
                    {
                        if (store.Orders != null)
                        {
                            foreach (Orders order in store.Orders)
                            {
                                Console.WriteLine($"[{order.Id}] Customer Id: {order.CustomerId} Total Price: ${order.TotalPrice}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"The store {store.Name} has no orders.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The store could not be found.");
                    }
                    EnterToContinue();
                    break;
                case "2":
                    /*Console.WriteLine("Enter the customer's name.");
                    name = Console.ReadLine();
                    Customer customer = CustomerBL.SearchCustomer(name);*/
                    CustomerSearchMenu customerSearch = new CustomerSearchMenu();
                    Customer customer = customerSearch.SearchCustomerByName();
                    if (customer != null)
                    {
                        if (customer.Orders != null)
                        {
                            foreach (Orders order in customer.Orders)
                            {
                                StoreFront orderStore = StoreFrontBL._storeFrontBL.FindStore(order.LocationId);
                                Console.WriteLine($"[{order.Id}] Store Name: {orderStore.Name} Total Price: ${order.TotalPrice}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"The customer {customer.Name} has no orders.");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("The customer could not be found.");
                    }
                    EnterToContinue();
                    break;
                default:
                    Console.WriteLine("Your input could not be understood");
                    EnterToContinue();
                    break;
            }
            return val;
        }
    }
}