using System;
using System.Collections.Generic;

namespace StoreModels 
{
    public class StoreFront 
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<LineItems> Inventory { get; set; }
        public List<Orders> Orders { get; set; }
        public StoreFront()
        {
            
        }

        //public void 

    }
}
