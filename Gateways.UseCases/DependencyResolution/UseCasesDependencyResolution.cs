using FluentValidation;
using Gateways.UseCases.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Gateways.UseCases.DependencyResolution
{
    public static class UseCasesDependencyResolution
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(executingAssembly);
            services.AddValidatorsFromAssembly(executingAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
