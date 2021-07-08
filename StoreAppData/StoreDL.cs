
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
            return new StoreFront() 
            {
                Id = storeFront.StoreId,
                Name = storeFront.StoreName,
                Address = storeFront.StoreAddress,
                Inventory = StoreLineItem._storeLineItem.RetrieveLineItems(storeFront.StoreId)
            };
        }

        public List<StoreFront> RetrieveStoreFronts()
        {
            return _context.StoreFronts.Select(
                rest => 
                    new StoreFront()
                    {
                        Id = rest.StoreId,
                        Name = rest.StoreName,
                        Address = rest.StoreAddress,
                        Inventory = StoreLineItem._storeLineItem.RetrieveLineItems(rest.StoreId)
                    }
            ).ToList();
        }
    }
}