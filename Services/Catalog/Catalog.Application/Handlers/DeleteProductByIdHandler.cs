using Catalog.Application.Queries;
using Catalog.Core.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class DeleteProductByIdHandler : IRequestHandler<DeleteProductByIdQuery, bool>
    {
        private readonly ICatalogRepository _productRepository;

        public DeleteProductByIdHandler(ICatalogRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(DeleteProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.Delete(request.Id);
        }
        }
    }
