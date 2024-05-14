using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
    public class GetProductByType : IRequest<IList<ProductResponse>>
    {
        public string Type { get; set; }
    }
}
