using AuthApi.Helpers;
using DataService.Models;
using DataService.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AuthApiTest
{
    public class LoginServiceTest
    {
        private Mock<IEmployeeLoginRepository> _mockDbService;
        private Mock<IConfiguration> _config;
        private Mock<ILogger<TokenGeneration>> _logger;
        private TokenGeneration _uut;

        public LoginServiceTest()
        {
            _mockDbService = new Mock<IEmployeeLoginRepository>();
            _config = new Mock<IConfiguration>();
            _logger = new Mock<ILogger<TokenGeneration>>();
        }

        private void CreateService()
        {
            _uut = new TokenGeneration(_config.Object, _logger.Object, _mockDbService.Object);
        }

        [Fact]
        public async void LoginTest()
        {
            // GIVEN
            CreateService();

            // WHEN
            var result = await _uut.Validate("test","test");

            // THEN
            Assert.Empty(result);
        }
    }
}