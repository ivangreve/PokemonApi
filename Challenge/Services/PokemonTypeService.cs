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
        Task<PokemonTypes> GetByName(string name);
        Task<PokemonTypes> GetById(long id);
        //void Create(PokemonDto pokemonDto);
        //Task<bool> Update(long id, PokemonDto pokemonDto);
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

        public async Task<PokemonTypes> GetByName(string name)
        {
            var pokemon = await _pokemonTypeRepository.GetByName(name);
            return pokemon;
        }
        public Task<PokemonTypes> GetById(long id)
        {
            var pokemon = _pokemonTypeRepository.GetById(id);
            return pokemon;
        }

        //public void Create(PokemonDto pokemonDto)
        //{
        //    var pokemonEntity = new Pokemon(pokemonDto);
        //    _pokemonRepository.Create(pokemonEntity);
        //    _pokemonRepository.SaveChanges();
        //}

        //public async Task<bool> Update(long id, PokemonDto pokemonDto)
        //{
        //    var existingPokemon = await _pokemonRepository.GetById(id);

        //    if (existingPokemon == null) return false;

        //    var pokemonEntity = new Pokemon
        //    {
        //        Id = id,
        //        Name = pokemonDto.Name,
        //        Hp = pokemonDto.Hp,
        //        IsFirstEdition = pokemonDto.IsFirstEdition,
        //        ExpansionSetId = pokemonDto.ExpansionSetId,
        //        PokemonTypeId = pokemonDto.PokemonTypeId,
        //        PokemonRarityId = pokemonDto.PokemonRarityId,
        //        Price = pokemonDto.Price,
        //        Image = pokemonDto.Image,
        //        CardCreationTime = pokemonDto.CardCreationTime
        //    };

        //    _pokemonRepository.Update(pokemonEntity);
        //    _pokemonRepository.SaveChanges();
        //    return true;
        //}
    }
}
