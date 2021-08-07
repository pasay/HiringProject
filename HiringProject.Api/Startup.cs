using FluentValidation.AspNetCore;
using HiringProject.Api.Middlewares;
using HiringProject.Api.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HiringProject.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            WebHostEnvironment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.AllowEmptyInputInBodyModelBinding = true;
                options.EnableEndpointRouting = false;
            })
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddControllers().AddNewtonsoftJson(p => p.SerializerSettings.Converters.Add(new StringEnumConverter()));
            services.AddHealthChecks();
            services.AddLogging(logBuilder =>
            {
                logBuilder.ClearProviders();
                logBuilder.AddConsole();
            });

            services.AddRequestLoggerMiddleware()
                    .AddResponseLoggerMiddleware()
                    .AddErrorHandlingMiddleware()
                    ;

            services.AddSettings(Configuration)
                    .AddServices(Configuration)
                    .AddValidations()
                    .AddMappers()
                    .AddSwaggers(WebHostEnvironment);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseRequestLoggerMiddleware()
               .UseResponseLoggerMiddleware()
               .UseErrorHandlingMiddleware();

            app.UseSwaggers();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            Console.WriteLine($"{typeof(Startup).Namespace} running on {env.EnvironmentName} environment.");
        }
    }
}
