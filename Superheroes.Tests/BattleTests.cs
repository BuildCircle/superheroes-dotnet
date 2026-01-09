using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using FluentAssertions;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Superheroes.Tests
{
    public class BattleTests
    {
        [Fact]
        public async Task CanGetHeros()
        {
            var charactersProvider = new FakeCharactersProvider();

            var factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(ICharactersProvider));
                        if (descriptor != null)
                        {
                            services.Remove(descriptor);
                        }
                        services.AddSingleton<ICharactersProvider>(charactersProvider);
                    });
                });

            var client = factory.CreateClient();

            charactersProvider.FakeResponse(new CharactersResponse
            {
                Items = new[]
                {
                    new CharacterResponse
                    {
                        Name = "Batman",
                        Score = 8.3,
                        Type = "hero"
                    },
                    new CharacterResponse
                    {
                        Name = "Joker",
                        Score = 8.2,
                        Type = "villain"
                    }
                }
            });

            var response = await client.GetAsync("battle?hero=Batman&villain=Joker");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseJson = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<JObject>(responseJson);

            responseObject.Value<string>("name").Should().Be("Batman");
        }
    }
}
