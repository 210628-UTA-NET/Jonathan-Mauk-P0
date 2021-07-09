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

        public void FindStoreInventory(int id)
        {
            if(StoreLineItem._storeLineItem.FindLineItem(id) == null)
            {
                throw new System.Exception();
            }
        }

        public bool ReplenishInventory(int p_storeLineItemId, int p_addedQuantity)
        {
            if (p_addedQuantity > 0)
            {
                return StoreLineItem._storeLineItem.UpdateLineItem(p_storeLineItemId, p_addedQuantity);
            }
            else
            {
                return false;
            }
        }
    }
}