using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Product { get; }
        IMongoCollection<ProductBrand> ProductBrand { get; }
        IMongoCollection<ProductType> ProductType { get; }
    }
}
