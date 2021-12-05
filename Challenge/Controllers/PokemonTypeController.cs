﻿using Microsoft.AspNetCore.Mvc;
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

    }
}