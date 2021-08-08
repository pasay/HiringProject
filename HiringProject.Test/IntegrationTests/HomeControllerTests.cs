using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace HiringProject.Test.IntegrationTests
{
    public class HomeControllerTests
    {
        private readonly IHost host = Helper.CreateHost();


        [Theory]
        [InlineData("/Health")]
        public async Task Get_EndpointsReturnSuccess(string url)
        {
            var client = host.GetTestClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
        }

    }
}
