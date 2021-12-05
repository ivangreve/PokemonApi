using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Challenge.Contracts.Requests;
using Challenge.Models.Entities;
using Challenge.Models.Repositories;

namespace Challenge.Services
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetAllPokemons();
        Task<Pokemon> GetByName(string name);
        Task<Pokemon> GetById(long id);
        Task Create(PokemonDto pokemonDto);
        Task Update(long id, PokemonDto pokemonDto);
        Task Delete(long id);
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
            var pokemon = await _pokemonRepository.GetByName(name);
            return pokemon;
        }
        public Task<Pokemon> GetById(long id)
        {
            var pokemon = _pokemonRepository.GetById(id);
            return pokemon;
        }

        public async Task Create(PokemonDto pokemonDto)
        {
            var pokemonEntity = new Pokemon(pokemonDto);
            _pokemonRepository.Create(pokemonEntity);
            _pokemonRepository.SaveChanges();
        }

        public async Task Update(long id, PokemonDto pokemonDto)
        {
            var existingPokemon = await _pokemonRepository.GetById(id);

            if (existingPokemon == null) throw new ArgumentException("Pokemon inexistente");

            var pokemonEntity = new Pokemon
            {
                Id = id,
                Name = pokemonDto.Name,
                Hp = pokemonDto.Hp,
                IsFirstEdition = pokemonDto.IsFirstEdition,
                ExpansionSetId = pokemonDto.ExpansionSetId,
                PokemonTypeId = pokemonDto.PokemonTypeId,
                PokemonRarityId = pokemonDto.PokemonRarityId,
                Price = pokemonDto.Price,
                Image = pokemonDto.Image,
                CardCreationTime = pokemonDto.CardCreationTime
            };

            _pokemonRepository.Update(pokemonEntity);
            _pokemonRepository.SaveChanges();
        }

        public async Task Delete(long id)
        {
            var existingPokemon = await _pokemonRepository.GetById(id);

            if (existingPokemon == null) throw new ArgumentException("Pokemon inexistente");

            _pokemonRepository.Delete(existingPokemon);
            _pokemonRepository.SaveChanges();

        }
    }
}
