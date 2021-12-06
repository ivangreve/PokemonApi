using System.Collections.Generic;
using System.Threading.Tasks;
using Challenge.Models.Entities;
using Challenge.Models.Repositories;

namespace Challenge.Services
{
    public interface IExpansionSetService
    {
        Task<List<ExpansionSet>> GetAllExpansions();

    }
    public class ExpansionSetService : IExpansionSetService
    {
        private readonly IExpansionSetRepository _expansionSetRepository;

        public ExpansionSetService(IExpansionSetRepository expansionSetRepository)
        {
            _expansionSetRepository = expansionSetRepository;
        }

        public async Task<List<ExpansionSet>> GetAllExpansions()
        {
            var expansionSet = await _expansionSetRepository.GetAll();
            return expansionSet;
        }

    }
}
