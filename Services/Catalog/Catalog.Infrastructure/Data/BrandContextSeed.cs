using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data
{
    public class BrandContextSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
        {
            var checkbrand= brandCollection.Find(p => true).Any();
            string path = Path.Combine("Data", "SeedData", "brands.json");
            if (!checkbrand)
            {
                var brands=JsonSerializer.Deserialize<List<ProductBrand>>(File.ReadAllText(path));

                foreach (var item in brands)
                {
                    brandCollection.InsertOne(item);
                }
            }
        }
    }
}
