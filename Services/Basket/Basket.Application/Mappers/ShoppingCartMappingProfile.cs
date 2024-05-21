using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Mappers
{
    public class ShoppingCartMappingProfile:Profile
    {
        public ShoppingCartMappingProfile()
        {
            CreateMap<Core.Entities.ShoppingCart, Responses.ShoppingCartResponse>().ReverseMap();
            CreateMap<Core.Entities.ShoppingCartItem, Responses.ShoppingCartItemResponse>().ReverseMap();
        }
    }
}
