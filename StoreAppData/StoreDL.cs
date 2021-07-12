
using System.Collections.Generic;
using StoreModels;
using System.Linq;

namespace StoreAppData
{
    public class StoreFrontDL : Repository, IStoreFrontDL
    {
        // The Singleton for StoreFrontDL
        public static StoreFrontDL _storeFrontDL = new StoreFrontDL(new Entities.JMStoreAppContext(DatabaseConnection.GetDatabaseOptions()));

        public StoreFrontDL(Entities.JMStoreAppContext p_context) : base(p_context)
        {
            _context = p_context;
        }

        public static StoreFront EntityToModel(Entities.StoreFront eStoreFront)
        {
            List<LineItems> inventory = new List<LineItems>();
            List<Orders> orders = new List<Orders>();
            foreach (Entities.StoreLineItem item in eStoreFront.StoreLineItems)
            {
                inventory.Add(StoreLineItem.EntityToModel(item));
            }
            foreach (Entities.Order order in eStoreFront.Orders)
            {
                orders.Add(OrderDL.EntityToModel(order));
            }
            return new StoreFront()
            {
                Id = eStoreFront.StoreId,
                Name = eStoreFront.StoreName,
                Address = eStoreFront.StoreAddress,
                Inventory = inventory,
                Orders = orders
            };
        }

        public StoreFront FindStore(string name)
        {
            foreach (StoreFront store in RetrieveStoreFronts())
            {
                if (store.Name == name)
                {
                    return store;
                }
            }
            return null;
        }

        public StoreFront FindStore(int id)
        {
            Entities.StoreFront storeFront = _context.StoreFronts.Find(id);
            return EntityToModel(storeFront);
        }

        public List<StoreFront> RetrieveStoreFronts()
        {
            return _context.StoreFronts.Select(
                rest => 
                    EntityToModel(rest)
            ).ToList().OrderBy(
                o => o.Id
            ).ToList()            ;
        }
    }
}