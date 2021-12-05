using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Challenge.Services;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/PokemonRarity")]
    public class PokemonRarityController : ControllerBase
    {
        private readonly IPokemonRarityService _pokemonRarityService;

        public PokemonRarityController(IPokemonRarityService pokemonRarityService)
        {
            _pokemonRarityService = pokemonRarityService;
        }

        // GET: api/PokemonRarity/GetAllRarities
        [HttpGet]
        [Route("GetAllRarities")]
        public async Task<IActionResult> GetAll()
        {
            var rarities = await _pokemonRarityService.GetAllRarities();
            return Ok(rarities);
        }

    }
}
