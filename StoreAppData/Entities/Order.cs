using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppData.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderLineItems = new HashSet<OrderLineItem>();
        }

        public int OrderId { get; set; }
        public decimal? TotalPrice { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual StoreFront Store { get; set; }
        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }
    }
}
