using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITRI_Project.Migrations
{
    public partial class addScriptSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "variableKey",
                table: "Nodes",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                defaultValueSql: "'[]'",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "response",
                table: "Nodes",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "'[]'",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "questionAudio",
                table: "Nodes",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true,
                oldDefaultValueSql: "'[]'");

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "key", "nodeID", "orderID", "question", "questionAudio", "scriptParameter", "type" },
                values: new object[] { 1, true, null, "n1-1", 1, 1, "測試問題01", null, null, (byte)1 });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "key", "nodeID", "orderID", "question", "questionAudio", "response", "scriptParameter", "type" },
                values: new object[] { 2, true, null, "n1-2", 1, 2, "測試選項", null, "['回覆01', '回覆02', '回覆03']", "{\"Options\":[\"選項01\",\"選項02\",\"選項03\"]}", (byte)2 });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "key", "nodeID", "orderID", "question", "questionAudio", "scriptParameter", "type", "variableKey" },
                values: new object[] { 3, true, null, "n1-3", 1, 3, "測試文字輸入{0}", null, null, (byte)3, "['n1-2']" });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "key", "nodeID", "orderID", "question", "questionAudio", "response", "scriptParameter", "type" },
                values: new object[] { 4, true, null, "n1-4", 1, 4, "測試多文字輸入", null, "['測試回覆']", "{\"Example\":\"範例範例範例\",\"FieldNum\":3}", (byte)4 });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "key", "nodeID", "orderID", "question", "questionAudio", "scriptParameter", "type" },
                values: new object[] { 5, false, null, "n1-5", 1, 5, "測試錄音", null, "", (byte)5 });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "key", "nodeID", "orderID", "question", "questionAudio", "response", "scriptParameter", "type" },
                values: new object[] { 6, true, null, "n1-6", 1, 6, "測試評分", null, "測試回覆", "{\"RatingScore\":[{\"Value\":0.2,\"Message\":\"階段01\"},{\"Value\":0.4,\"Message\":\"階段02\"},{\"Value\":0.6,\"Message\":\"階段03\"},{\"Value\":0.8,\"Message\":\"階段04\"},{\"Value\":1,\"Message\":\"階段05\"}],\"Tips\":[{\"Value\":0.33,\"Message\":\"提示01\"},{\"Value\":0.66,\"Message\":\"提示02\"},{\"Value\":1,\"Message\":\"提示03\"}]}", (byte)6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "variableKey",
                table: "Nodes",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true,
                oldDefaultValueSql: "'[]'");

            migrationBuilder.AlterColumn<string>(
                name: "response",
                table: "Nodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "'[]'");

            migrationBuilder.AlterColumn<string>(
                name: "questionAudio",
                table: "Nodes",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                defaultValueSql: "'[]'",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);
        }
    }
}
