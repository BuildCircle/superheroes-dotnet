using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Superheroes.Controllers
{
    [Route("battle")]
    public class BattleController : Controller
    {
        private readonly ICharactersProvider _charactersProvider;
        private static CharacterResponse _character1;
        private static CharacterResponse _character2;

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
                    _character1 = character;
                }
                if(character.Name == villain)
                {
                    _character2 = character;
                }
            }

            if(_character1.Score > _character2.Score)
            {
                return Ok(_character1);
            }

            return Ok(_character2);
        }
    }
}