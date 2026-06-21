using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoDaCopa2026.Migrations
{
    /// <inheritdoc />
    public partial class AddSelecaoVencedoraNaAposta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelecaoVencedoraId",
                table: "Apostas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 1,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/mx.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 2,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/za.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 3,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/kr.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 4,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/cz.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 5,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/ca.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 6,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/ba.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 7,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/qa.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 8,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/ch.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 9,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/br.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 10,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/ma.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 11,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/ht.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 12,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/gb-sct.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 13,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/us.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 14,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/py.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 15,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/au.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 16,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/tr.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 17,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/de.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 18,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/cw.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 19,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/ci.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 20,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/ec.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 21,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/nl.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 22,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/jp.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 23,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/se.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 24,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/tn.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 25,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/be.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 26,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/eg.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 27,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/ir.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 28,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/nz.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 29,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/es.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 30,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/cv.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 31,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/sa.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 32,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/uy.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 33,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/fr.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 34,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/sn.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 35,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/iq.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 36,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/no.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 37,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/ar.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 38,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/dz.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 39,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/at.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 40,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/jo.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 41,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/pt.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 42,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/cd.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 43,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/uz.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 44,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/co.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 45,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/gb-eng.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 46,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/hr.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 47,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/gh.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 48,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w160/pa.png");

            migrationBuilder.CreateIndex(
                name: "IX_Apostas_SelecaoVencedoraId",
                table: "Apostas",
                column: "SelecaoVencedoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apostas_Selecoes_SelecaoVencedoraId",
                table: "Apostas",
                column: "SelecaoVencedoraId",
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

            migrationBuilder.DropIndex(
                name: "IX_Apostas_SelecaoVencedoraId",
                table: "Apostas");

            migrationBuilder.DropColumn(
                name: "SelecaoVencedoraId",
                table: "Apostas");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 1,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/mx.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 2,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/za.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 3,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/kr.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 4,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/cz.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 5,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/ca.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 6,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/ba.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 7,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/qa.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 8,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/ch.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 9,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/br.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 10,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/ma.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 11,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/ht.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 12,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/gb-sct.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 13,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/us.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 14,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/py.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 15,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/au.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 16,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/tr.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 17,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/de.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 18,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/cw.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 19,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/ci.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 20,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/ec.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 21,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/nl.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 22,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/jp.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 23,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/se.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 24,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/tn.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 25,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/be.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 26,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/eg.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 27,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/ir.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 28,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/nz.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 29,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/es.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 30,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/cv.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 31,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/sa.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 32,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/uy.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 33,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/fr.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 34,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/sn.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 35,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/iq.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 36,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/no.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 37,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/ar.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 38,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/dz.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 39,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/at.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 40,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/jo.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 41,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/pt.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 42,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/cd.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 43,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/uz.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 44,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/co.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 45,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/gb-eng.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 46,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/hr.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 47,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/gh.png");

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 48,
                column: "BandeiraUrl",
                value: "https://flagcdn.com/w40/pa.png");
        }
    }
}
