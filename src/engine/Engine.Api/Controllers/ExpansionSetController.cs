using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Challenge.Services;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/ExpansionSet")]
    public class ExpansionSetController : ControllerBase
    {
        private readonly IExpansionSetService _expansionSetSetService;

        public ExpansionSetController(IExpansionSetService expansionSetSetService)
        {
            _expansionSetSetService = expansionSetSetService;
        }

        [HttpGet]
        [Route("GetExpansionSets")]
        public async Task<IActionResult> GetAll()
        {
            var pokemons = await _expansionSetSetService.GetAllExpansions();
            return Ok(pokemons);
        }

    }
}
