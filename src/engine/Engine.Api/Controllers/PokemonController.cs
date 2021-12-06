using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Challenge.Contracts.Requests;
using Challenge.Services;
using Microsoft.AspNetCore.Authorization;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/PokemonCard")]
    [Authorize]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // GET: api/PokemonCard/GetAll
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var pokemons = await _pokemonService.GetAllPokemons();
            return Ok(pokemons);
        }

        [HttpGet]
        [Route("Name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var pokemons = await _pokemonService.GetByName(name);
            return Ok(pokemons);
        }

        [HttpGet]
        [Route("Id/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var pokemons = await _pokemonService.GetById(id);
            return Ok(pokemons);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PokemonDto pokemonDto)
        {
            await _pokemonService.Create(pokemonDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] PokemonDto pokemonDto)
        {
            await _pokemonService.Update(id, pokemonDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _pokemonService.Delete(id);
            return Ok();
        }

    }
}
