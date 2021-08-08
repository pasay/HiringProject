using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HiringProject.Api.Settings;

namespace HiringProject.Api.Modules
{
    public static class SettingModule
    {
        public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)))
                .Configure<MongoDbConnectionSettings>(configuration.GetSection(nameof(MongoDbConnectionSettings)))
                ;
        }
    }
}
