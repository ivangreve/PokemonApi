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
    public interface IPokemonRarityService
    {
        Task<List<PokemonRarity>> GetAllRarities();

    }
    public class PokemonRarityService : IPokemonRarityService
    {
        private readonly IPokemonRarityRepository _pokemonRarityRepository;

        public PokemonRarityService(IPokemonRarityRepository pokemonRarityRepository)
        {
            _pokemonRarityRepository = pokemonRarityRepository;
        }

        public async Task<List<PokemonRarity>> GetAllRarities()
        {
            var pokemonRarities = await _pokemonRarityRepository.GetAll();
            return pokemonRarities;
        }

    }
}
