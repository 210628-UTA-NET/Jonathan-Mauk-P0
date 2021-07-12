
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

        /// <summary>
        /// Converts an Entities.StoreFront class to a StoreModels.StoreFront class
        /// </summary>
        /// <param name="eStoreFront">The Entities.StoreFront to be converted</param>
        /// <returns>A converted StoreModels.StoreFront class</returns>
        public static StoreFront EntityToModel(Entities.StoreFront eStoreFront)
        {
            return new StoreFront()
            {
                Id = eStoreFront.StoreId,
                Name = eStoreFront.StoreName,
                Address = eStoreFront.StoreAddress,
                Inventory = StoreLineItem._storeLineItem.RetrieveLineItems(eStoreFront.StoreId),
                Orders = OrderDL._orderDL.FindOrdersByStore(eStoreFront.StoreId)
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