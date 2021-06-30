using System;
using System.Collections.Generic;

namespace StoreUI 
{
    public class ListCustomerMenu : IMenu
    {
        private List<string> lists = new List<string>();
        public ListCustomerMenu(List<string> list)
        {
            foreach (string item in list)
            {
                lists.Add(item);
            }
        }

        public void Menu()
        {
            Console.WriteLine("Here is a list of the Customers.");
            foreach (string item in lists)
            {
                Console.WriteLine(item);
            }
        }

        public MenuOptions YourChoice()
        {
            Console.WriteLine("Press Enter to return to the main menu");
            Console.ReadLine();
            return MenuOptions.MainMenu;
        }
    }
}