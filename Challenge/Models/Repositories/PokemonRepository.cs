using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Challenge.Models.Entities;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Challenge.Models.Repositories
{

    public interface IPokemonRepository
    {
        Task<List<Pokemon>> GetAll();
        Task<Pokemon> Get(int id);
        Task<Pokemon> Get(string pokemonName);
    }

    public class PokemonRepository: IAsyncDbRepository<PokemonRepository>, IPokemonRepository
    {
        private readonly PokemonDbContext _pokemonContext;
        public PokemonRepository(PokemonDbContext pokemonContext)
        {
            _pokemonContext = pokemonContext;
        }

        public async Task<List<Pokemon>> GetAll()
        {
            var pokemons = await _pokemonContext.Pokemon
                .Include(p => p.PokemonType)
                .Include(p => p.PokemonRarity)
                .Include(p => p.ExpansionSet)
                .ToListAsync();
            return pokemons;
        }

        public async Task<Pokemon> Get(string name)
        {
            var pokemon = await _pokemonContext.Pokemon.FirstOrDefaultAsync(x => x.Name == name);

            return pokemon;
        }

        public async Task<Pokemon> Get(int id)
        {
            var pokemon = await _pokemonContext.Pokemon.FirstOrDefaultAsync(x => x.Id == id);
            return pokemon;
        }

        public void Add(PokemonRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PokemonRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(PokemonRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PokemonRepository>> GetAllAsync(params Expression<Func<PokemonRepository, object>>[] includes)
        {
            throw new NotImplementedException();
        }
    }

}