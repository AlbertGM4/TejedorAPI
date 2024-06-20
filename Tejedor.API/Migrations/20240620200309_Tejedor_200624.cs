using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tejedor.API.Migrations
{
    /// <inheritdoc />
    public partial class Tejedor_200624 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Points",
                table: "Users",
                newName: "ACoins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ACoins",
                table: "Users",
                newName: "Points");
        }
    }
}
