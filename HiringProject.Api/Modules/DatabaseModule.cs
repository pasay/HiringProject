using System;
using System.Reflection;
using HiringProject.Api.Settings;
using HiringProject.Data.DataContext;
using HiringProject.Data.DataContext.Imp;
using HiringProject.Data.Repositories;
using HiringProject.Data.Repositories.Imp;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace HiringProject.Api.Modules
{
    public static class DatabaseModule
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMongoDatabase>(provider =>
            {
                var settings = provider.GetService<MongoDbConnectionSettings>();
                var client = new MongoClient(settings.ConnectionString);
                if (client == null)
                    throw new NotImplementedException();

                return client.GetDatabase(settings.Database);
            });
            services.AddScoped<IDbContext, HiringProjectMongoDbContext>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IUnitOfWorkRepository, IUnitOfWorkRepository>();

            return services;
        }
    }
}
