using System.Collections.Generic;
using System.Linq;

namespace Dasigno.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool HasValues<T>(this IEnumerable<T> items)
        {
            return items?.Any() ?? false;
        }
    }
}
