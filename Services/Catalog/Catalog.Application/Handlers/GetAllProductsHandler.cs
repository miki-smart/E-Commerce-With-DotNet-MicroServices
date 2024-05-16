using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repository;
using Catalog.Core.SpecParams;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class GetAllProductsHandler:IRequestHandler<GetAllProductsQuery, Pagination<ProductResponse>>
    {
        private readonly ICatalogRepository _productRepository;
        public GetAllProductsHandler(ICatalogRepository productRepository)
        {
                _productRepository = productRepository;
        }
        public async Task<Pagination<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products= await _productRepository.GetProducts(request._catalogSpecParams);
            return ProductMapper.MapperExt.Map<Pagination<Product>, Pagination<ProductResponse>>(products);
        }
    }
}
