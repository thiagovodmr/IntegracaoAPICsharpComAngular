using Microsoft.EntityFrameworkCore.Migrations;

namespace APIWebApplication.Migrations
{
    public partial class Alterandonomedocampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Notas",
                newName: "DataCriacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Notas",
                newName: "DateTime");
        }
    }
}
