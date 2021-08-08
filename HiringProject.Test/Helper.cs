using HiringProject.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace HiringProject.Test
{
    public static class Helper
    {
        public static IHost CreateHost()
        {
            var hostBuilder = new HostBuilder()
               .ConfigureWebHost(webHost =>
               {
                   var environment = "Test";
                   webHost.UseEnvironment(environment);
                   webHost.UseTestServer();

                   var integrationConfig = new ConfigurationBuilder()
                     .AddJsonFile($"appsettings.{environment}.json")
                     .Build();

                   webHost.UseConfiguration(integrationConfig);

                   webHost.UseStartup<Startup>();
               });

            return hostBuilder.StartAsync().GetAwaiter().GetResult();
        }
    }
}
