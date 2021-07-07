using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppData.Entities
{
    public partial class OrderLineItem
    {
        public int OrderLineItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
