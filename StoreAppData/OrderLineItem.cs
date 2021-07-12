using System.Collections.Generic;
using StoreAppData.Entities;
using StoreModels;
using System.Linq;

namespace StoreAppData
{
    public class OrderLineItem : Repository, ILineItemDL
    {
        // The Singleton for the OrderLineItem class
        public static OrderLineItem _orderLineItem = new OrderLineItem(new Entities.JMStoreAppContext(DatabaseConnection.GetDatabaseOptions()));
        public OrderLineItem(JMStoreAppContext p_context) : base(p_context)
        {
            _context = p_context;
        }

        public LineItems FindLineItem(int id)
        {
            Entities.OrderLineItem orderLineItem = _context.OrderLineItems.Find(id);
            return EntityToModel(orderLineItem);
        }

        public List<LineItems> RetrieveLineItems(int fkid)
        {
            return _context.OrderLineItems.Select(
                rest => EntityToModel(rest)
            ).ToList().Where(
                rest => rest.FkId == fkid
            ).ToList();
        }

        /// <summary>
        /// Adds an OrderLineItem to the database
        /// </summary>
        /// <param name="lineItem">The Lineitem to be added</param>
        /// <param name="order">The Order that the OrderLineItem corresponds to</param>
        /// <returns>True if the OrderLineItem was successfully added to the database</returns>
        public bool AddLineItem(LineItems lineItem, Entities.Order order)
        {
            bool val = false;
            try
            {
                _context.OrderLineItems.Add(
                    new Entities.OrderLineItem()
                    {
                        ProductId = lineItem.Product.Id,
                        Quantity = lineItem.Count,
                        Order = order   // This allows for the OrderLineItem to get the primary key of the Order and use it as a foreign key
                    }
                );
                val = true;
            }
            catch (System.Exception)
            {
                val = false;
            }
            return val;
        }

        /// <summary>
        /// Converts an Entities.OrderLineItem class to a StoreModels.LineItems class
        /// </summary>
        /// <param name="eLineItem">The Entities.OrderLineItem to be converted</param>
        /// <returns>A converted StoreModels.LineItems class</returns>
        public static LineItems EntityToModel(Entities.OrderLineItem eLineItem)
        {
            return new LineItems(){
                Id = eLineItem.OrderLineItemId,
                FkId = eLineItem.OrderId,
                Product = ProductDL._productDL.FindProduct(eLineItem.ProductId),
                Count = eLineItem.Quantity
            };
        }
    }
}