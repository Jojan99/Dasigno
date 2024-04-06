using Dasigno.Core;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Dasigno.Api.Controllers
{
    public class BaseController : ApiController, IDisposable
    {
        #region [ Properties ]

        protected internal IDomainManager DomainManager { get; }

        #endregion

        #region [ Constructor ]

        public BaseController()
        {
            DomainManager = new DomainManager();
        }

        #endregion

        #region [ Methods ]

        protected async Task<V> ExecuteDomainServiceAsync<T, V>(Func<T, Task<V>> serviceMethodAsync) where T : class, IDomain
        {
            try
            {
                T domainProxy = DomainManager.CreateProxy<T>();
                return await serviceMethodAsync(domainProxy);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public new void Dispose()
        {
            DomainManager?.Dispose();
        }

        #endregion
    }
}