using HiringProject.Model.Controllers;
using MapsterMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HiringProject.Api.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = _mapper.Map<CustomHttpResponse>(ex);

            _logger?.LogError(ex, Newtonsoft.Json.JsonConvert.SerializeObject(response));

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;
            await context.Response.WriteAsync(response.Message);
        }
    }

    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder => appBuilder.UseMiddleware<ErrorHandlingMiddleware>());
        }
        public static IServiceCollection AddErrorHandlingMiddleware(this IServiceCollection services)
        {
            return services.AddTransient<ErrorHandlingMiddleware>();
        }
    }
}
