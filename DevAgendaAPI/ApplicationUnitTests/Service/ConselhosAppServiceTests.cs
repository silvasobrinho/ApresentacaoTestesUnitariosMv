using Application.Services;
using Application.Services.Interfaces;
using Domain.Commom;
using Domain.Interfaces;
using Domain.ViewModel;
using Moq;
using Xunit;

namespace ApplicationUnitTests.Service
{
    public class ConselhosAppServiceTests
    {
        private readonly Mock<IExternalApiClientAppService> _externalApiClientAppService;
        private readonly Mock<IConselhosRepository> _conselhosRepository;
        public ConselhosAppServiceTests()
        {
            _externalApiClientAppService = new Mock<IExternalApiClientAppService>();
            _conselhosRepository = new Mock<IConselhosRepository>();

            _conselhosRepository.Setup(x => x.SaveConselhos(It.IsAny<Response<ConselhosViewModel>>())).ReturnsAsync(true);
        }

        [Fact]
        public async void DeveRetonarConselhos()
        {
            // Arrange
            string requestResult = @"{""slip"": { ""id"": 99, ""advice"": ""Um homem hidratado não quer guerra com ninguém""}}";
            _externalApiClientAppService.Setup(x => x.GetResquest(It.IsAny<string>())).ReturnsAsync(requestResult);
            var conselhosAppService = new ConselhosAppService(_externalApiClientAppService.Object, _conselhosRepository.Object);

            // Act
            var result = await conselhosAppService.GetConselhos();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.NumeroDaSorte > 0);
            Assert.True(result.Data is not null);
        }
        
        
        [Fact]
        public async void DeveRetonarExceptionJsonSerializeConselhos()
        {
            _externalApiClientAppService.Setup(x => x.GetResquest(It.IsAny<string>())).ReturnsAsync("");
            var conselhosAppService = new ConselhosAppService(_externalApiClientAppService.Object, _conselhosRepository.Object);

            var result =  conselhosAppService.GetConselhos();

            await Assert.ThrowsAsync<System.Text.Json.JsonException>(async () => await  result);
        }

        [Theory]
        [InlineData(10, 120, 0)]
        [InlineData(20, 111, 0)]
        [InlineData(21, 100, 0)]
        [InlineData(22, 41, 0)]
        [InlineData(23, 762, 0)]
        [InlineData(55, 222, 0)]
        [InlineData(51, 73, 0)]
        [InlineData(522, 664, 0)]
        public void PowerOfTest(int inicial, int final, int expected)
        {
            var conselhosAppService = new ConselhosAppService(_externalApiClientAppService.Object, _conselhosRepository.Object);


            var result = conselhosAppService.GetRandomNumber(inicial, final);

            Assert.True(expected < result);
        }
    }
}
