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
    [Route("api/PokemonsType")]
    public class PokemonTypeController : ControllerBase
    {
        private readonly IPokemonTypeService _pokemonTypeService;

        public PokemonTypeController(IPokemonTypeService pokemonTypeService)
        {
            _pokemonTypeService = pokemonTypeService;
        }

        // GET: api/PokemonsType/GetAllTypes
        [HttpGet]
        [Route("GetAllTypes")]
        [ProducesResponseType(typeof(List<PokemonTypes>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {

            var pokemons = await _pokemonTypeService.GetAllTypes();
            return Ok(pokemons);
        }

        // GET: api/PokemonsType/Name/Electrico
        [HttpGet]
        [Route("Name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var pokemons = await _pokemonTypeService.GetByName(name);
            return Ok(pokemons);
        }

        // GET: api/PokemonsType/Id/1
        [HttpGet]
        [Route("Id/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var pokemonType = await _pokemonTypeService.GetById(id);
            return Ok(pokemonType);
        }

        //[HttpPost]
        //public IActionResult Create([FromBody] PokemonDto pokemonDto)
        //{
        //    _pokemonTypeService.Create(pokemonDto);
        //    return Ok(new PokemonDto());
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(long id, [FromBody] PokemonDto pokemonDto)
        //{
        //    var result = await _pokemonService.Update(id, pokemonDto);
        //    if (!result) return BadRequest("Error al modificar la Carta");

        //    return Ok();
        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return BadRequest("Not implemented");

        }

    }
}
