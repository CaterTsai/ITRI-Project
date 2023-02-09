using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITRI_Project.Migrations
{
    public partial class seedingNewType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "key", "nodeID", "orderID", "question", "questionAudio", "response", "scriptParameter", "type" },
                values: new object[] { 9, true, null, "n99-8", 99, 8, "測試影片播放", null, "[]", null, (byte)8 });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "key", "nodeID", "orderID", "question", "questionAudio", "response", "scriptParameter", "type" },
                values: new object[] { 10, true, null, "n99-9", 99, 9, "測試音檔播放", "", "[]", null, (byte)9 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
