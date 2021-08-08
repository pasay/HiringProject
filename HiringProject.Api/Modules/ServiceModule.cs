using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HiringProject.Api.Modules
{
    public static class ServiceModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Startup));
            var assembly = AppDomain.CurrentDomain.Load("HiringProject.Business");
            services.AddMediatR(assembly);


            return services;
        }
    }
}
