using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using VertexCore.Application.Commands.Product;
using MediatR;
using VertexCore.WebAPI.Controllers.Product;
using VertexCore.Application.Common.Models;

namespace VertexCore.WebAPI.UnitTests
{
    public class ProductControllerUnitTests
    {
        [Fact]
        public async Task CreateProduct_ReturnsSuccess_WhenMediatorReturnsSuccess()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<CreateProductCommand>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(Result.Success("ok"));

            var controller = new ProductController(mediatorMock.Object);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity("TestAuth"))
                }
            };

            var command = new CreateProductCommand { Name = "p", Price = 1m, IsActive = true };
            var response = await controller.CreateProduct(command);

            var objectResult = Assert.IsType<ObjectResult>(response);
            Assert.Equal(200, objectResult.StatusCode);
        }
    }
}
