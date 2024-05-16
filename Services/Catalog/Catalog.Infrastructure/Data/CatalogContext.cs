using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Product {get;}

        public IMongoCollection<ProductBrand> ProductBrand {get;}

        public IMongoCollection<ProductType> ProductType {get;}
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            
            ProductBrand = database.GetCollection<ProductBrand>(configuration.GetValue<string>("DatabaseSettings:BrandCollection"));
            
            ProductType = database.GetCollection<ProductType>(configuration.GetValue<string>("DatabaseSettings:TypeCollection"));
            
            Product = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:ProductCollection"));
            BrandContextSeed.SeedData(ProductBrand);
            TypeContextSeed.SeedData(ProductType);
            ProductContextSeed.SeedData(Product);
        }
    }
}
