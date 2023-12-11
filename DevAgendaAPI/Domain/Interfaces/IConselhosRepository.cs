using Domain.Commom;
using Domain.ViewModel;

namespace Domain.Interfaces
{
    public interface IConselhosRepository
    {
        Task<bool> SaveConselhos(Response<ConselhosViewModel> data);
    }
}
