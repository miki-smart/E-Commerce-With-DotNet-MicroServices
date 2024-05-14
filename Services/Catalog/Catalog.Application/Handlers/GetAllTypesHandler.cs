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
        private readonly ITypeRepository _typeRepository;
        public GetAllTypesHandler(ITypeRepository typeRepository)
        {

            _typeRepository = typeRepository;

        }
        public async Task<IList<TypeResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var types = await _typeRepository.GetProductTypes();
            var result = ProductMapper.MapperExt.Map<IList<ProductType>, IList<TypeResponse>>(types.ToList());
            return result;
        }
    }
}
