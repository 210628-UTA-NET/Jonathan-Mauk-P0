using StoreModels;
using StoreAppData;
using System.Collections.Generic;

namespace StoreAppBL
{
    public class StoreFrontBL
    {
        public static StoreFrontBL _storeFrontBL = new StoreFrontBL();

        public StoreFront FindStore(string name)
        {
            return StoreFrontDL._storeFrontDL.FindStore(name);
        }
        public StoreFront FindStore(int id)
        {
            return StoreFrontDL._storeFrontDL.FindStore(id);
        }

        public List<StoreFront> RetrieveStores()
        {
            return StoreFrontDL._storeFrontDL.RetrieveStoreFronts();
        }
    }
}