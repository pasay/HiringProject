using FluentValidation;
using HiringProject.Data.Models;
using HiringProject.Exceptions;
using HiringProject.Model.Commands.Companies;
using HiringProject.Model.Commands.ForbiddenWords;
using HiringProject.Model.Commands.Jobs;
using HiringProject.Model.Controllers;
using HiringProject.Model.Controllers.Companies.Requests;
using HiringProject.Model.Controllers.Companies.Responses;
using HiringProject.Model.Controllers.ForbiddenWords.Requests;
using HiringProject.Model.Controllers.ForbiddenWords.Responses;
using HiringProject.Model.Controllers.Jobs.Requests;
using HiringProject.Model.Controllers.Jobs.Responses;
using HiringProject.Model.Queries.Companies;
using HiringProject.Model.Queries.ForbiddenWords;
using HiringProject.Model.Queries.Jobs;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;

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
            NewConfig<PostCompanyRequest, PostCompanyCommand>();
            NewConfig<PutCompanyRemainPublishJobCountRequest, PutCompanyRemainPublishJobCountCommand>();
            //ForbiddenWords Controller
            NewConfig<GetForbiddenWordRequest, GetForbiddenWordQuery>();
            NewConfig<DeleteForbiddenWordRequest, DeleteForbiddenWordCommand>();
            NewConfig<PostForbiddenWordRequest, PostForbiddenWordCommand>();
            //Job Controller
            NewConfig<GetJobIdRequest, GetJobFromIdQuery>();
            NewConfig<GetAllJobRequest, GetAllJobsFromCompanyIdQuery>();
            NewConfig<DeleteJobIdRequest, DeleteJobFromIdCommand>();
            NewConfig<PostJobRequest, PostJobCommand>();
            NewConfig<PutJobPublishRequest, PutJobPublishCommand>();

            //Data->Response
            //Companies
            NewConfig<Company, CompanyInfoResponse>();
            //ForbiddenWords
            NewConfig<ForbiddenWord, ForbiddenWordInfoResponse>();
            //Jobs
            NewConfig<Job, JobInfoResponse>();

            //Exceptions
            NewConfig<UnauthorizedAccessException, CustomHttpResponse>()
                .Map(dest => dest.StatusCode, src => (int)HttpStatusCode.Unauthorized);
            NewConfig<ValidationException, CustomHttpResponse>()
                .Map(dest => dest.StatusCode, src => (int)HttpStatusCode.BadRequest);
            NewConfig<AlreadyExistsException, CustomHttpResponse>()
                .Map(dest => dest.StatusCode, src => (int)HttpStatusCode.BadRequest);
            NewConfig<RemainPublishJobCountException, CustomHttpResponse>()
                .Map(dest => dest.StatusCode, src => (int)HttpStatusCode.Forbidden);
            NewConfig<PublishJobStatusException, CustomHttpResponse>()
                .Map(dest => dest.StatusCode, src => (int)HttpStatusCode.Forbidden);
            NewConfig<DataNotFoundException, CustomHttpResponse>()
                .Map(dest => dest.StatusCode, src => (int)HttpStatusCode.NotFound);
            NewConfig<Exception, CustomHttpResponse>()
                .Map(dest => dest.StatusCode, src => (int)HttpStatusCode.InternalServerError);

        }
    }
}
