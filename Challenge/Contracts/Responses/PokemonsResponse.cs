using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge.Models.Entities;

namespace Challenge.Contracts.Responses
{
    public class PokemonsResponse
    {
        public IEnumerable<Pokemon> Pokemons;
    }
}
