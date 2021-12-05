using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Challenge.Services;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/PokemonsType")]
    public class PokemonTypeController : ControllerBase
    {
        private readonly IPokemonTypeService _pokemonTypeService;

        public PokemonTypeController(IPokemonTypeService pokemonTypeService)
        {
            _pokemonTypeService = pokemonTypeService;
        }

        [HttpGet]
        [Route("GetAllTypes")]
        public async Task<IActionResult> GetAll()
        {
            var pokemons = await _pokemonTypeService.GetAllTypes();
            return Ok(pokemons);
        }

    }
}
