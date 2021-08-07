using System.Collections.Generic;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace HiringProject.Api.Modules
{
    public static class MapperModule
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddSingleton<TypeAdapterConfig, Maps>();
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }

    public class Maps : TypeAdapterConfig
    {
        public Maps()
        {

        }
    }
}
