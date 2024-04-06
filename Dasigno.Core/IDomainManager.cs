using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dasigno.Core
{
    public interface IDomainManager : IDisposable
    {
        T CreateProxy<T>() where T : class, IDomain;
    }
}
