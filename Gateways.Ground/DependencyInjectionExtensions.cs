using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Gateways.Ground
{
    public static class InfrastructureDependencyResolution
    {
        public static IServiceCollection AddTransientByConvention(this IServiceCollection services, Assembly interfaceAssembly, Assembly implementationAssembly, Func<Type, bool> interfacePredicate, Func<Type, bool> implementationPredicate)
        {
            var interfaces = interfaceAssembly.ExportedTypes
                .Where(x => (x.IsInterface || x.IsAbstract) && interfacePredicate(x))
                .ToList();
            var implementations = implementationAssembly.ExportedTypes
                .Where(x => !x.IsInterface && !x.IsAbstract && implementationPredicate(x))
                .ToList();
            foreach (var @interface in interfaces)
            {
                var registeredImplementations = implementations.Where(x => @interface.IsAssignableFrom(x))
                    .ToList();
                if (registeredImplementations == null || registeredImplementations.Count <= 0) continue;

                foreach (var implementation in registeredImplementations)
                    services.AddTransient(@interface, implementation);
            }
            return services;
        }

        public static IServiceCollection AddTransientByConvention(this IServiceCollection services, Assembly assembly, Func<Type, bool> predicate)
            => services.AddTransientByConvention(assembly, assembly, predicate, predicate);
        public static IServiceCollection AddTransientByConvention(this IServiceCollection services, Assembly interfaceAssembly, Assembly implementationAssembly, Func<Type, bool> predicate)
            => services.AddTransientByConvention(interfaceAssembly, implementationAssembly, predicate, predicate);
    }
}
