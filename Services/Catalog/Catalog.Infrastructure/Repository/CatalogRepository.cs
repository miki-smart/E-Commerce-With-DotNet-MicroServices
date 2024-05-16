using Catalog.Core.Entities;
using Catalog.Core.Repository;
using Catalog.Core.SpecParams;
using Catalog.Infrastructure.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repository
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ICatalogContext _context;
        public CatalogRepository(ICatalogContext context)
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

        public async Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams)
        {
            var builder = Builders<Product>.Filter;
            var filter = builder.Empty;
            if (!string.IsNullOrEmpty(catalogSpecParams.BrandId))
            {   
                filter = builder.Eq(p => p.Brands.Id, catalogSpecParams.BrandId);
            }
            if (!string.IsNullOrEmpty(catalogSpecParams.TypeId))
            {
                filter = builder.Eq(p => p.Types.Id, catalogSpecParams.TypeId);
            }
            if (!string.IsNullOrEmpty(catalogSpecParams.Search))
            {
                var searchFilter = builder.Regex(x => x.Name, new BsonRegularExpression(catalogSpecParams.Search));
                filter &=searchFilter;
            }
            
            if (!string.IsNullOrEmpty(catalogSpecParams.Sort))
            {
                var sort = catalogSpecParams.Sort switch
                {
                    "priceAsc" => Builders<Product>.Sort.Ascending(p => p.Price),
                    "priceDesc" => Builders<Product>.Sort.Descending(p => p.Price),
                    _ => Builders<Product>.Sort.Ascending(p => p.Name)
                };
                return new Pagination<Product>(
                    catalogSpecParams.PageIndex,
                    catalogSpecParams.PageSize,
                     await _context.Product.CountDocumentsAsync(filter),
                    await _context.Product.Find(filter).Sort(sort).Skip((catalogSpecParams.PageIndex - 1)
                * catalogSpecParams.PageSize).Limit(catalogSpecParams.PageSize).ToListAsync()
                );
            }
            return new Pagination<Product>(
                    catalogSpecParams.PageIndex,
                    catalogSpecParams.PageSize,
                     await _context.Product.CountDocumentsAsync(filter),
                    await _context.Product.Find(filter).Skip((catalogSpecParams.PageIndex - 1)
                * catalogSpecParams.PageSize).Limit(catalogSpecParams.PageSize).ToListAsync()
                );

        }

        public async Task<IEnumerable<Product>> GetProductsByBrand(string brandId)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Brands.Id, brandId);
            return await _context.Product.Find(filter).ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsByBrandName(string brandName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Brands.Name, brandName);
            return await _context.Product.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByType(string typeId)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Types.Id, typeId);
            return await _context.Product.Find(filter).ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsByTypeName(string typeName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Brands.Name, typeName);
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
