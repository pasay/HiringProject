using HiringProject.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace HiringProject.Test
{
    public static class Helper
    {
        public static IHost CreateHost(Action<IServiceCollection> mockServicesConfiguration)
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

                   webHost.UseStartup<Startup>().ConfigureTestServices(mockServicesConfiguration);
               });

            return hostBuilder.StartAsync().GetAwaiter().GetResult();
        }
    }
}
