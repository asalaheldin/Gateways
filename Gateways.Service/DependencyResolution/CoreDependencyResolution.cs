using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Service.DependencyResolution
{
    public static class CoreDependencyResolution
    {
        public static IServiceCollection AddCoreService(this IServiceCollection services)
        {            
            return services;
        }
    }
}
