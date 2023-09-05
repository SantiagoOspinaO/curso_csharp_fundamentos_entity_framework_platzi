using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace curso_fundamentos_entity_framework_platzi.Migrations
{
    /// <inheritdoc />
    public partial class ColumnEstadoTarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "Tarea",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "Tarea");
        }
    }
}
