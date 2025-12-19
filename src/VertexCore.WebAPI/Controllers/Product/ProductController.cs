using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VertexCore.Application.Commands.Product;
using VertexCore.WebAPI.Extensions;

namespace VertexCore.WebAPI.Controllers.Product
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }
        [HttpPut("update")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }
        [HttpDelete("delete")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();

        }
        [HttpGet("getproducts")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAllProducts()
        {
            var command = new Application.Queries.Product.GetAllProductsCommand();
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }
        [HttpGet("getproductbyid/{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id)
        {
            var command = new Application.Queries.Product.GetProductByIdProductCommand { Id = id };
            var result = await _mediator.Send(command);
            return result.ToActionResult();

        }
    }
}
