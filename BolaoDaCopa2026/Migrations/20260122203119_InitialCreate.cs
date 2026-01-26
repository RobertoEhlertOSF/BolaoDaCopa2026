using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BolaoDaCopa2026.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Selecoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Grupo = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false),
                    BandeiraUrl = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    GolsPro = table.Column<int>(type: "INTEGER", nullable: false),
                    GolsContra = table.Column<int>(type: "INTEGER", nullable: false),
                    Jogos = table.Column<int>(type: "INTEGER", nullable: false),
                    Vitorias = table.Column<int>(type: "INTEGER", nullable: false),
                    Empates = table.Column<int>(type: "INTEGER", nullable: false),
                    Derrotas = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selecoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SelecaoAId = table.Column<int>(type: "INTEGER", nullable: false),
                    SelecaoBId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstaAberto = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fase = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    GolsSelecaoA = table.Column<int>(type: "INTEGER", nullable: true),
                    GolsSelecaoB = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogos_Selecoes_SelecaoAId",
                        column: x => x.SelecaoAId,
                        principalTable: "Selecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jogos_Selecoes_SelecaoBId",
                        column: x => x.SelecaoBId,
                        principalTable: "Selecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apostadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPago = table.Column<bool>(type: "INTEGER", nullable: false),
                    Pontuacao = table.Column<int>(type: "INTEGER", nullable: false),
                    PalpitesExatos = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apostadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apostadores_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apostas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JogoId = table.Column<int>(type: "INTEGER", nullable: false),
                    SelecaoAId = table.Column<int>(type: "INTEGER", nullable: false),
                    SelecaoBId = table.Column<int>(type: "INTEGER", nullable: false),
                    GolsSelecaoA = table.Column<int>(type: "INTEGER", nullable: false),
                    GolsSelecaoB = table.Column<int>(type: "INTEGER", nullable: false),
                    ApostadorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apostas_Apostadores_ApostadorId",
                        column: x => x.ApostadorId,
                        principalTable: "Apostadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apostas_Jogos_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apostas_Selecoes_SelecaoAId",
                        column: x => x.SelecaoAId,
                        principalTable: "Selecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apostas_Selecoes_SelecaoBId",
                        column: x => x.SelecaoBId,
                        principalTable: "Selecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Selecoes",
                columns: new[] { "Id", "BandeiraUrl", "Derrotas", "Empates", "GolsContra", "GolsPro", "Grupo", "Jogos", "Nome", "Vitorias" },
                values: new object[,]
                {
                    { 1, "https://flagcdn.com/w40/mx.png", 0, 0, 0, 0, "A", 0, "México", 0 },
                    { 2, "https://flagcdn.com/w40/za.png", 0, 0, 0, 0, "A", 0, "África do Sul", 0 },
                    { 3, "https://flagcdn.com/w40/kr.png", 0, 0, 0, 0, "A", 0, "Coreia do Sul", 0 },
                    { 4, "https://flagcdn.com/w40/eu.png", 0, 0, 0, 0, "A", 0, "Repescagem Europa D", 0 },
                    { 5, "https://flagcdn.com/w40/ca.png", 0, 0, 0, 0, "B", 0, "Canadá", 0 },
                    { 6, "https://flagcdn.com/w40/eu.png", 0, 0, 0, 0, "B", 0, "Repescagem Europa A", 0 },
                    { 7, "https://flagcdn.com/w40/qa.png", 0, 0, 0, 0, "B", 0, "Catar", 0 },
                    { 8, "https://flagcdn.com/w40/ch.png", 0, 0, 0, 0, "B", 0, "Suíça", 0 },
                    { 9, "https://flagcdn.com/w40/br.png", 0, 0, 0, 0, "C", 0, "Brasil", 0 },
                    { 10, "https://flagcdn.com/w40/ma.png", 0, 0, 0, 0, "C", 0, "Marrocos", 0 },
                    { 11, "https://flagcdn.com/w40/ht.png", 0, 0, 0, 0, "C", 0, "Haiti", 0 },
                    { 12, "https://flagcdn.com/w40/gb-sct.png", 0, 0, 0, 0, "C", 0, "Escócia", 0 },
                    { 13, "https://flagcdn.com/w40/us.png", 0, 0, 0, 0, "D", 0, "Estados Unidos", 0 },
                    { 14, "https://flagcdn.com/w40/py.png", 0, 0, 0, 0, "D", 0, "Paraguai", 0 },
                    { 15, "https://flagcdn.com/w40/au.png", 0, 0, 0, 0, "D", 0, "Austrália", 0 },
                    { 16, "https://flagcdn.com/w40/eu.png", 0, 0, 0, 0, "D", 0, "Repescagem Europa C", 0 },
                    { 17, "https://flagcdn.com/w40/de.png", 0, 0, 0, 0, "E", 0, "Alemanha", 0 },
                    { 18, "https://flagcdn.com/w40/cw.png", 0, 0, 0, 0, "E", 0, "Curaçao", 0 },
                    { 19, "https://flagcdn.com/w40/ci.png", 0, 0, 0, 0, "E", 0, "Costa do Marfim", 0 },
                    { 20, "https://flagcdn.com/w40/ec.png", 0, 0, 0, 0, "E", 0, "Equador", 0 },
                    { 21, "https://flagcdn.com/w40/nl.png", 0, 0, 0, 0, "F", 0, "Holanda", 0 },
                    { 22, "https://flagcdn.com/w40/jp.png", 0, 0, 0, 0, "F", 0, "Japão", 0 },
                    { 23, "https://flagcdn.com/w40/eu.png", 0, 0, 0, 0, "F", 0, "Repescagem Europa B", 0 },
                    { 24, "https://flagcdn.com/w40/tn.png", 0, 0, 0, 0, "F", 0, "Tunísia", 0 },
                    { 25, "https://flagcdn.com/w40/be.png", 0, 0, 0, 0, "G", 0, "Bélgica", 0 },
                    { 26, "https://flagcdn.com/w40/eg.png", 0, 0, 0, 0, "G", 0, "Egito", 0 },
                    { 27, "https://flagcdn.com/w40/ir.png", 0, 0, 0, 0, "G", 0, "Irã", 0 },
                    { 28, "https://flagcdn.com/w40/nz.png", 0, 0, 0, 0, "G", 0, "Nova Zelândia", 0 },
                    { 29, "https://flagcdn.com/w40/es.png", 0, 0, 0, 0, "H", 0, "Espanha", 0 },
                    { 30, "https://flagcdn.com/w40/cv.png", 0, 0, 0, 0, "H", 0, "Cabo Verde", 0 },
                    { 31, "https://flagcdn.com/w40/sa.png", 0, 0, 0, 0, "H", 0, "Arábia Saudita", 0 },
                    { 32, "https://flagcdn.com/w40/uy.png", 0, 0, 0, 0, "H", 0, "Uruguai", 0 },
                    { 33, "https://flagcdn.com/w40/fr.png", 0, 0, 0, 0, "I", 0, "França", 0 },
                    { 34, "https://flagcdn.com/w40/sn.png", 0, 0, 0, 0, "I", 0, "Senegal", 0 },
                    { 35, "https://flagcdn.com/w40/un.png", 0, 0, 0, 0, "I", 0, "Repescagem Intercontinental 2", 0 },
                    { 36, "https://flagcdn.com/w40/no.png", 0, 0, 0, 0, "I", 0, "Noruega", 0 },
                    { 37, "https://flagcdn.com/w40/ar.png", 0, 0, 0, 0, "J", 0, "Argentina", 0 },
                    { 38, "https://flagcdn.com/w40/dz.png", 0, 0, 0, 0, "J", 0, "Argélia", 0 },
                    { 39, "https://flagcdn.com/w40/at.png", 0, 0, 0, 0, "J", 0, "Áustria", 0 },
                    { 40, "https://flagcdn.com/w40/jo.png", 0, 0, 0, 0, "J", 0, "Jordânia", 0 },
                    { 41, "https://flagcdn.com/w40/pt.png", 0, 0, 0, 0, "K", 0, "Portugal", 0 },
                    { 42, "https://flagcdn.com/w40/un.png", 0, 0, 0, 0, "K", 0, "Repescagem Intercontinental 1", 0 },
                    { 43, "https://flagcdn.com/w40/uz.png", 0, 0, 0, 0, "K", 0, "Uzbequistão", 0 },
                    { 44, "https://flagcdn.com/w40/co.png", 0, 0, 0, 0, "K", 0, "Colômbia", 0 },
                    { 45, "https://flagcdn.com/w40/gb-eng.png", 0, 0, 0, 0, "L", 0, "Inglaterra", 0 },
                    { 46, "https://flagcdn.com/w40/hr.png", 0, 0, 0, 0, "L", 0, "Croácia", 0 },
                    { 47, "https://flagcdn.com/w40/gh.png", 0, 0, 0, 0, "L", 0, "Gana", 0 },
                    { 48, "https://flagcdn.com/w40/pa.png", 0, 0, 0, 0, "L", 0, "Panamá", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apostadores_UsuarioId",
                table: "Apostadores",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apostas_ApostadorId",
                table: "Apostas",
                column: "ApostadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Apostas_JogoId",
                table: "Apostas",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apostas_SelecaoAId",
                table: "Apostas",
                column: "SelecaoAId");

            migrationBuilder.CreateIndex(
                name: "IX_Apostas_SelecaoBId",
                table: "Apostas",
                column: "SelecaoBId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_SelecaoAId",
                table: "Jogos",
                column: "SelecaoAId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_SelecaoBId",
                table: "Jogos",
                column: "SelecaoBId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apostas");

            migrationBuilder.DropTable(
                name: "Apostadores");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Selecoes");
        }
    }
}
