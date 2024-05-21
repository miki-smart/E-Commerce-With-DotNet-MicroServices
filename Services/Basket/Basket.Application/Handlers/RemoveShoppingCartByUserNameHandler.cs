using Basket.Application.Commands;
using Basket.Application.Responses;
using Basket.Core.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Handlers
{
    public class RemoveShoppingCartByUserNameHandler:IRequestHandler<RemoveShoppingCartByUserNameCommand>
    {
        private readonly IBasketRepository _basketRespository;
        public RemoveShoppingCartByUserNameHandler(IBasketRepository basketRespository)
        {
            _basketRespository = basketRespository;
        }
        public async Task<Unit> Handle(RemoveShoppingCartByUserNameCommand request, CancellationToken cancellationToken)
        {
            await _basketRespository.DeleteBasket(request.UserName);
            return Unit.Value;

        }
    }
}
