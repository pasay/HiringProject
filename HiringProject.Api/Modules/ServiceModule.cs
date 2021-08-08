using HiringProject.Business;
using HiringProject.Business.Imp;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HiringProject.Api.Modules
{
    public static class ServiceModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Startup));
            //var assembly = AppDomain.CurrentDomain.Load("Project.Core");
            //services.AddMediatR(assembly);

            services.AddTransient<ICompanyBusiness, CompanyBusiness>()
                    .AddTransient<IJobBusiness, JobBusiness>()
                    ;

            return services;
        }
    }
}
