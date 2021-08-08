using System;
using System.Reflection;
using HiringProject.Api.Settings;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace HiringProject.Api.Modules
{
    public static class ServiceModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //configuration.GetSection(nameof(MongoDbConnection).Get<MongoDbConnection>();
            services.AddMediatR(typeof(Startup));
            //var assembly = AppDomain.CurrentDomain.Load("Project.Core");
            //services.AddMediatR(assembly);

            return services;
        }
    }
}
