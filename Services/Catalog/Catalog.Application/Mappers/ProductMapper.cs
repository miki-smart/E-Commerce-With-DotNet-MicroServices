using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mappers
{
    public class ProductMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
                   {
                       var config = new MapperConfiguration(cfg =>
                       {
                           cfg.ShouldMapField = p => p.IsPublic && p.IsAssembly;
                           cfg.AddProfile<ProductMappingProfile>();
                       });
                       var mapper = config.CreateMapper();
                       return mapper;
                   });
    
        public static IMapper MapperExt => Lazy.Value;

                        
    }
}
