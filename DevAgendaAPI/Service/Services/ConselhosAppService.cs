using Application.Services.Interfaces;
using Domain.Commom;
using Domain.Interfaces;
using Domain.ViewModel;
using System.Text.Json;

namespace Application.Services
{
    public class ConselhosAppService : IConselhosAppService
    {
        private readonly IExternalApiClientAppService _externalApiClientAppService;
        private readonly IConselhosRepository _conselhosRepository;
        public ConselhosAppService(IExternalApiClientAppService externalApiClientAppService, IConselhosRepository conselhosRepository)
        {
            _externalApiClientAppService = externalApiClientAppService;
            _conselhosRepository = conselhosRepository;
        }

        public async Task<Response<ConselhosViewModel>> GetConselhos()
        {

            var result = JsonSerializer.Deserialize<ConselhosViewModel>(await _externalApiClientAppService.GetResquest("https://api.adviceslip.com/advice"));
            var response = new Response<ConselhosViewModel>()
            {
                Data = result ?? new(),
                NumeroDaSorte = GetRandomNumber(1, 100)
            };

            await _conselhosRepository.SaveConselhos(response);

            return response;

        }

        public int GetRandomNumber(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }
}
