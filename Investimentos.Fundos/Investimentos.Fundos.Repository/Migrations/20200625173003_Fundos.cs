using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Investimentos.Fundos.Repository.Migrations
{
    public partial class Fundos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fundo",
                columns: table => new
                {
                    IdFundo = table.Column<Guid>(nullable: false),
                    NomeFundo = table.Column<string>(nullable: false),
                    CnpjFundo = table.Column<string>(nullable: false),
                    InvestimentoInicialMinimo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundo", x => x.IdFundo);
                });

            migrationBuilder.CreateTable(
                name: "Movimento",
                columns: table => new
                {
                    IdMovimento = table.Column<Guid>(nullable: false),
                    TipoMovimento = table.Column<int>(nullable: false),
                    IdFundo = table.Column<Guid>(nullable: false),
                    CpfCliente = table.Column<string>(nullable: false),
                    ValorMovimento = table.Column<decimal>(nullable: false),
                    DataMovimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimento", x => x.IdMovimento);
                    table.ForeignKey(
                        name: "FK_Movimento_Fundo_IdFundo",
                        column: x => x.IdFundo,
                        principalTable: "Fundo",
                        principalColumn: "IdFundo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_IdFundo",
                table: "Movimento",
                column: "IdFundo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimento");

            migrationBuilder.DropTable(
                name: "Fundo");
        }
    }
}
