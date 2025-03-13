using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial1_CristiaMejia_JuanHerrera.Migrations
{
    /// <inheritdoc />
    public partial class add_new_tables_vivienda_venta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vivienda",
                columns: table => new
                {
                    IdVivienda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAgencia = table.Column<int>(type: "int", nullable: false),
                    IdTipoVivienda = table.Column<int>(type: "int", nullable: false),
                    NumeroCuartos = table.Column<int>(type: "int", nullable: false),
                    NumeroBanos = table.Column<int>(type: "int", nullable: false),
                    TamanoM2 = table.Column<int>(type: "int", nullable: false),
                    NumeroPisos = table.Column<int>(type: "int", nullable: false),
                    Accesorios = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vivienda", x => x.IdVivienda);
                    table.ForeignKey(
                        name: "FK_Vivienda_Agencia_IdAgencia",
                        column: x => x.IdAgencia,
                        principalTable: "Agencia",
                        principalColumn: "IdAgencia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vivienda_TipoVivienda_IdTipoVivienda",
                        column: x => x.IdTipoVivienda,
                        principalTable: "TipoVivienda",
                        principalColumn: "IdTipoVivienda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAgencia = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdVivienda = table.Column<int>(type: "int", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "date", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_Venta_Agencia_IdAgencia",
                        column: x => x.IdAgencia,
                        principalTable: "Agencia",
                        principalColumn: "IdAgencia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Venta_Vivienda_IdVivienda",
                        column: x => x.IdVivienda,
                        principalTable: "Vivienda",
                        principalColumn: "IdVivienda",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdAgencia",
                table: "Venta",
                column: "IdAgencia");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdCliente",
                table: "Venta",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdVivienda",
                table: "Venta",
                column: "IdVivienda");

            migrationBuilder.CreateIndex(
                name: "IX_Vivienda_IdAgencia",
                table: "Vivienda",
                column: "IdAgencia");

            migrationBuilder.CreateIndex(
                name: "IX_Vivienda_IdTipoVivienda",
                table: "Vivienda",
                column: "IdTipoVivienda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Vivienda");
        }
    }
}
