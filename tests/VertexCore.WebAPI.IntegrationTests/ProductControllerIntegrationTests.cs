using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace VertexCore.WebAPI.IntegrationTests
{
    public class ProductControllerIntegrationTests : IClassFixture<CustomWebAppFactory<Program>>
    {
        private readonly CustomWebAppFactory<Program> _factory;

        public ProductControllerIntegrationTests(CustomWebAppFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CreateProduct_ReturnsSuccess()
        {
            var client = _factory.CreateClient();
            var command = new { Name = "Test", Description = "desc", Price = 1.0m, IsActive = true };
            var response = await client.PostAsJsonAsync("/api/v1/Product/create", command);
            response.EnsureSuccessStatusCode();
        }
    }
}
