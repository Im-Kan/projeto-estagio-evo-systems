using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Funcionarios.data.Migrations
{
    public partial class DefaultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Nomes" },
                values: new object[] { new Guid("e28234c7-e309-418e-9367-f6c456469cf1"), "userdefault@funcionarios.com", "User Default" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e28234c7-e309-418e-9367-f6c456469cf1"));
        }
    }
}
