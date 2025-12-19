using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Product
{
    public class CreateProductCommand : IRequest<Result>
    {
        public required string Name { get; set; } // Name of the product
        public string? Description { get; set; } // Description of the product
        public decimal Price { get; set; } // Price of the product
        public bool IsActive { get; set; } // Indicates if the product is active, true if available for sale
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        // Handler implementation goes here
        public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Implementation for creating a product
                var product = new VertexCore.Domain.Entities.Product
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    IsActive = request.IsActive,
                };

                var result = await _productService.CreateAsync(product, cancellationToken);

                if (result == null)
                {
                    return Result.Failure("ProductCreationFailed", "Failed to create product.");
                }
                return Result.Success("Product created successfully.");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to create product.");
            }
        }
    }
}
