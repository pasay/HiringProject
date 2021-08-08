using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HiringProject.Data.Models;
using HiringProject.Data.Repositories;
using HiringProject.Model.Controllers.Companies.Requests;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using Xunit;

namespace HiringProject.Test.IntegrationTests
{
    public class CompaniesControllerTests
    {
        private readonly IHost host;
        private static Mock<ICompanyRepository> repository;
        public CompaniesControllerTests()
        {
            repository = new Mock<ICompanyRepository>();
            repository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Company, bool>>>())).Returns((Expression<Func<Company, bool>> source) => Task.FromResult((IEnumerable<Company>)(new List<Company>())));
            repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<Company, bool>>>())).Returns((Expression<Func<Company, bool>> source) => Task.FromResult(default(Company)));
            repository.Setup(x => x.GetByIdAsync(It.IsAny<string>())).Returns((string source) => Task.FromResult(new Company()));
            repository.Setup(x => x.AddAsync(It.IsAny<Company>())).Returns((Company source) => Task.FromResult(source));
            repository.Setup(x => x.UpdateByIdAsync(It.IsAny<string>(), It.IsAny<Company>())).Returns((string id, Company source) => Task.FromResult(source));
            repository.Setup(x => x.UpdateExpressionAsync(It.IsAny<Company>(), It.IsAny<Expression<Func<Company, bool>>>())).Returns((Company source, Expression<Func<Company, bool>> exp) => Task.FromResult(source));
            repository.Setup(x => x.DeleteAsync(It.IsAny<Company>())).Returns((Company source) => Task.FromResult(source));
            repository.Setup(x => x.DeleteByIdAsync(It.IsAny<string>())).Returns((string source) => Task.FromResult(new Company() { Id = source }));
            repository.Setup(x => x.DeleteExpressionAsync(It.IsAny<Expression<Func<Company, bool>>>())).Returns((Expression<Func<Company, bool>> source) => Task.FromResult(new Company()));

            host = Helper.CreateHost(ConfigureTestServices);
        }

        private static void ConfigureTestServices(IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository>(p => repository.Object);
        }

        [Theory]
        [InlineData("/api/Companies")]
        [InlineData("/api/Companies/611033aea27f5f6e19ffe1ce")]
        public async Task Get_EndpointsReturnSuccess(string url)
        {
            var client = host.GetTestClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("/api/Companies/611033aea27f5f6e19ffe1ce")]
        public async Task Delete_EndpointsReturnSuccess(string url)
        {
            var client = host.GetTestClient();
            var response = await client.DeleteAsync(url);

            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("/api/Companies", "company1", "5321234567")]
        public async Task Post_EndpointsReturnSuccess(string url, string name, string phoneNumber)
        {
            var request = new PostCompanyRequest() { Name = name, PhoneNumber = phoneNumber, Address = "Ist", RemainPublishJobCount = 2 };
            HttpContent content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var client = host.GetTestClient();
            var response = await client.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("/api/Companies", "611033aea27f5f6e19ffe1ce")]
        public async Task Put_EndpointsReturnSuccess(string url, string id)
        {
            var request = new PutCompanyRemainPublishJobCountRequest() { Id = id, RemainPublishJobCount = 2 };
            HttpContent content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var client = host.GetTestClient();
            var response = await client.PutAsync(url, content);

            response.EnsureSuccessStatusCode();
        }
    }
}
