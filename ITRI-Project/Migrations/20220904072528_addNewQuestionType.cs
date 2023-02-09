using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITRI_Project.Migrations
{
    public partial class addNewQuestionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "hasFixedRep", "hints", "key", "nodeID", "orderID", "question", "questionAudio", "response", "scriptParameter", "type" },
                values: new object[] { 7, true, null, "n1-7", 1, 7, "測試資訊", null, "['回覆01','回覆02','回覆03','回覆04']", "{\"RatingScore\":[{\"Value\":0.2,\"Message\":\"階段01\"},{\"Value\":0.4,\"Message\":\"階段02\"},{\"Value\":0.6,\"Message\":\"階段03\"},{\"Value\":0.8,\"Message\":\"階段04\"},{\"Value\":1,\"Message\":\"階段05\"}],\"Tips\":[{\"Value\":0.33,\"Message\":\"提示01\"},{\"Value\":0.66,\"Message\":\"提示02\"},{\"Value\":1,\"Message\":\"提示03\"}]}", (byte)7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
