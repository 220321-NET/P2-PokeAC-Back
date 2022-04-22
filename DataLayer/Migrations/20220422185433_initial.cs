using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    hp = table.Column<int>(type: "integer", nullable: false),
                    attack = table.Column<int>(type: "integer", nullable: false),
                    special = table.Column<int>(type: "integer", nullable: false),
                    defense = table.Column<int>(type: "integer", nullable: false),
                    type1 = table.Column<string>(type: "text", nullable: false),
                    type2 = table.Column<string>(type: "text", nullable: false),
                    rarity = table.Column<int>(type: "integer", nullable: false),
                    childID = table.Column<int>(type: "integer", nullable: false),
                    parentID = table.Column<int>(type: "integer", nullable: false),
                    combatAI = table.Column<string>(type: "text", nullable: false),
                    specialAttack = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    matches = table.Column<int>(type: "integer", nullable: false),
                    wins = table.Column<int>(type: "integer", nullable: false),
                    losses = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemon");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
