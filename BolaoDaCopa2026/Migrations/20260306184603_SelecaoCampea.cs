using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoDaCopa2026.Migrations
{
    /// <inheritdoc />
    public partial class SelecaoCampea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelecaoCampeaId",
                table: "Apostadores",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apostadores_SelecaoCampeaId",
                table: "Apostadores",
                column: "SelecaoCampeaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apostadores_Selecoes_SelecaoCampeaId",
                table: "Apostadores",
                column: "SelecaoCampeaId",
                principalTable: "Selecoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apostadores_Selecoes_SelecaoCampeaId",
                table: "Apostadores");

            migrationBuilder.DropIndex(
                name: "IX_Apostadores_SelecaoCampeaId",
                table: "Apostadores");

            migrationBuilder.DropColumn(
                name: "SelecaoCampeaId",
                table: "Apostadores");
        }
    }
}
