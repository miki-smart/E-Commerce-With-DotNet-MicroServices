using Catalog.Application.Responses;
using Catalog.Core.SpecParams;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
    public class GetAllProductsQuery:IRequest<Pagination<ProductResponse>>
    {
        public readonly CatalogSpecParams _catalogSpecParams;
        public GetAllProductsQuery(CatalogSpecParams catalogSpecParams)
        {
            _catalogSpecParams = catalogSpecParams;
        }
    }
}
