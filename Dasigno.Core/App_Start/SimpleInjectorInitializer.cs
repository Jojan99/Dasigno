using Dasigno.Core.Extensions;
using SimpleInjector;
using System.Collections.Generic;
using System.Reflection;

namespace Dasigno.Core.App_Start
{
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        private static IEnumerable<Assembly> Assemblies { get; } = new Assembly[] { Assembly.GetExecutingAssembly() };

        internal static void RegisterCore(this Container container)
        {
            container.RegisterAllServiceTypeImplementations<IInjectable>(Assemblies);
        }



    }
}
