using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;
using ProductEntity = VertexCore.Domain.Entities.Product;
namespace VertexCore.Application.Queries.Product
{
    public class GetProductByIdProductCommand : IRequest<Result<ProductEntity>>
    {
        public Guid Id { get; set; }
    }
    public class GetProductByIdProductCommandHandler : IRequestHandler<GetProductByIdProductCommand, Result<ProductEntity>>
    {
        private readonly IProductService _productService;
        public GetProductByIdProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Result<ProductEntity>> Handle(GetProductByIdProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productService.GetByIdAsync(request.Id, cancellationToken);
                if (product == null)
                {
                    return Result<ProductEntity>.Failure("NOT_FOUND", "Product not found.");
                }
                return Result<ProductEntity>.Success(product);
            }
            catch (Exception ex)
            {
                return Result<ProductEntity>.Failure(ex, ex.Message);
            }
        }
    }
}
