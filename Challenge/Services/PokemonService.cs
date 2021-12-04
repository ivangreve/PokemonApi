using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge.Contracts.Responses;
using Challenge.Models.Entities;
using Challenge.Models.Repositories;

namespace Challenge.Services
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetAllPokemons();
        Task<Pokemon> GetByName(string name);
    }
    public class PokemonService: IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<List<Pokemon>> GetAllPokemons()
        {
            var pokemons = await _pokemonRepository.GetAll();
            return pokemons;
        }

        public async Task<Pokemon> GetByName(string name)
        {
            var pokemon = await _pokemonRepository.Get(name);
            return pokemon;
        }
    }
}
