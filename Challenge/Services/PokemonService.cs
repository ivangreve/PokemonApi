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
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetAllPokemons();
        Task<Pokemon> GetByName(string name);
        Task<Pokemon> GetById(long id);
        void Create(PokemonDto pokemonDto);
        Task<bool> Update(long id, PokemonDto pokemonDto);
        Task<bool> Delete(long id);
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

        public void Create(PokemonDto pokemonDto)
        {
            var pokemonEntity = new Pokemon(pokemonDto);
            _pokemonRepository.Create(pokemonEntity);
            _pokemonRepository.SaveChanges();
        }

        public async Task<bool> Update(long id, PokemonDto pokemonDto)
        {
            var existingPokemon = await _pokemonRepository.GetById(id);

            if (existingPokemon == null) return false;

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
            return true;
        }

        public async Task<bool> Delete(long id)
        {
            var existingPokemon = await _pokemonRepository.GetById(id);
            if (existingPokemon == null) return false;

            _pokemonRepository.Delete(existingPokemon);
            _pokemonRepository.SaveChanges();
            return true;
        }
    }
}
