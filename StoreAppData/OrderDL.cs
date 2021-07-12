using System.Collections.Generic;
using StoreModels;
using System.Linq;
using StoreAppData.Entities;

namespace StoreAppData
{
    public class OrderDL : Repository, IOrderDL
    {
        // The Singleton for the OrderDL class
        public static OrderDL _orderDL = new OrderDL(new Entities.JMStoreAppContext(DatabaseConnection.GetDatabaseOptions()));
        public OrderDL(JMStoreAppContext p_context) : base(p_context)
        {
            _context = p_context;
        }

        /// <summary>
        /// Converts an Entities.Order class to a StoreModels.Orders class
        /// </summary>
        /// <param name="eOrder">The Entities.Order to be converted</param>
        /// <returns>A converted StoreModels.Orders class</returns>
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

        public bool PlaceOrder(Orders order, List<LineItems> p_changedLineItems)
        {
            bool val = false;
            try
            {
                // Update the StoreLineItems to match the order being made
                foreach (LineItems item in p_changedLineItems)
                {
                    StoreLineItem._storeLineItem.UpdateLineItemNoSave(item.Id, -item.Count);
                }

                // Create the order to be added to the database
                Entities.Order newOrder = new Entities.Order()
                    {
                        TotalPrice = order.TotalPrice,
                        StoreId = order.LocationId,
                        CustomerId = order.CustomerId
                    };
                // Add the order to the database
                _context.Orders.Add(newOrder);

                // Add the OrderLineItems to the database
                foreach (LineItems item in order.LineItems)
                {
                    // Passing in the created order allows for the OrderLineItems to 
                    // get the Order's OrderId value
                    OrderLineItem._orderLineItem.AddLineItem(item, newOrder);
                }
                _context.SaveChanges();     // Save Changes to the database
                StoreLineItem._storeLineItem.StoreLineItemSave(); //Makes sure that the Store line items are updated
                val = true;
            }
            // Catch any errors and return false to signal a failure
            catch (System.Exception)
            {
                val = false;
            }
            return val;
        }
    }
}