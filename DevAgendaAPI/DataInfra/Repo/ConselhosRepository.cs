using Domain.Commom;
using Domain.Interfaces;
using Domain.ViewModel;

namespace DataInfra.Repo
{
    public class ConselhosRepository : IConselhosRepository
    {
        public async Task<bool> SaveConselhos(Response<ConselhosViewModel> data)
        {
            return await Task.FromResult(true);
        }
    }
}
