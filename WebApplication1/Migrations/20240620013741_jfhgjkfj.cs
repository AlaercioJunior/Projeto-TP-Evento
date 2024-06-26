using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_MS_Evento.Migrations
{
    /// <inheritdoc />
    public partial class jfhgjkfj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Local = table.Column<string>(type: "TEXT", nullable: false),
                    Atracao = table.Column<string>(type: "TEXT", nullable: false),
                    ValorIngresso = table.Column<decimal>(type: "TEXT", nullable: false),
                    QuantidadeIngresso = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantidadeVendida = table.Column<int>(type: "INTEGER", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cancelado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evento");
        }
    }
}
