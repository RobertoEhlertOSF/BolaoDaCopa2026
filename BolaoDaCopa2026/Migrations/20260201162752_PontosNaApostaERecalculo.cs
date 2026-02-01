using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoDaCopa2026.Migrations
{
    /// <inheritdoc />
    public partial class PontosNaApostaERecalculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pontos",
                table: "Selecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ApostasProcessadas",
                table: "Jogos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClassificacaoProcessada",
                table: "Jogos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Pontos",
                table: "Apostas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 10,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 11,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 12,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 13,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 14,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 15,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 16,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 17,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 18,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 19,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 20,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 21,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 22,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 23,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 24,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 25,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 26,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 27,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 28,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 29,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 30,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 31,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 32,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 33,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 34,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 35,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 36,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 37,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 38,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 39,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 40,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 41,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 42,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 43,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 44,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 45,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 46,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 47,
                column: "Pontos",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 48,
                column: "Pontos",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pontos",
                table: "Selecoes");

            migrationBuilder.DropColumn(
                name: "ApostasProcessadas",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "ClassificacaoProcessada",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "Pontos",
                table: "Apostas");
        }
    }
}
