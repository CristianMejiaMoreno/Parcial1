using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial1_CristiaMejia_JuanHerrera.Migrations
{
    /// <inheritdoc />
    public partial class add_timestamps_to_all_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Vivienda",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Vivienda",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Vivienda",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Venta",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Venta",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Venta",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TipoVivienda",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TipoVivienda",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TipoVivienda",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Cliente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cliente",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Cliente",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Agencia",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Agencia",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Agencia",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Vivienda");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Vivienda");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Vivienda");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TipoVivienda");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TipoVivienda");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TipoVivienda");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Agencia");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Agencia");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Agencia");
        }
    }
}
