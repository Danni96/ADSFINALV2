using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSProject.Migrations
{
    public partial class RelacionCarreraMateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idCarrera",
                table: "Materias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Materias_idCarrera",
                table: "Materias",
                column: "idCarrera");

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Carreras_idCarrera",
                table: "Materias",
                column: "idCarrera",
                principalTable: "Carreras",
                principalColumn: "idCarrera",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Carreras_idCarrera",
                table: "Materias");

            migrationBuilder.DropIndex(
                name: "IX_Materias_idCarrera",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "idCarrera",
                table: "Materias");
        }
    }
}
