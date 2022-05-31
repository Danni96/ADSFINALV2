using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSProject.Migrations
{
    public partial class RelacionProfesoresGrupos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Grupos_idMateria",
                table: "Grupos",
                column: "idMateria");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_idProfesor",
                table: "Grupos",
                column: "idProfesor");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Materias_idMateria",
                table: "Grupos",
                column: "idMateria",
                principalTable: "Materias",
                principalColumn: "idMateria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Profesores_idProfesor",
                table: "Grupos",
                column: "idProfesor",
                principalTable: "Profesores",
                principalColumn: "idProfesor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Materias_idMateria",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Profesores_idProfesor",
                table: "Grupos");

            migrationBuilder.DropIndex(
                name: "IX_Grupos_idMateria",
                table: "Grupos");

            migrationBuilder.DropIndex(
                name: "IX_Grupos_idProfesor",
                table: "Grupos");
        }
    }
}
