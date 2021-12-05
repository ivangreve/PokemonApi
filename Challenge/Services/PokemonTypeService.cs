using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Challenge.Contracts.Requests;
using Challenge.Contracts.Responses;
using Challenge.Models.Entities;
using Challenge.Models.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Challenge.Services
{
    public interface IPokemonTypeService
    {
        Task<List<PokemonTypes>> GetAllTypes();

    }
    public class PokemonTypeService : IPokemonTypeService
    {
        private readonly IPokemonTypeRepository _pokemonTypeRepository;

        public PokemonTypeService(IPokemonTypeRepository pokemonTypeRepository)
        {
            _pokemonTypeRepository = pokemonTypeRepository;
        }

        public async Task<List<PokemonTypes>> GetAllTypes()
        {
            var pokemons = await _pokemonTypeRepository.GetAll();
            return pokemons;
        }

    }
}
