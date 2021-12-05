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
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/Pokemons")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // GET: api/Pokemons/GetAllCards
        [HttpGet]
        [Route("GetAllCards")]
        [ProducesResponseType(typeof(List<Pokemon>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var pokemons = await _pokemonService.GetAllPokemons();
            return Ok(pokemons);
        }

        // GET: api/Pokemons/Name/Pikachu
        [HttpGet]
        [Route("Name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var pokemons = await _pokemonService.GetByName(name);
            return Ok(pokemons);
        }

        // GET: api/Pokemons/Id/1
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
        public async Task<IActionResult> Update(long id, [FromBody] PokemonDto pokemonDto)
        {
            var result = await _pokemonService.Update(id, pokemonDto);
            if (!result) return BadRequest("Error al modificar la Carta");

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok(new PokemonDto());

        }

    }
}
