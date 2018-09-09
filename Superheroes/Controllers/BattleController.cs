
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Superheroes
{
    [Route("battle")]
    public class BattleController : Controller
    {
        private readonly ICharactersProvider _charactersProvider;
        private static CharacterResponse character1;
        private static CharacterResponse character2;

        public BattleController(ICharactersProvider charactersProvider)
        {
            _charactersProvider = charactersProvider;
        }

        public async Task<IActionResult> Get(string hero, string villain)
        {
            var characters = await _charactersProvider.GetCharacters();
            
            foreach(var character in characters.Items)
            {
                if(character.Name == hero)
                {
                    character1 = character;
                }
                if(character.Name == villain)
                {
                    character2 = character;
                }
            }

            if(character1.Score > character2.Score)
            {
                return Ok(character1);
            }

            return Ok(character2);
        }
    }
}