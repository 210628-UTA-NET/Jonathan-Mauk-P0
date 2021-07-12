using System.Collections.Generic;
using StoreModels;
using System.Linq;
using StoreAppData.Entities;

namespace StoreAppData
{
    public class OrderDL : Repository, IOrderDL
    {
        public static OrderDL _orderDL = new OrderDL(new Entities.JMStoreAppContext(DatabaseConnection.GetDatabaseOptions()));
        public OrderDL(JMStoreAppContext p_context) : base(p_context)
        {
            _context = p_context;
        }

        public static Orders EntityToModel(Order eOrder)
        {
            return new Orders()
            {
                Id = eOrder.OrderId,
                LineItems = OrderLineItem._orderLineItem.RetrieveLineItems(eOrder.OrderId),
                TotalPrice = (decimal)eOrder.TotalPrice,
                LocationId = eOrder.StoreId,
                CustomerId = eOrder.CustomerId
            };
        }

        public Orders FindOrder(int orderID)
        {
            Entities.Order order = _context.Orders.Find(orderID);
            return EntityToModel(order);
        }

        public List<Orders> FindOrdersByCustomer(int p_customerID)
        {
            return _context.Orders.Select(
                rest => EntityToModel(rest)
            ).ToList().Where(
                rest => rest.CustomerId == p_customerID
            ).ToList();
        }

        public List<Orders> FindOrdersByStore(int p_storeID)
        {
            return _context.Orders.Select(
                rest => EntityToModel(rest)
            ).ToList().Where(
                rest => rest.LocationId == p_storeID
            ).ToList();
        }

        public bool PlaceOrder(Orders order)
        {
            bool val = false;
            try
            {
                Entities.Order newOrder = new Entities.Order()
                    {
                        TotalPrice = order.TotalPrice,
                        StoreId = order.LocationId,
                        CustomerId = order.CustomerId
                    };
                _context.Orders.Add(newOrder);
                foreach (LineItems item in order.LineItems)
                {
                    OrderLineItem._orderLineItem.AddLineItem(item, newOrder);
                    StoreLineItem._storeLineItem.UpdateLineItem(order.LocationId, -item.Count);
                }
                _context.SaveChanges();
                val = true;
            }
            catch (System.Exception)
            {
                val = false;
            }
            return val;
        }
    }
}