using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITRI_Project.Migrations
{
    public partial class changeSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "key",
                value: "n99-1");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "key",
                value: "n99-2");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "key",
                value: "n99-3");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 4,
                column: "key",
                value: "n99-4");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 5,
                column: "key",
                value: "n99-5");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 6,
                column: "key",
                value: "n99-6");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 7,
                column: "key",
                value: "n99-7");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "key",
                value: "n1-1");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "key",
                value: "n1-2");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "key",
                value: "n1-3");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 4,
                column: "key",
                value: "n1-4");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 5,
                column: "key",
                value: "n1-5");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 6,
                column: "key",
                value: "n1-6");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 7,
                column: "key",
                value: "n1-7");
        }
    }
}
