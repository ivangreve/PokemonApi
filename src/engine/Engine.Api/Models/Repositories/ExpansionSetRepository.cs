using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Challenge.Models.Entities;


namespace Challenge.Models.Repositories
{

    public interface IExpansionSetRepository : IRepositoryBase<ExpansionSetRepository>
    {
        Task<List<ExpansionSet>> GetAll();
        Task<ExpansionSet> GetByName(string expansionSet);
        Task<ExpansionSet> GetById(long id);
    }

    public class ExpansionSetRepository : RepositoryBase<ExpansionSetRepository>, IExpansionSetRepository
    {
        private readonly PokemonDbContext _pokemonContext;
        public ExpansionSetRepository(PokemonDbContext pokemonContext): base(pokemonContext)
        {
            _pokemonContext = pokemonContext;
        }

        public async Task<List<ExpansionSet>> GetAll()
        {
            var expansionSets = await _pokemonContext.ExpansionSet.ToListAsync();
            return expansionSets;
        }

        public async Task<ExpansionSet> GetByName(string expansionSetName)
        {
            var expansionSet = await _pokemonContext.ExpansionSet
                .FirstOrDefaultAsync(x => x.Expansion == expansionSetName);

            return expansionSet;
        }

        public async Task<ExpansionSet> GetById(long id)
        {
            var expansionSet = await _pokemonContext.ExpansionSet
                .FirstOrDefaultAsync(x => x.Id == id);
            
            return expansionSet;
        }

    }

}