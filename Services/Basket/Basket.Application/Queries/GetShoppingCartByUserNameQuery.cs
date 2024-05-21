using Basket.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Queries
{
    public class GetShoppingCartByUserNameQuery:IRequest<ShoppingCartResponse>
    {
        public string UserName { get; set; }
        public GetShoppingCartByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
