using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Challenge.Migrations
{
    public partial class PokemonInitMigration : Migration
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
                    ExpansionSetId1 = table.Column<long>(type: "bigint", nullable: true),
                    ExpansionSetId = table.Column<int>(type: "int", nullable: false),
                    PokemonTypeId1 = table.Column<long>(type: "bigint", nullable: true),
                    PokemonTypeId = table.Column<int>(type: "int", nullable: false),
                    PokemonRarityId1 = table.Column<long>(type: "bigint", nullable: true),
                    PokemonRarityId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Pokemon_ExpansionSet_ExpansionSetId1",
                        column: x => x.ExpansionSetId1,
                        principalTable: "ExpansionSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemon_PokemonRarity_PokemonRarityId1",
                        column: x => x.PokemonRarityId1,
                        principalTable: "PokemonRarity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemon_PokemonTypes_PokemonTypeId1",
                        column: x => x.PokemonTypeId1,
                        principalTable: "PokemonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ExpansionSet",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Expansion", "ModifiedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 12, 4, 23, 7, 33, 113, DateTimeKind.Utc).AddTicks(9675), false, "Base Set", null },
                    { 2L, new DateTime(2021, 12, 4, 23, 7, 33, 113, DateTimeKind.Utc).AddTicks(9889), false, "Jungle", null },
                    { 3L, new DateTime(2021, 12, 4, 23, 7, 33, 113, DateTimeKind.Utc).AddTicks(9891), false, "Fossil", null },
                    { 4L, new DateTime(2021, 12, 4, 23, 7, 33, 113, DateTimeKind.Utc).AddTicks(9892), false, "Base Set 2", null }
                });

            migrationBuilder.InsertData(
                table: "Pokemon",
                columns: new[] { "Id", "CardCreationTime", "CreatedDate", "Deleted", "ExpansionSetId", "ExpansionSetId1", "Hp", "Image", "IsFirstEdition", "ModifiedDate", "Name", "PokemonRarityId", "PokemonRarityId1", "PokemonTypeId", "PokemonTypeId1", "Price" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 12, 4, 20, 7, 33, 114, DateTimeKind.Local).AddTicks(1268), new DateTime(2021, 12, 4, 23, 7, 33, 114, DateTimeKind.Utc).AddTicks(80), false, 1, null, 100, "https://i.pinimg.com/originals/dc/ab/b7/dcabb7fbb2f763d680d20a3d228cc6f9.jpg", true, null, "Pikachu", 3, null, 4, null, 0.0 },
                    { 2L, new DateTime(2021, 12, 4, 20, 7, 33, 114, DateTimeKind.Local).AddTicks(1750), new DateTime(2021, 12, 4, 23, 7, 33, 114, DateTimeKind.Utc).AddTicks(1746), false, 1, null, 150, "https://static.wikia.nocookie.net/superpokemon/images/f/f2/Charmander.jpg/revision/latest?cb=20101205152949&path-prefix=es", false, null, "Charmander", 3, null, 2, null, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "PokemonRarity",
                columns: new[] { "Id", "CreatedDate", "Deleted", "ModifiedDate", "Rarity" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 12, 4, 23, 7, 33, 113, DateTimeKind.Utc).AddTicks(9151), false, null, "Comun" },
                    { 2L, new DateTime(2021, 12, 4, 23, 7, 33, 113, DateTimeKind.Utc).AddTicks(9463), false, null, "No Comun" },
                    { 3L, new DateTime(2021, 12, 4, 23, 7, 33, 113, DateTimeKind.Utc).AddTicks(9465), false, null, "Raro" }
                });

            migrationBuilder.InsertData(
                table: "PokemonTypes",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Description", "ModifiedDate", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 12, 4, 23, 7, 33, 113, DateTimeKind.Utc).AddTicks(8048), false, "Tipo Agua", null, "Agua" },
                    { 2L, new DateTime(2021, 12, 4, 23, 7, 33, 113, DateTimeKind.Utc).AddTicks(8928), false, "Tipo de Fuego", null, "Fuego" },
                    { 3L, new DateTime(2021, 12, 4, 23, 7, 33, 113, DateTimeKind.Utc).AddTicks(8931), false, "Tipo Hierba", null, "Hierba" },
                    { 4L, new DateTime(2021, 12, 4, 23, 7, 33, 113, DateTimeKind.Utc).AddTicks(8932), false, "Tipo Electrico", null, "Electrico" },
                    { 5L, new DateTime(2021, 12, 4, 23, 7, 33, 113, DateTimeKind.Utc).AddTicks(8933), false, "Tipo Psiquico", null, "Psiquico" },
                    { 6L, new DateTime(2021, 12, 4, 23, 7, 33, 113, DateTimeKind.Utc).AddTicks(8934), false, "Tipo Normal", null, "Normal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_ExpansionSetId1",
                table: "Pokemon",
                column: "ExpansionSetId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_PokemonRarityId1",
                table: "Pokemon",
                column: "PokemonRarityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_PokemonTypeId1",
                table: "Pokemon",
                column: "PokemonTypeId1");
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
