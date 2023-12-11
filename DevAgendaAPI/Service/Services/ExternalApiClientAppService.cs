using Application.Services.Interfaces;

namespace Application.Services
{
    public class ExternalApiClientAppService : IExternalApiClientAppService
    {
        public ExternalApiClientAppService()
        {

        }

        public async Task<string> GetResquest(string url)
        {
            HttpClient httpclient = new();

            var response = await httpclient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }

    }
}
