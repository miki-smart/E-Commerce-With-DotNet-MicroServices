using Catalog.Application.Command;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class CreateProductCommandHandler:IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly ICatalogRepository _productRepository;
        public CreateProductCommandHandler(ICatalogRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                ImageFile = request.ImageFile,
                Brands= request.Brands,
                Types = request.Types
            };
            var result = await _productRepository.Create(product);
            
            return ProductMapper.MapperExt.Map<Product,ProductResponse>(result);
        }
    }
}
