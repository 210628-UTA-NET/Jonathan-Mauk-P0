using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppData.Entities
{
    public partial class StoreFront
    {
        public StoreFront()
        {
            Orders = new HashSet<Order>();
            StoreLineItems = new HashSet<StoreLineItem>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<StoreLineItem> StoreLineItems { get; set; }
    }
}
