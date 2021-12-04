using System;

namespace Challenge.Models.Entities
{
    public class Pokemon: EntityBase
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public bool IsFirstEdition { get; set; }
        public ExpansionSet ExpansionSet { get; set; }
        public int ExpansionSetId { get; set; }
        public PokemonType PokemonType { get; set; }
        public int PokemonTypeId { get; set; }
        public PokemonRarity PokemonRarity { get; set; }
        public int PokemonRarityId { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public DateTime CardCreationTime { get; set; }
    }


}


