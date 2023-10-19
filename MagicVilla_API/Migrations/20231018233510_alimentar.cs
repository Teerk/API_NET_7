using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class alimentar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImageUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la villa", new DateTime(2023, 10, 18, 17, 35, 10, 439, DateTimeKind.Local).AddTicks(3523), new DateTime(2023, 10, 18, 17, 35, 10, 439, DateTimeKind.Local).AddTicks(3513), "", 345, "Villa Real", 4, 1313.0 },
                    { 2, "", "Detalle de la villa", new DateTime(2023, 10, 18, 17, 35, 10, 439, DateTimeKind.Local).AddTicks(3525), new DateTime(2023, 10, 18, 17, 35, 10, 439, DateTimeKind.Local).AddTicks(3525), "", 345, "Villa Real II", 4, 1313.0 },
                    { 3, "", "Detalle de la villa", new DateTime(2023, 10, 18, 17, 35, 10, 439, DateTimeKind.Local).AddTicks(3527), new DateTime(2023, 10, 18, 17, 35, 10, 439, DateTimeKind.Local).AddTicks(3527), "", 345, "Villa Real", 4, 1313.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
