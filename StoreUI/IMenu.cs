using System;

namespace StoreUI
{
    public enum MenuOptions
    {
        MainMenu,
        AddCustomer,
        AddCustomerMenu,
        ListCustomerMenu,
        SearchCustomer,
        ViewStoreInv,
        PlaceOrder,
        ViewOrderHistory,
        ReplenishInventory,
        Exit
    }
    public interface IMenu
    {
        /// <summary>
        /// Shows the menu
        /// </summary>
        void Menu();

        /// <summary>
        /// Reads user input to respond to the user's choice
        /// </summary>
        /// <returns>A MenuOptions enum based off of the users input</returns>
        MenuOptions YourChoice();
    }
}
