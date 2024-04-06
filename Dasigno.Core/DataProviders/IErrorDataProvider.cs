using Dasigno.Core.Models.StaticModel;
using System.Threading.Tasks;

namespace Dasigno.Core.DataProviders
{
    public interface IErrorDataProvider : IDataProvider
    {
        Task<bool> CreateErrorAsync(ErrorModel error);
    }
}
