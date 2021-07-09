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
            throw new System.NotImplementedException();
        }

        public List<Orders> FindOrdersByCustomer(int p_customerID)
        {
            throw new System.NotImplementedException();
        }

        public List<Orders> FindOrdersByStore(int p_storeID)
        {
            throw new System.NotImplementedException();
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