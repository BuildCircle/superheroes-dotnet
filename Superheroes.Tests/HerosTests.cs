using System;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Superheroes;
using System.Threading.Tasks;
using FluentAssertions;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.DependencyInjection;

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
