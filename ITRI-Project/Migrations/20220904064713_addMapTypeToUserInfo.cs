using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITRI_Project.Migrations
{
    public partial class addMapTypeToUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "NowMapType",
                table: "UserInfo",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)1);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "scriptParameter",
                value: "{\"AutoNext\":true}");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 4,
                column: "scriptParameter",
                value: "{\"Example\":\"範例範例範例\",\"FieldName\":[\"A\",\"B\",\"C\"]}");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 5,
                column: "scriptParameter",
                value: null);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 6,
                column: "response",
                value: "['測試回覆']");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NowMapType",
                table: "UserInfo");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "scriptParameter",
                value: null);

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 4,
                column: "scriptParameter",
                value: "{\"Example\":\"範例範例範例\",\"FieldNum\":3}");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 5,
                column: "scriptParameter",
                value: "");

            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 6,
                column: "response",
                value: "測試回覆");
        }
    }
}
