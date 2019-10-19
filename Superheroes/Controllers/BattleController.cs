using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Superheroes.Controllers
{
    [Route("battle")]
    public class BattleController : Controller
    {
        private readonly ICharactersProvider _charactersProvider;
        
        public BattleController(ICharactersProvider charactersProvider)
        {
            _charactersProvider = charactersProvider;
        }

        public async Task<IActionResult> Get(string hero, string villain)
        {
            var characters = await _charactersProvider.GetCharacters();

            CharacterResponse heroCharacter = characters.Items.SingleOrDefault(character => character.Name == hero);
            CharacterResponse villianCharacter = characters.Items.SingleOrDefault(character => character.Name == villain);

            if (heroCharacter == null)
            {
                return NotFound();
            }

            if (heroCharacter.Type == villianCharacter.Type)
            {
                return BadRequest();
            }

            if(heroCharacter.Score > villianCharacter.Score)
            {
                return Ok(heroCharacter);
            }

            return Ok(villianCharacter);
        }
    }
}