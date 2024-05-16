using Catalog.API.Controller;
using Catalog.Application.Command;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.SpecParams;
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
        [ProducesResponseType(typeof(Pagination<ProductResponse>),StatusCodes.Status200OK)]
        public async Task<ActionResult<Pagination<ProductResponse>>> GetProducts([FromQuery] CatalogSpecParams catalogSpecParams)
        {
            var query = new GetAllProductsQuery(catalogSpecParams);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductResponse>> GetProductById(string id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("brands")]
        [ProducesResponseType(typeof(IList<BrandResponse>),StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<BrandResponse>>> GetBrands()
        {
            var query = new GetAllBrandsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("types")]
        [ProducesResponseType(typeof(IList<TypeResponse>),StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<TypeResponse>>> GetTypes()
        {
            var query = new GetAllTypesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost("create-product")]
        [ProducesResponseType(typeof(ProductResponse),StatusCodes.Status201Created)]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand createProductCommand)
        {
            var result = await _mediator.Send(createProductCommand);
            return CreatedAtAction(nameof(GetProductById), new { id = result.Id }, result);
        }
        [HttpPost("delete-product")]

        [ProducesResponseType(typeof(bool),StatusCodes.Status204NoContent)]
        public async Task<ActionResult<bool>> DeleteProduct([FromQuery] string id)
        {
            var query = new DeleteProductByIdQuery(id);
            var result = await _mediator.Send(query);
            return NoContent();
        }
        [HttpPut("update-product")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
        public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand)
        {
            var result = await _mediator.Send(updateProductCommand);
            return NoContent();
        }
    }
}
