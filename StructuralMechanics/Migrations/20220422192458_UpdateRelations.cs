using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StructuralMechanics.Migrations
{
    public partial class UpdateRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StrengthMembers_LocationId",
                table: "StrengthMembers");

            migrationBuilder.DropIndex(
                name: "IX_SimpleShapes_FirstPointId",
                table: "SimpleShapes");

            migrationBuilder.DropIndex(
                name: "IX_SimpleShapes_SecondPointId",
                table: "SimpleShapes");

            migrationBuilder.DropIndex(
                name: "IX_ShearForces_LocationId",
                table: "ShearForces");

            migrationBuilder.CreateIndex(
                name: "IX_StrengthMembers_LocationId",
                table: "StrengthMembers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SimpleShapes_FirstPointId",
                table: "SimpleShapes",
                column: "FirstPointId");

            migrationBuilder.CreateIndex(
                name: "IX_SimpleShapes_SecondPointId",
                table: "SimpleShapes",
                column: "SecondPointId");

            migrationBuilder.CreateIndex(
                name: "IX_ShearForces_LocationId",
                table: "ShearForces",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StrengthMembers_LocationId",
                table: "StrengthMembers");

            migrationBuilder.DropIndex(
                name: "IX_SimpleShapes_FirstPointId",
                table: "SimpleShapes");

            migrationBuilder.DropIndex(
                name: "IX_SimpleShapes_SecondPointId",
                table: "SimpleShapes");

            migrationBuilder.DropIndex(
                name: "IX_ShearForces_LocationId",
                table: "ShearForces");

            migrationBuilder.CreateIndex(
                name: "IX_StrengthMembers_LocationId",
                table: "StrengthMembers",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SimpleShapes_FirstPointId",
                table: "SimpleShapes",
                column: "FirstPointId",
                unique: true,
                filter: "[FirstPointId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SimpleShapes_SecondPointId",
                table: "SimpleShapes",
                column: "SecondPointId",
                unique: true,
                filter: "[SecondPointId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShearForces_LocationId",
                table: "ShearForces",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");
        }
    }
}
