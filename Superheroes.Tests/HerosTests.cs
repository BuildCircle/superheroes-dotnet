using Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Superheroes.Tests
{
    public class HerosTests
    {
        [Fact]
        public void CanGetHeros()
        {
            var startup = new WebHostBuilder()
                            .UseStartup<Startup>();
            var testServer = new TestServer(startup);
            var client = testServer.CreateClient();


        }
    }
}
