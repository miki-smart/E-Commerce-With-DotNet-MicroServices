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
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            var checktype = productCollection.Find(p => true).Any();
            string path = Path.Combine("Data", "SeedData", "products.json");
            if (!checktype)
            {
                var types = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(path));

                foreach (var item in types)
                {
                    productCollection.InsertOne(item);
                }
            }
        }
    }
}
