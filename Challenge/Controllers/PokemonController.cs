using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge.Contracts.Requests;
using Challenge.Contracts.Responses;
using Challenge.Models.Entities;
using Challenge.Services;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/Pokemons")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        [Route("GetAllCards")]
        public async Task<IActionResult> GetAll()
        {
            var pokemons = await _pokemonService.GetAllPokemons();
            return Ok(pokemons);
        }

        // GET: api/Pokemons/id/1
        [HttpGet]
        [Route("Name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var pokemons = await _pokemonService.GetByName(name);
            return Ok(pokemons);
        }

        // GET: api/Pokemons/name/5
        [HttpGet]
        [Route("Id/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var pokemons = await _pokemonService.GetById(id);
            return Ok(pokemons);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PokemonDto pokemonDto)
        {
            _pokemonService.Create(pokemonDto);
            return Ok(new PokemonDto());
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] PokemonDto pokemon)
        {
            return Ok(new PokemonDto());

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok(new PokemonDto());

        }

    }
}
