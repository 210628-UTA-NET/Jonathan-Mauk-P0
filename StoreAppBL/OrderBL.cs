using System;
using StoreModels;
using StoreAppData;
using System.Collections.Generic;

namespace StoreAppBL
{
    public class OrderBL
    {
        public Orders CurrentOrder { get; set; }
        public OrderBL()
        {
            CurrentOrder = new Orders();
        }

        //public List<Orders> GetOrdersByCustomer() 

        public void BeginOrder(Customer p_customer, StoreFront p_storeFront)
        {
            CurrentOrder.Location = p_storeFront;
            CurrentOrder.TotalPrice = 0;
            CurrentOrder.CustomerId = p_customer.CustomerId;
            CurrentOrder.LineItems = new List<LineItems>();
        }

        public bool AddOrderItem(int p_id, int num)
        {
            LineItems storeLineItem = StoreLineItem._storeLineItem.FindLineItem(p_id);
            if(num > storeLineItem.Count)
            {
                return false;
            }
            else
            {
                LineItems orderLineItem = new LineItems()
                {
                    Product = storeLineItem.Product,
                    Count = num
                };
                CurrentOrder.LineItems.Add(orderLineItem);
                CurrentOrder.TotalPrice += orderLineItem.Product.Price * num;
                return true;
            }
        }

        public void IsChoice(int choice)
        {
            foreach (LineItems item in CurrentOrder.Location.Inventory)
            {
                if (item.Id == choice)
                {
                    return;
                }
            }
            throw new Exception();
        }

        public bool FinalizeOrder()
        {
            return OrderDL._orderDL.PlaceOrder(CurrentOrder);
        }
    }
}