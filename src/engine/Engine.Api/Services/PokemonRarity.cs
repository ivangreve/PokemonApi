using System.Collections.Generic;
using System.Threading.Tasks;
using Challenge.Models.Entities;
using Challenge.Models.Repositories;

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
