using System;
using System.Collections.Generic;

namespace StoreUI 
{
    public class ListCustomerUI : IMenu
    {
        private List<string> lists = new List<string>();
        public ListCustomerUI(List<string> list)
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

        public string YourChoice()
        {
            Console.WriteLine("Press Enter to return to the main menu");
            Console.ReadLine();
            return "MainMenu";
        }
    }
}