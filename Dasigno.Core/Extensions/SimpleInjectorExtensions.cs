using Dasigno.Core.Managers;
using Dasigno.Core.Managers.Implementation;
using Npgsql;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace Dasigno.Core.Extensions
{
    public static class SimpleInjectorExtensions
    {
        public static void RegisterAllServiceTypeImplementations<T>(this Container container, IEnumerable<Assembly> assemblies)
        {
            Type typeFromHandle = typeof(T);
            RegisterAllServiceTypeImplementations(container, typeFromHandle, assemblies);
        }

        public static void RegisterAllServiceTypeImplementations(this Container container, Type type, IEnumerable<Assembly> assemblies)
        {

            foreach (Tuple<Type, Type> item in GetAllToRegisterFromType(type, assemblies))
            {
                container.Register(item.Item2, item.Item1);
            }



            container.Register<IDBContextManager>(() =>
            {
                var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                return new DBContextManager(connection);
            });

        }

        private static IEnumerable<Tuple<Type, Type>> GetAllToRegisterFromType(Type type, IEnumerable<Assembly> assemblies)
        {
            if (!assemblies.HasValues())
            {
                return Enumerable.Empty<Tuple<Type, Type>>();
            }
            return from t in GetAllTypesInAssemblies(assemblies)
                   where !t.IsInterface && (from i in t.GetInterfaces()
                                            where i.IsAssignableFrom(type)
                                            select i).Any()
                   select new Tuple<Type, Type>(t, t.GetInterfaces().FirstOrDefault((Type i) => !i.Equals(type) && type.IsAssignableFrom(i))) into x
                   where x.Item2 != null
                   select x;
        }

        private static IEnumerable<Type> GetAllTypesInAssemblies(IEnumerable<Assembly> assemblies)
        {
            return assemblies.SelectMany(delegate (Assembly x)
            {
                IEnumerable<Type> result = Enumerable.Empty<Type>();
                try
                {
                    result = x.GetTypes();
                    return result;
                }
                catch
                {
                    return result;
                }
            });
        }
    }
}
