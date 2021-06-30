using System;

namespace StoreUI
{
    public enum MenuOptions
    {
        MainMenu,
        AddCustomer,
        AddCustomerMenu,
        ListCustomerMenu,
        Exit
    }
    public interface IMenu
    {
        void Menu();

        MenuOptions YourChoice();
    }
}
