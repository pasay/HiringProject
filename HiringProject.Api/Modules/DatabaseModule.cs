using HiringProject.Api.Settings;
using HiringProject.Data.DataContext;
using HiringProject.Data.DataContext.Imp;
using HiringProject.Data.Repositories;
using HiringProject.Data.Repositories.Imp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace HiringProject.Api.Modules
{
    public static class DatabaseModule
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMongoDatabase>(provider =>
            {
                var mongoDbConnectionSettings = provider.GetService<IOptions<MongoDbConnectionSettings>>().Value;
                var client = new MongoClient(mongoDbConnectionSettings.ConnectionString);
                if (client == null)
                    throw new NotImplementedException();

                return client.GetDatabase(mongoDbConnectionSettings.Database);
            });
            services.AddScoped<IDbContext, HiringProjectMongoDbContext>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IForbiddenWordRepository, ForbiddenWordRepository>();
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

            return services;
        }
    }
}
