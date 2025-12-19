using Moq;
using VertexCore.Application.Commands.Product;
using VertexCore.Infrastructure.Interfaces.Services;

namespace Vertex.Application.Tests.Product
{
    public class ProductCommandHandlerTests
    {
        private readonly Mock<IProductService> _productServiceMock;
        private readonly CreateProductCommandHandler _handler;

        public ProductCommandHandlerTests()
        {
            _productServiceMock = new Mock<IProductService>();
            _handler = new CreateProductCommandHandler(_productServiceMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateProductSuccessfully()
        {
            // Arrange
            var command = new CreateProductCommand
            {
                Name = "Test Product",
                Description = "Test Description",
                Price = 99.99m,
                IsActive = true
            };
            _productServiceMock
                .Setup(service => service.CreateAsync(It.IsAny<VertexCore.Domain.Entities.Product>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new VertexCore.Domain.Entities.Product { Id = Guid.NewGuid(), Name = "Test Product" });
            // Act
            var result = await _handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("Product created successfully.", result.Message);
        }
    }
}
