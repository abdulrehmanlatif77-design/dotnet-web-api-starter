using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Product
{
    public class UpdateProductCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public required string Name { get; set; } // Name of the product
        public string? Description { get; set; } // Description of the product
        public decimal Price { get; set; } // Price of the product
        public bool IsActive { get; set; } // Indicates if the product is active, true if available for sale
    }

    // Create the update handler

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result>
    {
        private readonly IProductService _productService;
        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        // Handler implementation goes here
        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Implementation for updating a product
                var product = new VertexCore.Domain.Entities.Product
                {
                    Id = request.Id,
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    IsActive = request.IsActive,
                };
                await _productService.UpdateAsync(product, cancellationToken);
                return Result.Success("Product updated successfully.");
            }
            catch (KeyNotFoundException knfEx)
            {
                return Result.Failure("ProductNotFound", knfEx.Message);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to update product.");
            }
        }
    }
}
