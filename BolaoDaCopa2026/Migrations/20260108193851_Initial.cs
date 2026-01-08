using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoDaCopa2026.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Grupo = table.Column<string>(type: "TEXT", nullable: false),
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
                name: "Apostadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                name: "IX_Apostas_SelecaoAId",
                table: "Apostas",
                column: "SelecaoAId");

            migrationBuilder.CreateIndex(
                name: "IX_Apostas_SelecaoBId",
                table: "Apostas",
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
                name: "Selecoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
