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
    public class GetAllProductsHandler:IRequestHandler<GetAllProductsQuery,IList<ProductResponse>>
    {
        private readonly ICatalogRepository _productRepository;
        public GetAllProductsHandler(ICatalogRepository productRepository)
        {
                _productRepository = productRepository;
        }
        public async Task<IList<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products= await _productRepository.GetProducts();
            return ProductMapper.MapperExt.Map<IList<Product>,IList<ProductResponse>>(products.ToList());
        }
    }
}
