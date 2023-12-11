using Domain.Commom;
using Domain.ViewModel;

namespace Application.Services.Interfaces
{
    public interface IConselhosAppService
    {
        Task<Response<ConselhosViewModel>> GetConselhos();
        int GetRandomNumber(int min, int max);
    }
}
