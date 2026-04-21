using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoDaCopa2026.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BandeiraUrl", "Nome" },
                values: new object[] { "https://flagcdn.com/w40/cz.png", "República Tcheca" });

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BandeiraUrl", "Nome" },
                values: new object[] { "https://flagcdn.com/w40/ba.png", "Bósnia e Herzegovina" });

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BandeiraUrl", "Nome" },
                values: new object[] { "https://flagcdn.com/w40/tr.png", "Turquia" });

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BandeiraUrl", "Nome" },
                values: new object[] { "https://flagcdn.com/w40/se.png", "Suécia" });

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "BandeiraUrl", "Nome" },
                values: new object[] { "https://flagcdn.com/w40/iq.png", "Iraque" });

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "BandeiraUrl", "Nome" },
                values: new object[] { "https://flagcdn.com/w40/cd.png", "RD Congo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BandeiraUrl", "Nome" },
                values: new object[] { "https://flagcdn.com/w40/eu.png", "Repescagem Europa D" });

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BandeiraUrl", "Nome" },
                values: new object[] { "https://flagcdn.com/w40/eu.png", "Repescagem Europa A" });

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BandeiraUrl", "Nome" },
                values: new object[] { "https://flagcdn.com/w40/eu.png", "Repescagem Europa C" });

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BandeiraUrl", "Nome" },
                values: new object[] { "https://flagcdn.com/w40/eu.png", "Repescagem Europa B" });

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "BandeiraUrl", "Nome" },
                values: new object[] { "https://flagcdn.com/w40/un.png", "Repescagem Intercontinental 2" });

            migrationBuilder.UpdateData(
                table: "Selecoes",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "BandeiraUrl", "Nome" },
                values: new object[] { "https://flagcdn.com/w40/un.png", "Repescagem Intercontinental 1" });
        }
    }
}
