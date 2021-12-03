using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Funcionarios.data.Migrations
{
    public partial class Fixingdefaultuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e28234c7-e309-418e-9367-f6c456469cf1"),
                column: "DateCreated",
                value: new DateTime(2021, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e28234c7-e309-418e-9367-f6c456469cf1"),
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
