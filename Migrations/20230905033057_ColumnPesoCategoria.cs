using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace curso_fundamentos_entity_framework_platzi.Migrations
{
    /// <inheritdoc />
    public partial class ColumnPesoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "peso",
                table: "Categoria",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "peso",
                table: "Categoria");
        }
    }
}
