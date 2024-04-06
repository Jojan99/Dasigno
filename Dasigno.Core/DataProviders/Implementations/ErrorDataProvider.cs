using Dasigno.Core.Models.StaticModel;
using Dasigno.Core.Repositories;
using System.Threading.Tasks;

namespace Dasigno.Core.DataProviders.Implementations
{
    internal class ErrorDataProvider : IErrorDataProvider
    {
        protected IErrorReporitory ErrorReporitory { get; }

        public ErrorDataProvider(IErrorReporitory errorReporitory)
        {
            ErrorReporitory = errorReporitory;
        }

        public Task<bool> CreateErrorAsync(ErrorModel error)
        {
            return ErrorReporitory.CreateErrorAsync(error);
        }
    }
}
