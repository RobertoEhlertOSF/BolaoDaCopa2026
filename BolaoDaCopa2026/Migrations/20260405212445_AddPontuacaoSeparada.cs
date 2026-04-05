using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoDaCopa2026.Migrations
{
    /// <inheritdoc />
    public partial class AddPontuacaoSeparada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apostas_Selecoes_SelecaoCampeaId",
                table: "Apostas");

            migrationBuilder.DropIndex(
                name: "IX_Apostas_SelecaoCampeaId",
                table: "Apostas");

            migrationBuilder.DropColumn(
                name: "SelecaoCampeaId",
                table: "Apostas");

            migrationBuilder.RenameColumn(
                name: "Pontuacao",
                table: "Apostadores",
                newName: "PontosJogos");

            migrationBuilder.AddColumn<int>(
                name: "PontosCampeao",
                table: "Apostadores",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PontosCampeao",
                table: "Apostadores");

            migrationBuilder.RenameColumn(
                name: "PontosJogos",
                table: "Apostadores",
                newName: "Pontuacao");

            migrationBuilder.AddColumn<int>(
                name: "SelecaoCampeaId",
                table: "Apostas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apostas_SelecaoCampeaId",
                table: "Apostas",
                column: "SelecaoCampeaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apostas_Selecoes_SelecaoCampeaId",
                table: "Apostas",
                column: "SelecaoCampeaId",
                principalTable: "Selecoes",
                principalColumn: "Id");
        }
    }
}
