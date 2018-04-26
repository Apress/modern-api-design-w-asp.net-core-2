using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Moq;
using System.Net.Http;
using Moq.Protected;
using System.Threading;
using System.Net;
using System.Security.Authentication;

namespace AwesomeApi.Tests
{
    public class PeopleController_Should
    {
        //...
        [Fact]
        public async Task Return_Cached_Person_As_Xml_Given_Id()
        {
            //arrange
            var httpMock = CreateMockHttpClient("Fanie");
            var hostBuilder = new WebHostBuilder().UseStartup<Startup>()
                .ConfigureServices(services =>
                {
                    services.AddSingleton(httpMock);
                });
            var server = new TestServer(hostBuilder);
            var client = server.CreateClient();
            
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            //act
            var response = await client.GetAsync("/api/people/2");
            var content = await response.Content.ReadAsStringAsync();
            //assert
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("application/xml", response.Content.Headers.ContentType.MediaType);
            var expectedContent = "<Person xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" Id =\"2\" Name=\"Fanie\"/>";
            Assert.Equal(expectedContent, content);
            Assert.True(response.Headers.CacheControl.Public);
            Assert.Equal(30, response.Headers.CacheControl.MaxAge.Value.
           TotalSeconds);
        }

        private object CreateMockHttpClient(string v)
        {
            throw new NotImplementedException();
        }
    }
}
