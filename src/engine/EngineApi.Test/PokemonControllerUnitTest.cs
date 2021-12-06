using Challenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Challenge.Models.Entities;
using Xunit;
using System.Threading.Tasks;
using Challenge.Contracts.Requests;
using Challenge.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EngineApi.Test
{
    public class PokemonServiceFake : IPokemonService
    {
        private readonly List<Pokemon> _pokemons;
        public PokemonServiceFake()
        {
            _pokemons = new List<Pokemon> {
                new Pokemon {
                    Id = 1,
                    Name = "Pikachu",
                    Hp = 100,
                    IsFirstEdition = true,
                    ExpansionSetId = 1,
                    PokemonRarityId = 3,
                    PokemonTypeId = 4,
                    CardCreationTime = DateTime.Now,
                    Image = "https://i.pinimg.com/originals/dc/ab/b7/dcabb7fbb2f763d680d20a3d228cc6f9.jpg"
                },
                new Pokemon {
                    Id = 2,
                    Name = "Charmander",
                    Hp = 150,
                    IsFirstEdition = false,
                    ExpansionSetId = 1,
                    PokemonRarityId = 3,
                    PokemonTypeId = 2,
                    CardCreationTime = DateTime.Now,
                    Image = "https://static.wikia.nocookie.net/superpokemon/images/f/f2/Charmander.jpg/revision/latest?cb=20101205152949&path-prefix=es"
                },
            };
        }

        public async Task<List<Pokemon>> GetAll()
        {
            var pokemons = _pokemons;
            return pokemons;
        }
        public async Task<Pokemon> GetById(long id)
        {
            var pokemonEntity = _pokemons
                .FirstOrDefault(a => a.Id == id);

            return pokemonEntity;
        }

        public async Task Create(PokemonDto pokemonDto)
        {
            var pokemonEntity = new Pokemon(pokemonDto);
            pokemonEntity.Id = 999;
            _pokemons.Add(pokemonEntity);
        }

        public Task Update(long id, PokemonDto pokemonDto)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(long id)
        {
            var existing = _pokemons.First(a => a.Id == id);
            _pokemons.Remove(existing);
        }

        public async Task<List<Pokemon>> GetAllPokemons()
        {
            var pokemons = _pokemons;
            return pokemons;
        }

        public async Task<Pokemon> GetByName(string name)
        {
            var pokemonEntity = _pokemons
                .FirstOrDefault(a => a.Name == name);

            return pokemonEntity;
        }
    }
    public class PokemonControllerUnitTest
    {
        private readonly PokemonController _controller;
        private readonly IPokemonService _service;
        public PokemonControllerUnitTest()
        {
            _service = new PokemonServiceFake();
            _controller = new PokemonController(_service);
        }

        [Fact]
        public void Get_ReturnsOkResult()
        {

            var okResult = _controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }


        [Fact]
        public void Get_AllPokemons()
        {
            // Act
            var okResult = (OkObjectResult)_controller.GetAll().Result;
            // Assert
            var items = Assert.IsType<List<Pokemon>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void Get_ByName()
        {
            // Busco Pokemon existente en la BD
            var okResult = (OkObjectResult)_controller.GetByName("Pikachu").Result;
            var item = Assert.IsType<Pokemon>(okResult.Value);
            Assert.Equal("Pikachu", item.Name);
        }


        [Fact]
        public void Add_And_Delete_Pokemons()
        {
            var pokemonDto = new PokemonDto
            {
                Name = "MewTwo",
                Hp = 150,
                IsFirstEdition = false,
                ExpansionSetId = 1,
                PokemonRarityId = 3,
                PokemonTypeId = 2,
                CardCreationTime = DateTime.Now,
                Image =
                    "https://assets.pokemon.com/assets/cms2/img/pokedex/full/150.png",
            };
            // Creo nuevo Pokemon y verifico que se haya agregado a la Lista inicial
            _controller.Create(pokemonDto);
            var resultAdded = (OkObjectResult)_controller.GetAll().Result;
            var items = Assert.IsType<List<Pokemon>>(resultAdded.Value);
            Assert.Equal(3, items.Count);

            // Elimino ese pokemon agregado a la lista y verifico cantidad de Items
            _controller.Delete(999);
            var resultDeleted = (OkObjectResult)_controller.GetAll().Result;
            var itemsDeleted = Assert.IsType<List<Pokemon>>(resultDeleted.Value);
            Assert.Equal(2, items.Count);
        }
    }
}
