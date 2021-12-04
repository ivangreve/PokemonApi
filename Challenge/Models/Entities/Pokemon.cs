using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Models.Entities
{
    public class Pokemon: EntityBase
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public bool IsFirstEdition { get; set; }
        public long ExpansionSetId { get; set; }
        [ForeignKey("ExpansionSetId")]
        public ExpansionSet ExpansionSet { get; set; }
        public long PokemonTypeId { get; set; }
        [ForeignKey("PokemonTypeId")]
        public PokemonType PokemonType { get; set; }
        public long PokemonRarityId { get; set; }
        [ForeignKey("PokemonRarityId")]
        public PokemonRarity PokemonRarity { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public DateTime CardCreationTime { get; set; }
    }


}


