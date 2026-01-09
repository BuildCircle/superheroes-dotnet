using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Superheroes.Tests
{
    public class HerosTests
    {
        [Fact]
        public void CanGetHeros()
        {
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();
        }
    }
}
