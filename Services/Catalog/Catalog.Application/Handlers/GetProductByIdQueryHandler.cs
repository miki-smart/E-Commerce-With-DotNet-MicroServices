using Catalog.Application.Mappers;
using Catalog.Application.Queries;
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
    public class GetProductByIdQueryHandler:IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly ICatalogRepository _catalogRepository;
        public GetProductByIdQueryHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product=await _catalogRepository.GetProduct(request.Id);
            if (product == null)
            {
                throw new ApplicationException("Product not found.");
            }
            return ProductMapper.MapperExt.Map<Product, ProductResponse>(product);
        }
    }
}
