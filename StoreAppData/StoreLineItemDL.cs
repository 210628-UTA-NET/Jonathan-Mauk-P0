using System.Collections.Generic;
using StoreAppData.Entities;
using StoreModels;
using System.Linq;

namespace StoreAppData
{
    public class StoreLineItem : Repository, ILineItemDL
    {
        public static StoreLineItem _storeLineItem = new StoreLineItem(new Entities.JMStoreAppContext(DatabaseConnection.GetDatabaseOptions()));
        public StoreLineItem(JMStoreAppContext p_context) : base(p_context)
        {
            _context = p_context;
        }

        public LineItems FindLineItem(int id)
        {
            Entities.StoreLineItem storeLineItem = _context.StoreLineItems.Find(id);
            return new LineItems() {
                Id = storeLineItem.StoreLineItemId,
                Product = ProductDL._productDL.FindProduct(storeLineItem.ProductId),
                Count = storeLineItem.Quantity
            };
        }

        public List<LineItems> RetrieveLineItems(int fkid)
        {
            return _context.StoreLineItems.Select(
                rest => new LineItems()
                {
                    Id = rest.StoreLineItemId,
                    Product = ProductDL._productDL.FindProduct(rest.ProductId),
                    Count = rest.Quantity,
                    FkId = rest.StoreId
                }
            ).ToList().Where(
                rest => rest.FkId == fkid
            ).ToList();
        }

        public bool UpdateLineItem(int id, int addedQuantity)
        {
            try
            {
                Entities.StoreLineItem updatedLineItem = _context.StoreLineItems.Find(id);
                updatedLineItem.Quantity += addedQuantity;
                _context.StoreLineItems.Update(updatedLineItem);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}