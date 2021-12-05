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
        [ProducesResponseType(typeof(List<PokemonRarity>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var rarities = await _pokemonRarityService.GetAllRarities();
            return Ok(rarities);
        }

    }
}
