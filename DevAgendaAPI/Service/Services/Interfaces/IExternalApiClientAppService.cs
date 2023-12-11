namespace Application.Services.Interfaces
{
    public interface IExternalApiClientAppService
    {
        Task<string> GetResquest(string url);
    }
}
