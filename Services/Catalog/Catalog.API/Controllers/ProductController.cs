using Catalog.API.Controller;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    
    public class ProductController : ApiController
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetProducts()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductResponse>> GetProductById(string id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("brands")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<BrandResponse>>> GetBrands()
        {
            var query = new GetAllBrandsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("types")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<TypeResponse>>> GetTypes()
        {
            var query = new GetAllTypesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
