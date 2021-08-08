using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HiringProject.Api.Modules
{
    public static class ServiceModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Startup));
            //var assembly = AppDomain.CurrentDomain.Load("Project.Core");
            //services.AddMediatR(assembly);

            return services;
        }
    }
}
