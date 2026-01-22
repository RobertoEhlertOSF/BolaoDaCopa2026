using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoDaCopa2026.Migrations
{
    /// <inheritdoc />
    public partial class AddJogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apostas_Jogo_JogoId",
                table: "Apostas");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogo_Selecoes_SelecaoAId",
                table: "Jogo");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogo_Selecoes_SelecaoBId",
                table: "Jogo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jogo",
                table: "Jogo");

            migrationBuilder.RenameTable(
                name: "Jogo",
                newName: "Jogos");

            migrationBuilder.RenameIndex(
                name: "IX_Jogo_SelecaoBId",
                table: "Jogos",
                newName: "IX_Jogos_SelecaoBId");

            migrationBuilder.RenameIndex(
                name: "IX_Jogo_SelecaoAId",
                table: "Jogos",
                newName: "IX_Jogos_SelecaoAId");

            migrationBuilder.AddColumn<bool>(
                name: "EstaAberto",
                table: "Jogos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jogos",
                table: "Jogos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apostas_Jogos_JogoId",
                table: "Apostas",
                column: "JogoId",
                principalTable: "Jogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoAId",
                table: "Jogos",
                column: "SelecaoAId",
                principalTable: "Selecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoBId",
                table: "Jogos",
                column: "SelecaoBId",
                principalTable: "Selecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apostas_Jogos_JogoId",
                table: "Apostas");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoAId",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoBId",
                table: "Jogos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jogos",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "EstaAberto",
                table: "Jogos");

            migrationBuilder.RenameTable(
                name: "Jogos",
                newName: "Jogo");

            migrationBuilder.RenameIndex(
                name: "IX_Jogos_SelecaoBId",
                table: "Jogo",
                newName: "IX_Jogo_SelecaoBId");

            migrationBuilder.RenameIndex(
                name: "IX_Jogos_SelecaoAId",
                table: "Jogo",
                newName: "IX_Jogo_SelecaoAId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jogo",
                table: "Jogo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apostas_Jogo_JogoId",
                table: "Apostas",
                column: "JogoId",
                principalTable: "Jogo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogo_Selecoes_SelecaoAId",
                table: "Jogo",
                column: "SelecaoAId",
                principalTable: "Selecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogo_Selecoes_SelecaoBId",
                table: "Jogo",
                column: "SelecaoBId",
                principalTable: "Selecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
