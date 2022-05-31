using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSProject.Migrations
{
    public partial class MyfirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    idCarrera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCarrera = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NombreCarrera = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.idCarrera);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    idGrupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCarrera = table.Column<int>(type: "int", nullable: false),
                    idMateria = table.Column<int>(type: "int", nullable: false),
                    idProfesor = table.Column<int>(type: "int", nullable: false),
                    ciclo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    anio = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.idGrupo);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    idMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreMateria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.idMateria);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    idProfesor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreProfesor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellidoProfesor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    correoEstudiante = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.idProfesor);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    idEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombresEstudiante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellidosEstudiante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codigoEstudiante = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    correoEstudiante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    idCarrera = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.idEstudiante);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Carreras_idCarrera",
                        column: x => x.idCarrera,
                        principalTable: "Carreras",
                        principalColumn: "idCarrera",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_idCarrera",
                table: "Estudiantes",
                column: "idCarrera");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Carreras");
        }
    }
}
