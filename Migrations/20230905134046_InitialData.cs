using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace curso_fundamentos_entity_framework_platzi.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Tarea",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Categoria",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "categoriaId", "descripcion", "nombre", "peso" },
                values: new object[,]
                {
                    { new Guid("a9a12388-8c1a-49d5-9f6a-932fe1ea4402"), null, "Actividades personales", 50 },
                    { new Guid("a9a12388-8c1a-49d5-9f6a-932fe1ea44a2"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "tareaId", "categoriaId", "descripcion", "estado", "fechaCreacion", "prioridad", "titulo" },
                values: new object[,]
                {
                    { new Guid("a9a12388-8c1a-49d5-9f6a-932fe1ea4410"), new Guid("a9a12388-8c1a-49d5-9f6a-932fe1ea44a2"), null, false, new DateTime(2023, 9, 5, 8, 40, 46, 726, DateTimeKind.Local).AddTicks(3296), 1, "Pago de servicios publicos" },
                    { new Guid("a9a12388-8c1a-49d5-9f6a-932fe1ea4411"), new Guid("a9a12388-8c1a-49d5-9f6a-932fe1ea4402"), null, false, new DateTime(2023, 9, 5, 8, 40, 46, 726, DateTimeKind.Local).AddTicks(3382), 0, "Terminar de ver peliculas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "tareaId",
                keyValue: new Guid("a9a12388-8c1a-49d5-9f6a-932fe1ea4410"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "tareaId",
                keyValue: new Guid("a9a12388-8c1a-49d5-9f6a-932fe1ea4411"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "categoriaId",
                keyValue: new Guid("a9a12388-8c1a-49d5-9f6a-932fe1ea4402"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "categoriaId",
                keyValue: new Guid("a9a12388-8c1a-49d5-9f6a-932fe1ea44a2"));

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Tarea",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Categoria",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}
