using System;
using StoreModels;
using StoreAppData;
using System.Collections.Generic;

namespace StoreAppBL
{
    public class OrderBL
    {
        public Orders CurrentOrder { get; set; }
        public StoreFront CurrentStore { get; set; }
        private List<LineItems> _changedStoreLineItems = new List<LineItems>();
        public OrderBL()
        {
            CurrentOrder = new Orders();
        }

        //public List<Orders> GetOrdersByCustomer() 

        public void BeginOrder(Customer p_customer, StoreFront p_storeFront)
        {
            CurrentOrder.LocationId = p_storeFront.Id;
            CurrentOrder.TotalPrice = 0;
            CurrentOrder.CustomerId = p_customer.CustomerId;
            CurrentOrder.LineItems = new List<LineItems>();
            CurrentStore = p_storeFront;
        }

        public bool AddOrderItem(int p_id, int num)
        {
            LineItems storeLineItem = StoreLineItem._storeLineItem.FindLineItem(p_id);
            LineItems orderLineItem = null;
            bool val = false;

            foreach (LineItems item in CurrentOrder.LineItems)
            {
                if (item.Product.Id == storeLineItem.Product.Id)
                {
                    orderLineItem = item;
                }
            }
            if(num > storeLineItem.Count)
            {
                val = false;
            }
            else if (orderLineItem != null)
            {
                if (orderLineItem.Count + num > storeLineItem.Count)
                {
                    val = false;
                }
                else
                {
                    orderLineItem.Count += num;
                    CurrentOrder.TotalPrice += orderLineItem.Product.Price * num;
                    val = true;
                }
            }
            else
            {
                orderLineItem = new LineItems()
                {
                    Product = storeLineItem.Product,
                    Count = num
                };
                CurrentOrder.LineItems.Add(orderLineItem);
                CurrentOrder.TotalPrice += orderLineItem.Product.Price * num;
                val = true;
            }

            if (val)
            {
                _changedStoreLineItems.Add(new LineItems(){
                    Id = p_id,
                    Count = num
                });
            }
            return val;
        }

        public void IsChoice(int choice)
        {
            foreach (LineItems item in CurrentStore.Inventory)
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
            if (CurrentOrder.TotalPrice <= 0)
            {
                return false;
            }
            return OrderDL._orderDL.PlaceOrder(CurrentOrder, _changedStoreLineItems);
        }
    }
}