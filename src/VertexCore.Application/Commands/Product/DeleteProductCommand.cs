using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Product
{
    public class DeleteProductCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Check if the product exists before attempting delete
                var exists = await _productService.ExistsAsync(request.Id, cancellationToken);
                if (!exists)
                {
                    return Result.Failure("DeleteProductFailed", "Product not found");
                }

                await _productService.DeleteAsync(request.Id, cancellationToken);

                return Result.Success("Product deleted successfully");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to delete product");
            }
        }
    }
}

