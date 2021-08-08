using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HiringProject.Data.Models;
using HiringProject.Data.Repositories;
using HiringProject.Model.Controllers.ForbiddenWords.Requests;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using Xunit;

namespace HiringProject.Test.IntegrationTests
{
    public class ForbiddenWordsControllerTests
    {
        private readonly IHost host;
        private static Mock<IForbiddenWordRepository> repository;
        public ForbiddenWordsControllerTests()
        {
            repository = new Mock<IForbiddenWordRepository>();
            repository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<ForbiddenWord, bool>>>())).Returns((Expression<Func<ForbiddenWord, bool>> source) => Task.FromResult((IEnumerable<ForbiddenWord>)(new List<ForbiddenWord>())));
            repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<ForbiddenWord, bool>>>())).Returns((Expression<Func<ForbiddenWord, bool>> source) => Task.FromResult(default(ForbiddenWord)));
            repository.Setup(x => x.GetByIdAsync(It.IsAny<string>())).Returns((string source) => Task.FromResult(new ForbiddenWord()));
            repository.Setup(x => x.AddAsync(It.IsAny<ForbiddenWord>())).Returns((ForbiddenWord source) => Task.FromResult(source));
            repository.Setup(x => x.UpdateByIdAsync(It.IsAny<string>(), It.IsAny<ForbiddenWord>())).Returns((string id, ForbiddenWord source) => Task.FromResult(source));
            repository.Setup(x => x.UpdateExpressionAsync(It.IsAny<ForbiddenWord>(), It.IsAny<Expression<Func<ForbiddenWord, bool>>>())).Returns((ForbiddenWord source, Expression<Func<ForbiddenWord, bool>> exp) => Task.FromResult(source));
            repository.Setup(x => x.DeleteAsync(It.IsAny<ForbiddenWord>())).Returns((ForbiddenWord source) => Task.FromResult(source));
            repository.Setup(x => x.DeleteByIdAsync(It.IsAny<string>())).Returns((string source) => Task.FromResult(new ForbiddenWord() { Id = source, Word = source }));
            repository.Setup(x => x.DeleteExpressionAsync(It.IsAny<Expression<Func<ForbiddenWord, bool>>>())).Returns((Expression<Func<ForbiddenWord, bool>> source) => Task.FromResult(new ForbiddenWord()));

            host = Helper.CreateHost(ConfigureTestServices);
        }

        private static void ConfigureTestServices(IServiceCollection services)
        {
            services.AddScoped<IForbiddenWordRepository>(p => repository.Object);
        }

        [Theory]
        [InlineData("/api/ForbiddenWords")]
        [InlineData("/api/ForbiddenWords/testxxxxx")]
        public async Task Get_EndpointsReturnSuccess(string url)
        {
            var client = host.GetTestClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("/api/ForbiddenWords/testxxxxx")]
        public async Task Delete_EndpointsReturnSuccess(string url)
        {
            var client = host.GetTestClient();
            var response = await client.DeleteAsync(url);

            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("/api/ForbiddenWords", "testxxxx")]
        public async Task Post_EndpointsReturnSuccess(string url, string word)
        {
            var request = new PostForbiddenWordRequest() { Word = word };
            HttpContent content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var client = host.GetTestClient();
            var response = await client.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
        }
    }
}
