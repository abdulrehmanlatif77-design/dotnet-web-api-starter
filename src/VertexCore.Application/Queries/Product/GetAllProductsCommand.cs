using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;
using ProductEntity = VertexCore.Domain.Entities.Product;

namespace VertexCore.Application.Queries.Product
{
    public class GetAllProductsCommand : IRequest<Result<IEnumerable<ProductEntity>>>
    {

    }
    public class GetAllProductsCommandHandler : IRequestHandler<GetAllProductsCommand, Result<IEnumerable<ProductEntity>>>
    {
        private readonly IProductService _productService;
        public GetAllProductsCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Result<IEnumerable<ProductEntity>>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productService.GetAllAsync(cancellationToken);
                return Result<IEnumerable<ProductEntity>>.Success(products);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<ProductEntity>>.Failure(ex, ex.Message);
            }

        }
    }
}
