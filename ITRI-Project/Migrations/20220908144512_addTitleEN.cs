using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITRI_Project.Migrations
{
    public partial class addTitleEN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TitleEN",
                table: "Map",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "nodeID",
                value: 99);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "nodeID",
                value: 99);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "nodeID",
                value: 99);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 4,
                column: "nodeID",
                value: 99);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 5,
                column: "nodeID",
                value: 99);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 6,
                column: "nodeID",
                value: 99);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 7,
                column: "nodeID",
                value: 99);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleEN",
                table: "Map");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "nodeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "nodeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "nodeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 4,
                column: "nodeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 5,
                column: "nodeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 6,
                column: "nodeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 7,
                column: "nodeID",
                value: 1);
        }
    }
}
