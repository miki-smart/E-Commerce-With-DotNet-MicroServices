using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Repository
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>> GetProductsByBrand(string brandId);
        Task<IEnumerable<Product>> GetProductsByBrandName(string brandName);
        Task<IEnumerable<Product>> GetProductsByType(string typeId);
        Task<bool> Update(Product product);
        Task<Product> Create(Product product);
        Task<bool> Delete(string id);
        Task<IEnumerable<ProductBrand>> GetProductBrands();
        Task<IEnumerable<ProductType>> GetProductTypes();
    }
}
