using HiringProject.Model.Commands.Companies;
using HiringProject.Model.Commands.Jobs;
using HiringProject.Model.Controllers.Companies.Requests;
using HiringProject.Model.Controllers.Jobs.Requests;
using HiringProject.Model.Queries.Companies;
using HiringProject.Model.Queries.Jobs;
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
            //Controllers -> Cqrs
            //Companies Controller
            NewConfig<GetCompanyIdRequest, GetCompanyFromIdQuery>();
            NewConfig<DeleteCompanyIdRequest, DeleteCompanyFromIdCommand>();
            NewConfig<PostCompanyRequest, NewCompanyCommand>();

            //Job Controller
            NewConfig<GetJobIdRequest, GetJobFromIdQuery>();
            NewConfig<GetAllJobRequest, GetAllJobsFromCompanyIdQuery>();
            NewConfig<DeleteJobIdRequest, DeleteJobFromIdCommand>();
            NewConfig<PostJobRequest, NewJobCommand>();

        }
    }
}
