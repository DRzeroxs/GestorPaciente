using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorPaciente.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class verSolucion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PruebaId",
                table: "ResultadoLaboratorios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PruebaId",
                table: "ResultadoLaboratorios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
