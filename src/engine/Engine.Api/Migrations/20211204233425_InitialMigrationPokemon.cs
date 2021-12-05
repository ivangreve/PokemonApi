using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Challenge.Migrations
{
    public partial class InitialMigrationPokemon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExpansionSet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Expansion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpansionSet", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PokemonRarity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rarity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonRarity", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PokemonTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hp = table.Column<int>(type: "int", nullable: false),
                    IsFirstEdition = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExpansionSetId = table.Column<long>(type: "bigint", nullable: false),
                    PokemonTypeId = table.Column<long>(type: "bigint", nullable: false),
                    PokemonRarityId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CardCreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemon_ExpansionSet_ExpansionSetId",
                        column: x => x.ExpansionSetId,
                        principalTable: "ExpansionSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemon_PokemonRarity_PokemonRarityId",
                        column: x => x.PokemonRarityId,
                        principalTable: "PokemonRarity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemon_PokemonTypes_PokemonTypeId",
                        column: x => x.PokemonTypeId,
                        principalTable: "PokemonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ExpansionSet",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Expansion", "ModifiedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(2680), false, "Base Set", null },
                    { 2L, new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(2894), false, "Jungle", null },
                    { 3L, new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(2896), false, "Fossil", null },
                    { 4L, new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(2897), false, "Base Set 2", null }
                });

            migrationBuilder.InsertData(
                table: "PokemonRarity",
                columns: new[] { "Id", "CreatedDate", "Deleted", "ModifiedDate", "Rarity" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(2256), false, null, "Comun" },
                    { 2L, new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(2484), false, null, "No Comun" },
                    { 3L, new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(2487), false, null, "Raro" }
                });

            migrationBuilder.InsertData(
                table: "PokemonTypes",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Description", "ModifiedDate", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(1184), false, "Tipo Agua", null, "Agua" },
                    { 2L, new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(1987), false, "Tipo de Fuego", null, "Fuego" },
                    { 3L, new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(1991), false, "Tipo Hierba", null, "Hierba" },
                    { 4L, new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(1992), false, "Tipo Electrico", null, "Electrico" },
                    { 5L, new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(1994), false, "Tipo Psiquico", null, "Psiquico" },
                    { 6L, new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(1995), false, "Tipo Normal", null, "Normal" }
                });

            migrationBuilder.InsertData(
                table: "Pokemon",
                columns: new[] { "Id", "CardCreationTime", "CreatedDate", "Deleted", "ExpansionSetId", "Hp", "Image", "IsFirstEdition", "ModifiedDate", "Name", "PokemonRarityId", "PokemonTypeId", "Price" },
                values: new object[] { 2L, new DateTime(2021, 12, 4, 20, 34, 25, 425, DateTimeKind.Local).AddTicks(5233), new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(5229), false, 1L, 150, "https://static.wikia.nocookie.net/superpokemon/images/f/f2/Charmander.jpg/revision/latest?cb=20101205152949&path-prefix=es", false, null, "Charmander", 3L, 2L, 0.0 });

            migrationBuilder.InsertData(
                table: "Pokemon",
                columns: new[] { "Id", "CardCreationTime", "CreatedDate", "Deleted", "ExpansionSetId", "Hp", "Image", "IsFirstEdition", "ModifiedDate", "Name", "PokemonRarityId", "PokemonTypeId", "Price" },
                values: new object[] { 1L, new DateTime(2021, 12, 4, 20, 34, 25, 425, DateTimeKind.Local).AddTicks(4564), new DateTime(2021, 12, 4, 23, 34, 25, 425, DateTimeKind.Utc).AddTicks(3084), false, 1L, 100, "https://i.pinimg.com/originals/dc/ab/b7/dcabb7fbb2f763d680d20a3d228cc6f9.jpg", true, null, "Pikachu", 3L, 4L, 0.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_ExpansionSetId",
                table: "Pokemon",
                column: "ExpansionSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_PokemonRarityId",
                table: "Pokemon",
                column: "PokemonRarityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_PokemonTypeId",
                table: "Pokemon",
                column: "PokemonTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemon");

            migrationBuilder.DropTable(
                name: "ExpansionSet");

            migrationBuilder.DropTable(
                name: "PokemonRarity");

            migrationBuilder.DropTable(
                name: "PokemonTypes");
        }
    }
}
