using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HiringProject.Api.Modules
{
    public static class ServiceModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
