using System;
using System.Collections.Generic;

namespace StoreModels
{
    public class Orders
    {
        public List<LineItems> LineItems { get; set; }
        public StoreFront Location { get; set; }
        public double TotalPrice { get; set; }

        public Orders()
        {
            
        }
    }
}