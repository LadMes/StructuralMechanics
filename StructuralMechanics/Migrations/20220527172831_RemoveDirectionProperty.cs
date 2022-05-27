using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StructuralMechanics.Migrations
{
    public partial class RemoveDirectionProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direction",
                table: "VectorPhysicalQuantities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Direction",
                table: "VectorPhysicalQuantities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
