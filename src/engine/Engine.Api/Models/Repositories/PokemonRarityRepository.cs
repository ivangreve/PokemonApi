using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Challenge.Models.Entities;


namespace Challenge.Models.Repositories
{
    public interface IPokemonRarityRepository : IRepositoryBase<PokemonRarityRepository>
    {
        Task<List<PokemonRarity>> GetAll();
        Task<PokemonRarity> GetByName(string name);
        Task<PokemonRarity> GetById(long id);
    }

    public class PokemonRarityRepository : RepositoryBase<PokemonRarityRepository>, IPokemonRarityRepository
    {
        private readonly PokemonDbContext _pokemonContext;
        public PokemonRarityRepository(PokemonDbContext pokemonContext): base(pokemonContext)
        {
            _pokemonContext = pokemonContext;
        }

        public async Task<List<PokemonRarity>> GetAll()
        {
            var rarities = await _pokemonContext.PokemonRarity.ToListAsync();
            return rarities;
        }

        public async Task<PokemonRarity> GetByName(string rarityName)
        {
            var pokemon = await _pokemonContext.PokemonRarity
                .FirstOrDefaultAsync(x => x.Rarity == rarityName);

            return pokemon;
        }

        public async Task<PokemonRarity> GetById(long id)
        {
            var pokemon = await _pokemonContext.PokemonRarity
                .FirstOrDefaultAsync(x => x.Id == id);
            
            return pokemon;
        }

    }

}