using Basket.Application.Commands;
using Basket.Application.Mappers;
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
    public class CreateShoppingCartHandler:IRequestHandler<CreateShoppingCartCommand, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRespository;
        public CreateShoppingCartHandler(IBasketRepository basketRespository)
        {
            _basketRespository = basketRespository;
        }
        public async Task<ShoppingCartResponse> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
           
            
          var basket=  await _basketRespository.UpdateBasket(new ShoppingCart(request.UserName,request.Items));
            return ShoppingCartMapper.MapperExt.Map<ShoppingCartResponse>(basket);
        }
    }
}
