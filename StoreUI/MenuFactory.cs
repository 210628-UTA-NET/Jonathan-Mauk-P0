using System;

namespace StoreUI
{
    public class MenuFactory : IMenuFactory
    {
        public IMenu GetMenu(MenuOptions option)
        {
            IMenu menu = null;
            switch (option)
            {
                case MenuOptions.Exit:
                    menu = null;
                    break;
                case MenuOptions.ListCustomerMenu:
                    menu = new ListCustomerMenu();
                    break;
                case MenuOptions.AddCustomerMenu:
                    menu = new AddCustomerMenu();
                    break;
                case MenuOptions.MainMenu:
                    menu = new MainMenu();
                    break;
                case MenuOptions.SearchCustomer:
                    menu = new CustomerSearchMenu();
                    break;
                case MenuOptions.ViewStoreInv:
                    menu = new ViewStoreInvMenu();
                    break;
                case MenuOptions.ReplenishInventory:
                    Console.WriteLine("!!!!!!!!Not Implemented!!!!!!!!!");
                    break;
                case MenuOptions.ViewOrderHistory:
                    menu = new ViewOrderMenu();
                    break;
                case MenuOptions.PlaceOrder:
                    Console.WriteLine("!!!!!!!!Not Implemented!!!!!!!!!");
                    break;
                default:
                    menu = new MainMenu();
                    Console.WriteLine("Could not understand input.");
                    break;
            }
            return menu;
        }
    }
}