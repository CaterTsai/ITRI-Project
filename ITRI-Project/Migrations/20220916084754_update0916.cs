using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITRI_Project.Migrations
{
    public partial class update0916 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isGenerate",
                table: "Nodes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TriggerDistance",
                table: "Map",
                type: "float",
                nullable: false,
                defaultValue: 10.0);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 4,
                column: "scriptParameter",
                value: "{\"Field\":[{\"key\":\"n99-4_A\",\"placeholder\":\"測試01\"},{\"key\":\"n99-4_B\",\"placeholder\":\"測試02\"},{\"key\":\"n99-4_C\",\"placeholder\":\"測試03\"},{\"key\":\"n99-4_D\",\"placeholder\":\"測試04\"},{\"key\":\"n99-4_E\",\"placeholder\":\"測試05\"}]}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isGenerate",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "TriggerDistance",
                table: "Map");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 4,
                column: "scriptParameter",
                value: "{\"Example\":\"範例範例範例\",\"FieldName\":[\"A\",\"B\",\"C\"]}");
        }
    }
}
