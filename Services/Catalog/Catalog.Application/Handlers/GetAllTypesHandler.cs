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
    public class GetAllTypesHandler:IRequestHandler<GetAllTypesQuery,IList<TypeResponse>>
    {
        private readonly ICatalogRepository _catalogRepository;
        public GetAllTypesHandler(ICatalogRepository catalogRepository)
        {

            _catalogRepository = catalogRepository;

        }
        public async Task<IList<TypeResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var types = await _catalogRepository.GetProductTypes();
            var result = ProductMapper.MapperExt.Map<IList<ProductType>, IList<TypeResponse>>(types.ToList());
            return result;
        }
    }
}
