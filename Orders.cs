using System;
using System.Collections.Generic;

namespace P0
{
    class Orders
    {
        public List<LineItems> LineItems { get; set; }
        public StoreFront Location { get; set; }
        public double TotalPrice { get; set; }

        public Orders()
        {
            
        }
    }
}