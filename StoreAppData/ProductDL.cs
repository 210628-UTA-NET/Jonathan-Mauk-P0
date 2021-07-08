
using System.Collections.Generic;
using StoreModels;
using System.Linq;

namespace StoreAppData
{
    public class ProductDL : Repository, IProductDL
    {
        public ProductDL(Entities.JMStoreAppContext p_context) : base(p_context)
        {
            _context = p_context;
        }

        public Products FindProduct(int id)
        {
            Entities.Product eProduct = _context.Products.Find();
            return new Products(){
                Id = eProduct.ProductId,
                Name = eProduct.ProductName,
                Price = eProduct.ProductPrice,
                Description = eProduct.Description,
                Category = eProduct.Category
            };
        }

        public List<Products> RetrieveProducts()
        {
            return _context.Products.Select(
                rest => 
                    new Products()
                    {
                        Id = rest.ProductId,
                        Name = rest.ProductName,
                        Price = rest.ProductPrice,
                        Description = rest.Description,
                        Category = rest.Category
                    }
            ).ToList();
        }
    }
}