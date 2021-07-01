
using System.Collections.Generic;
using StoreModels;

namespace StoreAppData
{
    public class StoreFrontDL : IStoreFrontDL
    {
        // The Singleton for StoreFrontDL
        public static StoreFrontDL _storeFrontDL = new StoreFrontDL();

        public StoreFrontDL()
        {
            
        } 
        public StoreFront FindStore(string name)
        {
            throw new System.NotImplementedException();
        }

        public List<StoreFront> RetrieveStoreFronts()
        {
            throw new System.NotImplementedException();
        }
    }
}