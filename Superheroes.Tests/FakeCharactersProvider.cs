using System.Threading.Tasks;

namespace Superheroes.Tests
{
    public class FakeCharactersProvider : ICharactersProvider
    {
        CharactersResponse _response;
        
        public void FakeResponse(CharactersResponse response)
        {
            _response = response;
        }

        public Task<CharactersResponse> GetCharacters()
        {
            return Task.FromResult(_response);
        }
    }
}
