using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Challenge.Models.Entities;


namespace Challenge.Models.Repositories
{

    public interface IPokemonTypeRepository : IRepositoryBase<PokemonTypeRepository>
    {
        Task<List<PokemonTypes>> GetAll();
        Task<PokemonTypes> GetByName(string name);
        Task<PokemonTypes> GetById(long id);
    }

    public class PokemonTypeRepository : RepositoryBase<PokemonTypeRepository>, IPokemonTypeRepository
    {
        private readonly PokemonDbContext _pokemonContext;
        public PokemonTypeRepository(PokemonDbContext pokemonContext): base(pokemonContext)
        {
            _pokemonContext = pokemonContext;
        }

        public async Task<List<PokemonTypes>> GetAll()
        {
            var types = await _pokemonContext.PokemonTypes.ToListAsync();
            return types;
        }

        public async Task<PokemonTypes> GetByName(string typeName)
        {
            var pokemon = await _pokemonContext.PokemonTypes
                .FirstOrDefaultAsync(x => x.Type == typeName);

            return pokemon;
        }

        public async Task<PokemonTypes> GetById(long id)
        {
            var pokemon = await _pokemonContext.PokemonTypes
                .FirstOrDefaultAsync(x => x.Id == id);
            
            return pokemon;
        }

    }

}