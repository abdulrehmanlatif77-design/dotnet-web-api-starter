using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Domain.DTOs.Product;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Queries.Product
{
    public class GetAllProductsCommand : IRequest<Result<IEnumerable<GetAllProductsDto>>>
    {

    }

    public class GetAllProductsCommandHandler : IRequestHandler<GetAllProductsCommand, Result<IEnumerable<GetAllProductsDto>>>
    {
        private readonly IProductService _productService;
        public GetAllProductsCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Result<IEnumerable<GetAllProductsDto>>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productService.GetAllAsync(cancellationToken);
                var productDtos = products.Select(p => new GetAllProductsDto
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    IsActive = p.IsActive
                }).ToList();

                return Result<IEnumerable<GetAllProductsDto>>.Success(productDtos);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<GetAllProductsDto>>.Failure(ex, ex.Message);
            }

        }
    }
}
