using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace HiringProject.Api.Modules
{
    public static class SwaggerModule
    {
        private static readonly Assembly assembly;

        static SwaggerModule()
        {
            assembly = Assembly.GetExecutingAssembly();
        }

        public static IServiceCollection AddSwaggers(this IServiceCollection services, IWebHostEnvironment environment)
        {
            var headerSuffix = environment.IsProduction() ? "" : environment.EnvironmentName;

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"{assembly.GetName().Name} v{assembly.GetName().Version} {headerSuffix}",
                    Version = "v1",
                    Description = assembly.GetCustomAttributes<AssemblyDescriptionAttribute>().FirstOrDefault()?.Description,
                    Contact = new OpenApiContact
                    {
                        Name = "Paþa Yazýcý",
                        Email = "pasayazici@hotmail.com"
                    }
                });

                options.ExampleFilters();
                options.OperationFilter<AddResponseHeadersFilter>();

                var xmlFile = $"{assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath, true);
            });
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

            return services;
        }
        public static IApplicationBuilder UseSwaggers(this IApplicationBuilder app)
        {
            app.UseSwagger(c => c.SerializeAsV2 = true);
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", $"{assembly.GetName().Name} v{assembly.GetName().Version}");
            });

            return app;
        }
    }
}
