using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCPeliculas.Migrations
{
    /// <inheritdoc />
    public partial class Pelicula_Col_Director_Sala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Peliculas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Director",
                table: "Peliculas");
        }
    }
}
