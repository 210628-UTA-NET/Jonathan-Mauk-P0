using System.Collections.Generic;
using StoreAppData.Entities;
using StoreModels;
using System.Linq;

namespace StoreAppData
{
    public class OrderLineItem : Repository, ILineItemDL
    {
        public static StoreLineItem _orderLineItem = new StoreLineItem(new Entities.JMStoreAppContext(DatabaseConnection.GetDatabaseOptions()));
        public OrderLineItem(JMStoreAppContext p_context) : base(p_context)
        {
            _context = p_context;
        }

        public LineItems FindLineItem(int id)
        {
            Entities.OrderLineItem OrderLineItem = _context.OrderLineItems.Find(id);
            return new LineItems() {
                Id = OrderLineItem.OrderLineItemId,
                Product = ProductDL._productDL.FindProduct(OrderLineItem.ProductId),
                Count = OrderLineItem.Quantity
            };
        }

        public List<LineItems> RetrieveLineItems(int fkid)
        {
            return _context.OrderLineItems.Select(
                rest => new LineItems()
                {
                    Id = rest.OrderLineItemId,
                    Product = ProductDL._productDL.FindProduct(rest.ProductId),
                    Count = rest.Quantity,
                    FkId = rest.OrderId
                }
            ).ToList().Where(
                rest => rest.FkId == fkid
            ).ToList();
        }

        public bool UpdateLineItem(int id, int addedQuantity)
        {
            throw new System.NotImplementedException();
        }
    }
}