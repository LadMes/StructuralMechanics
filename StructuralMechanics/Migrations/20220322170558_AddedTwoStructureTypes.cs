using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StructuralMechanics.Migrations
{
    public partial class AddedTwoStructureTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CirclePlates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CirclePlates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CirclePlates_Structures_Id",
                        column: x => x.Id,
                        principalTable: "Structures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RotationalShells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotationalShells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RotationalShells_Structures_Id",
                        column: x => x.Id,
                        principalTable: "Structures",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CirclePlates");

            migrationBuilder.DropTable(
                name: "RotationalShells");
        }
    }
}
