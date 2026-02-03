using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoDaCopa2026.Migrations
{
    /// <inheritdoc />
    public partial class AddKnockoutStage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelecaoVencedoraId",
                table: "Apostas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GolsProrrogacaoA",
                table: "Jogos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GolsProrrogacaoB",
                table: "Jogos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelecaoVencedoraPenaltisId",
                table: "Jogos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apostas_SelecaoVencedoraId",
                table: "Apostas",
                column: "SelecaoVencedoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_SelecaoVencedoraPenaltisId",
                table: "Jogos",
                column: "SelecaoVencedoraPenaltisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apostas_Selecoes_SelecaoVencedoraId",
                table: "Apostas",
                column: "SelecaoVencedoraId",
                principalTable: "Selecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoVencedoraPenaltisId",
                table: "Jogos",
                column: "SelecaoVencedoraPenaltisId",
                principalTable: "Selecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apostas_Selecoes_SelecaoVencedoraId",
                table: "Apostas");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoVencedoraPenaltisId",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Apostas_SelecaoVencedoraId",
                table: "Apostas");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_SelecaoVencedoraPenaltisId",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "SelecaoVencedoraId",
                table: "Apostas");

            migrationBuilder.DropColumn(
                name: "GolsProrrogacaoA",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "GolsProrrogacaoB",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "SelecaoVencedoraPenaltisId",
                table: "Jogos");
        }
    }
}
