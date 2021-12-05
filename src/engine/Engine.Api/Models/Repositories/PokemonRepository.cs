using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Challenge.Models.Entities;


namespace Challenge.Models.Repositories
{

    public interface IPokemonRepository: IRepositoryBase<Pokemon>
    {
        Task<List<Pokemon>> GetAll();
        Task<Pokemon> GetByName(string name);
        Task<Pokemon> GetById(long id);
    }

    public class PokemonRepository: RepositoryBase<Pokemon>, IPokemonRepository
    {
        private readonly PokemonDbContext _pokemonContext;
        public PokemonRepository(PokemonDbContext pokemonContext): base(pokemonContext)
        {
            _pokemonContext = pokemonContext;
        }

        public async Task<List<Pokemon>> GetAll()
        {
            var pokemons = await _pokemonContext.Pokemon
                .Include(p => p.PokemonTypes)
                .Include(p => p.PokemonRarity)
                .Include(p => p.ExpansionSet)
                .ToListAsync();
            return pokemons;
        }

        public async Task<Pokemon> GetByName(string name)
        {
            var pokemon = await _pokemonContext.Pokemon
                .Include(p => p.PokemonTypes)
                .Include(p => p.PokemonRarity)
                .Include(p => p.ExpansionSet)
                .FirstOrDefaultAsync(x => x.Name == name);

            return pokemon;
        }

        public async Task<Pokemon> GetById(long id)
        {
            var pokemon = await _pokemonContext.Pokemon
                .Include(p => p.PokemonTypes)
                .Include(p => p.PokemonRarity)
                .Include(p => p.ExpansionSet)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            return pokemon;
        }
        
    }

}