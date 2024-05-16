using Amazon.Runtime.Internal;
using AutoMapper;
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
    public class GeAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IList<BrandResponse>>
    {
        private readonly ICatalogRepository _catalogRepository;
        public GeAllBrandsHandler(ICatalogRepository catalogRepository)
        {

            _catalogRepository = catalogRepository;

        }
        public async Task<IList<BrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _catalogRepository.GetProductBrands();   
            var result =ProductMapper.MapperExt.Map<IList<ProductBrand>,IList<BrandResponse>>(brands.ToList());
            return result;
        }
    }
}
