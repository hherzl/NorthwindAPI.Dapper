using System.Linq;
using System.Threading.Tasks;
using NorthwindApi.Dapper.Controllers;
using Xunit;

namespace NorthwindApi.Dapper.Tests
{
    public class NorthwindControllerTests
    {
        [Fact]
        public async Task TestGetProductsAsync()
        {
            // Arrange
            var logger = LoggerMocker.GetLogger<NorthwindController>();
            var repository = RepositoryMocker.GetNorthwindRepository();
            var controller = new NorthwindController(logger, repository);

            // Act
            var response = await controller.GetProductsAsync();

            // Asert
            Assert.True(response.Model.Count() > 0);
        }

        [Fact]
        public async Task TestGetProductAsync()
        {
            // Arrange
            var logger = LoggerMocker.GetLogger<NorthwindController>();
            var repository = RepositoryMocker.GetNorthwindRepository();
            var controller = new NorthwindController(logger, repository);
            var request = 10;

            // Act
            var response = await controller.GetProductAsync(request);

            // Asert
            Assert.True(response.Model != null);
        }

        [Fact]
        public async Task TestGetNonExistingProductAsync()
        {
            // Arrange
            var logger = LoggerMocker.GetLogger<NorthwindController>();
            var repository = RepositoryMocker.GetNorthwindRepository();
            var controller = new NorthwindController(logger, repository);
            var request = 0;

            // Act
            var response = await controller.GetProductAsync(request);

            // Asert
            Assert.True(response.Model == null);
        }
    }
}
