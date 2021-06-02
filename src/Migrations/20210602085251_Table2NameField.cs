using Microsoft.EntityFrameworkCore.Migrations;

namespace Ef.Test.Migrations
{
    public partial class Table2NameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "table2",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "table2",
                keyColumn: "id",
                keyValue: 1L,
                column: "name",
                value: "Name1");

            migrationBuilder.UpdateData(
                table: "table2",
                keyColumn: "id",
                keyValue: 2L,
                column: "name",
                value: "Name2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "table2");
        }
    }
}
