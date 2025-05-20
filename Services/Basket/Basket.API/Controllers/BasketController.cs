using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Basket.Core.Repository;
using AutoMapper;
using MediatR;
using Basket.Application.Responses;
using Basket.Application.Queries;
using Basket.Application.Commands;
using Basket.Core.Entities;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseController
    {
        private readonly IMediator _mediator;
        public BasketController(IMediator mediator)
        {
            _mediator = mediator; 
        }
        [HttpGet("{userName}")]
        [ProducesResponseType(typeof(ShoppingCartResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCartResponse>> GetBasket(string userName)
        {
            var basket = await _mediator.Send(new GetShoppingCartByUserNameQuery(userName));
            return Ok(basket);
        }
        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCartResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCartResponse>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            var updatedBasket = await _mediator.Send(new CreateShoppingCartCommand(basket.UserName,basket.Items));
            return Ok(updatedBasket);
        }
        [HttpDelete("{userName}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteBasket(string userName)
        {
            await _mediator.Send(new RemoveShoppingCartByUserNameCommand(userName));
            return NoContent();
        }

    }
}
