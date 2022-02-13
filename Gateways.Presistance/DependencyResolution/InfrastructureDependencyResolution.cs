using Gateways.Ground;
using Gateways.Service.DependencyResolution;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Presistance.DependencyResolution
{
    public static class InfrastructureDependencyResolution
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var interfaceAssembly = typeof(CoreDependencyResolution).Assembly;
            var implementationAssembly = typeof(InfrastructureDependencyResolution).Assembly;

            //inject by convention
            services.AddTransientByConvention(interfaceAssembly, implementationAssembly, x => x.Name.EndsWith("Factory"));
            services.AddTransientByConvention(interfaceAssembly, implementationAssembly, x => x.Name.EndsWith("Repository"));
            services.AddTransientByConvention(interfaceAssembly, implementationAssembly, x => x.Name.EndsWith("Validator"));

            return services;
        }
    }
}
