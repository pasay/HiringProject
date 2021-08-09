using HiringProject.Api.Extensions;
using HiringProject.Business.Rules;
using HiringProject.Business.Rules.Imp;
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
            var assembly = AppDomain.CurrentDomain.Load("HiringProject.Business");

            return services
                    .AddMediatR(typeof(Startup))
                    .AddMediatR(assembly)
                    .AddRules()
                    ;
        }
        private static IServiceCollection AddRules(this IServiceCollection services)
        {

            return services
                    .RegisterAllTypes<IJobQualityRule>(new[] { typeof(IJobQualityRule).Assembly })
                    .AddTransient<IJobQualityRuleCalculator, JobQualityRuleCalculator>()
                    ;
        }
    }
}
