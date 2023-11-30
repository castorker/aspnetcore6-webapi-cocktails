using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cocktails.API.Migrations
{
    public partial class ApplyUniqueConstraintToName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Name",
                table: "Ingredients",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cocktails_Name",
                table: "Cocktails",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ingredients_Name",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Cocktails_Name",
                table: "Cocktails");
        }
    }
}
