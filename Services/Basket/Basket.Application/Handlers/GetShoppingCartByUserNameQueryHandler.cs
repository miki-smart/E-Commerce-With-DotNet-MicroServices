using Basket.Application.Mappers;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Handlers
{
    public class GetShoppingCartByUserNameQueryHandler:IRequestHandler<GetShoppingCartByUserNameQuery, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRespository;
        public GetShoppingCartByUserNameQueryHandler(IBasketRepository basketRespository)
        {
            _basketRespository = basketRespository;
        }
        public async Task<ShoppingCartResponse> Handle(GetShoppingCartByUserNameQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketRespository.GetBasket(request.UserName);
            return ShoppingCartMapper.MapperExt.Map<ShoppingCart,ShoppingCartResponse>(basket);
        }
    }
}
