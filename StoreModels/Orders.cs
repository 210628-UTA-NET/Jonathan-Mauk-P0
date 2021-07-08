using System;
using System.Collections.Generic;

namespace StoreModels
{
    public class Orders
    {
        public int Id { get; set; }
        public List<LineItems> LineItems { get; set; }
        public StoreFront Location { get; set; }
        public decimal TotalPrice { get; set; }

        public Orders()
        {
            
        }
    }
}