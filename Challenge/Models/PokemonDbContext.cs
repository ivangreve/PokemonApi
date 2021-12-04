using System;
using System.Configuration;
using Challenge.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Models
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext()
        {
        }
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {

        }

        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<PokemonRarity> PokemonRarity { get; set; }
        public DbSet<ExpansionSet> ExpansionSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region seed data
            var pokemonTypes = new PokemonType[]
            {
                new PokemonType { Id = 1, Type = "Agua", Description = "Tipo Agua" },
                new PokemonType { Id = 2, Type = "Fuego", Description = "Tipo de Fuego" },
                new PokemonType { Id = 3, Type = "Hierba", Description = "Tipo Hierba" },
                new PokemonType { Id = 4, Type = "Electrico", Description = "Tipo Electrico" },
                new PokemonType { Id = 5, Type = "Psiquico", Description = "Tipo Psiquico" },
                new PokemonType { Id = 6, Type = "Normal", Description = "Tipo Normal" },
            };

            var pokemonRarities = new PokemonRarity[]
            {
                new PokemonRarity { Id = 1, Rarity = "Comun" },
                new PokemonRarity { Id = 2, Rarity = "No Comun" },
                new PokemonRarity { Id = 3, Rarity = "Raro" }
            };

            var pokemonExpansions = new ExpansionSet[]
            {
                new ExpansionSet { Id = 1, Expansion = "Base Set" },
                new ExpansionSet { Id = 2, Expansion = "Jungle" },
                new ExpansionSet { Id = 3, Expansion = "Fossil" },
                new ExpansionSet { Id = 4, Expansion = "Base Set 2" }
            };
            var pokemons = new Pokemon[] {
                new Pokemon { 
                    Id = 1, 
                    Name = "Pikachu", 
                    Hp = 100, 
                    IsFirstEdition = true, 
                    ExpansionSetId = 1, 
                    PokemonRarityId = 3,
                    PokemonTypeId = 4,
                    CardCreationTime = DateTime.Now, 
                    Image = "https://i.pinimg.com/originals/dc/ab/b7/dcabb7fbb2f763d680d20a3d228cc6f9.jpg"
                },
                new Pokemon {
                    Id = 2,
                    Name = "Charmander",
                    Hp = 150,
                    IsFirstEdition = false,
                    ExpansionSetId = 1,
                    PokemonRarityId = 3,
                    PokemonTypeId = 2,
                    CardCreationTime = DateTime.Now,
                    Image = "https://static.wikia.nocookie.net/superpokemon/images/f/f2/Charmander.jpg/revision/latest?cb=20101205152949&path-prefix=es"
                },
            };


            modelBuilder.Entity<PokemonRarity>().HasData(pokemonRarities);
            modelBuilder.Entity<PokemonType>().HasData(pokemonTypes);
            modelBuilder.Entity<ExpansionSet>().HasData(pokemonExpansions);
            modelBuilder.Entity<Pokemon>().HasData(pokemons);

            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
