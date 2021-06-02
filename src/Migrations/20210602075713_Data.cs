using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ef.Test.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "table1",
                columns: new[] { "id", "table2_ids" },
                values: new object[,]
                {
                    { 1L, new[] { 1L } },
                    { 2L, new[] { 1L, 2L } },
                    { 3L, null }
                });

            migrationBuilder.InsertData(
                table: "table2",
                column: "id",
                values: new object[]
                {
                    1L,
                    2L
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "table1",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "table1",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "table1",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "table2",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "table2",
                keyColumn: "id",
                keyValue: 2L);
        }
    }
}
