using Dasigno.Core.Models.StaticModel;
using System.Threading.Tasks;

namespace Dasigno.Core.Repositories
{
    public interface IErrorReporitory : IRepository
    {
        Task<bool> CreateErrorAsync(ErrorModel error);
    }
}
