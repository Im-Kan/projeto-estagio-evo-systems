using Microsoft.EntityFrameworkCore.Migrations;

namespace Funcionarios.data.Migrations
{
    public partial class WorkerFoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Worker",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Worker");
        }
    }
}
