using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tejedor.API.Migrations
{
    /// <inheritdoc />
    public partial class Tejedor_110624_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagesRoute",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagesRoute",
                table: "Categories");
        }
    }
}
