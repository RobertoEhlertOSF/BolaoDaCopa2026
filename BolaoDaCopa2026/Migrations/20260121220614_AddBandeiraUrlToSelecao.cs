using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoDaCopa2026.Migrations
{
    /// <inheritdoc />
    public partial class AddBandeiraUrlToSelecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BandeiraUrl",
                table: "Selecoes",
                type: "TEXT",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "JogoId",
                table: "Apostas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Jogo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SelecaoAId = table.Column<int>(type: "INTEGER", nullable: false),
                    SelecaoBId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fase = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    GolsSelecaoA = table.Column<int>(type: "INTEGER", nullable: true),
                    GolsSelecaoB = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogo_Selecoes_SelecaoAId",
                        column: x => x.SelecaoAId,
                        principalTable: "Selecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jogo_Selecoes_SelecaoBId",
                        column: x => x.SelecaoBId,
                        principalTable: "Selecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apostas_JogoId",
                table: "Apostas",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_SelecaoAId",
                table: "Jogo",
                column: "SelecaoAId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_SelecaoBId",
                table: "Jogo",
                column: "SelecaoBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apostas_Jogo_JogoId",
                table: "Apostas",
                column: "JogoId",
                principalTable: "Jogo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apostas_Jogo_JogoId",
                table: "Apostas");

            migrationBuilder.DropTable(
                name: "Jogo");

            migrationBuilder.DropIndex(
                name: "IX_Apostas_JogoId",
                table: "Apostas");

            migrationBuilder.DropColumn(
                name: "BandeiraUrl",
                table: "Selecoes");

            migrationBuilder.DropColumn(
                name: "JogoId",
                table: "Apostas");
        }
    }
}
