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
    public class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> typeCollection)
        {
            var checktype = typeCollection.Find(p => true).Any();
            string path = "../Catalog.Infrastructure/Data/SeedData/types.json";
            if (!checktype)
            {
                var types = JsonSerializer.Deserialize<List<ProductType>>(File.ReadAllText(path));

                foreach (var item in types)
                {
                    typeCollection.InsertOne(item);
                }
            }
        }
    }
}
