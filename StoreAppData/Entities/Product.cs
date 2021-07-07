using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppData.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderLineItems = new HashSet<OrderLineItem>();
            StoreLineItems = new HashSet<StoreLineItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }
        public virtual ICollection<StoreLineItem> StoreLineItems { get; set; }
    }
}
