﻿


using Basket.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Commands
{
    public class RemoveShoppingCartByUserNameCommand:IRequest<Unit>
    {
        public string UserName { get; set; }
        public RemoveShoppingCartByUserNameCommand(string userName)
        {
            UserName = userName;
        }
    }
}
