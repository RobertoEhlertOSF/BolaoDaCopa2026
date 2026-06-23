using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoDaCopa2026.Migrations
{
    /// <inheritdoc />
    public partial class AddSelecaoVencedoraNoJogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelecaoVencedoraId",
                table: "Jogos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_SelecaoVencedoraId",
                table: "Jogos",
                column: "SelecaoVencedoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoVencedoraId",
                table: "Jogos",
                column: "SelecaoVencedoraId",
                principalTable: "Selecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoVencedoraId",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_SelecaoVencedoraId",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "SelecaoVencedoraId",
                table: "Jogos");
        }
    }
}
