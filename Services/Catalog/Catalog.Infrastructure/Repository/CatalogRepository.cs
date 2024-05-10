using Catalog.Core.Entities;
using Catalog.Core.Repository;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repository
{
    public class CatalogRepository : IProductRepository, IBrandRepository, ITypeRepository
    {
        private readonly ICatalogContext _context;
        public CatalogRepository(CatalogContext context)
        {
            _context = context;   
        }
        public async Task<Product> Create(Product product)
        {
            await _context.Product.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            var deleteresult = await _context.Product.DeleteOneAsync(filter);
            return deleteresult.IsAcknowledged && deleteresult.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _context.Product.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductBrand>> GetProductBrands()
        {
            return await _context.ProductBrand.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Product.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByBrand(string brandId)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.ProductBrand.Id, brandId);
            return await _context.Product.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByType(string typeId)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.ProductType.Id, typeId);
            return await _context.Product.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<ProductType>> GetProductTypes()
        {
            return await _context.ProductType.Find(p => true).ToListAsync();
        }

        public async Task<bool> Update(Product product)
        {
            var updateresult = await _context.Product.ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);
            return updateresult.IsAcknowledged && updateresult.ModifiedCount > 0;
        }
    }
}
