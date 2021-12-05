using System;
using Challenge.Models.Entities;

namespace Challenge.Contracts.Requests
{
    public class PokemonDto
    {
        public PokemonDto(){}
        public PokemonDto(Pokemon pokemon)
        {
            Name = pokemon.Name;
            Hp = pokemon.Hp;
            IsFirstEdition = pokemon.IsFirstEdition;
            ExpansionSetId = pokemon.ExpansionSetId;
            PokemonTypeId = pokemon.PokemonTypeId;
            PokemonRarityId = pokemon.PokemonRarityId;
            Price = pokemon.Price;
            Image = pokemon.Image;
            CardCreationTime = pokemon.CardCreationTime;
        }
        public string Name { get; set; }
        public int Hp { get; set; }
        public bool IsFirstEdition { get; set; }
        public long ExpansionSetId { get; set; }
        public long PokemonTypeId { get; set; }
        public long PokemonRarityId { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public DateTime CardCreationTime { get; set; }
    }

}
