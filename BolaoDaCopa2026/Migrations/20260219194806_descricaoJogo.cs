using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoDaCopa2026.Migrations
{
    /// <inheritdoc />
    public partial class descricaoJogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescricaoSelecaoA",
                table: "Jogos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoSelecaoB",
                table: "Jogos",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoSelecaoA",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "DescricaoSelecaoB",
                table: "Jogos");
        }
    }
}
