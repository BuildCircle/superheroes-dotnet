using System.Threading.Tasks;

namespace Superheroes
{
    public interface ICharactersProvider
    {
        Task<CharactersResponse> GetCharacters();
    }
}