using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITRI_Project.Migrations
{
    public partial class addFinishTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.CreateTable(
                name: "Finish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finish", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finish");

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "isGenerate", "key", "nodeID", "orderID", "question", "questionAudio", "scriptParameter", "type" },
                values: new object[] { 1, true, null, false, "n99-1", 99, 1, "測試問題01", null, "{\"AutoNext\":true}", (byte)1 });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "isGenerate", "key", "nodeID", "orderID", "question", "questionAudio", "response", "scriptParameter", "type" },
                values: new object[] { 2, true, null, false, "n99-2", 99, 2, "測試選項", null, "['回覆01', '回覆02', '回覆03']", "{\"Options\":[\"選項01\",\"選項02\",\"選項03\"]}", (byte)2 });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "isGenerate", "key", "nodeID", "orderID", "question", "questionAudio", "scriptParameter", "type", "variableKey" },
                values: new object[] { 3, true, null, false, "n99-3", 99, 3, "測試文字輸入{0}", null, null, (byte)3, "['n1-2']" });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "isGenerate", "key", "nodeID", "orderID", "question", "questionAudio", "response", "scriptParameter", "type" },
                values: new object[] { 4, true, null, false, "n99-4", 99, 4, "測試多文字輸入", null, "['測試回覆']", "{\"Field\":[{\"key\":\"n99-4_A\",\"placeholder\":\"測試01\"},{\"key\":\"n99-4_B\",\"placeholder\":\"測試02\"},{\"key\":\"n99-4_C\",\"placeholder\":\"測試03\"},{\"key\":\"n99-4_D\",\"placeholder\":\"測試04\"},{\"key\":\"n99-4_E\",\"placeholder\":\"測試05\"}]}", (byte)4 });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "isGenerate", "key", "nodeID", "orderID", "question", "questionAudio", "scriptParameter", "type" },
                values: new object[] { 5, false, null, false, "n99-5", 99, 5, "測試錄音", null, null, (byte)5 });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "isGenerate", "key", "nodeID", "orderID", "question", "questionAudio", "response", "scriptParameter", "type" },
                values: new object[,]
                {
                    { 6, true, null, false, "n99-6", 99, 6, "測試評分", null, "['測試回覆']", "{\"RatingScore\":[{\"Value\":0.2,\"Message\":\"階段01\"},{\"Value\":0.4,\"Message\":\"階段02\"},{\"Value\":0.6,\"Message\":\"階段03\"},{\"Value\":0.8,\"Message\":\"階段04\"},{\"Value\":1,\"Message\":\"階段05\"}],\"Tips\":[{\"Value\":0.33,\"Message\":\"提示01\"},{\"Value\":0.66,\"Message\":\"提示02\"},{\"Value\":1,\"Message\":\"提示03\"}]}", (byte)6 },
                    { 7, true, null, false, "n99-7", 99, 7, "測試資訊", null, "['回覆01','回覆02','回覆03','回覆04']", "{\"Options\":[\"選項01\",\"選項02\",\"選項03\",\"選項04\"]}", (byte)7 },
                    { 9, true, null, false, "n99-8", 99, 8, "測試影片播放", null, "[]", null, (byte)8 },
                    { 10, true, null, false, "n99-9", 99, 9, "測試音檔播放", "", "[]", null, (byte)9 }
                });
        }
    }
}
