using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSProject.Migrations
{
    public partial class RelacionCarreraGrupo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Grupos_idCarrera",
                table: "Grupos",
                column: "idCarrera");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Carreras_idCarrera",
                table: "Grupos",
                column: "idCarrera",
                principalTable: "Carreras",
                principalColumn: "idCarrera",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Carreras_idCarrera",
                table: "Grupos");

            migrationBuilder.DropIndex(
                name: "IX_Grupos_idCarrera",
                table: "Grupos");
        }
    }
}
