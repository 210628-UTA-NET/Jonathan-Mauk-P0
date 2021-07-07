using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppData.Entities
{
    public partial class StoreLineItem
    {
        public int StoreLineItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int StoreId { get; set; }

        public virtual Product Product { get; set; }
        public virtual StoreFront Store { get; set; }
    }
}
