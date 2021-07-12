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

        public Orders FindOrder(int orderID)
        {
            Entities.Order order = _context.Orders.Find(orderID);
            return new Orders()
            {
                Id = order.OrderId,
                TotalPrice = (decimal)order.TotalPrice,
                CustomerId = order.CustomerId,
                //Location = StoreFrontDL._storeFrontDL.FindStore(order.StoreId),
                LineItems = OrderLineItem._orderLineItem.RetrieveLineItems(order.OrderId)
            };
        }

        public List<Orders> FindOrdersByCustomer(int p_customerID)
        {
            return _context.Orders.Select(
                rest => new Orders()
                {
                    Id = rest.OrderId,
                    TotalPrice = (decimal)rest.TotalPrice,
                    CustomerId = rest.CustomerId,
                    Location = StoreFrontDL._storeFrontDL.FindStore(rest.StoreId),
                    LineItems = OrderLineItem._orderLineItem.RetrieveLineItems(rest.OrderId)
                }
            ).ToList().Where(
                rest => rest.CustomerId == p_customerID
            ).ToList();
        }

        public List<Orders> FindOrdersByStore(int p_storeID)
        {
            return _context.Orders.Select(
                rest => new Orders()
                {
                    Id = rest.OrderId,
                    TotalPrice = (decimal)rest.TotalPrice,
                    CustomerId = rest.CustomerId,
                    Location = StoreFrontDL._storeFrontDL.FindStore(rest.StoreId),
                    LineItems = OrderLineItem._orderLineItem.RetrieveLineItems(rest.OrderId)
                }
            ).ToList().Where(
                rest => rest.Location.Id == p_storeID
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
                        StoreId = order.Location.Id,
                        CustomerId = order.CustomerId
                    };
                _context.Orders.Add(newOrder);
                foreach (LineItems item in order.LineItems)
                {
                    OrderLineItem._orderLineItem.AddLineItem(item, newOrder);
                    StoreLineItem._storeLineItem.UpdateLineItem(order.Location.Id, -item.Count);
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