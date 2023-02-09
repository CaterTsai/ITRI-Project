using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITRI_Project.Migrations
{
    public partial class addNewQuestionType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 7,
                column: "scriptParameter",
                value: "{\"Options\":[\"選項01\",\"選項02\",\"選項03\",\"選項04\"]}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 7,
                column: "scriptParameter",
                value: "{\"RatingScore\":[{\"Value\":0.2,\"Message\":\"階段01\"},{\"Value\":0.4,\"Message\":\"階段02\"},{\"Value\":0.6,\"Message\":\"階段03\"},{\"Value\":0.8,\"Message\":\"階段04\"},{\"Value\":1,\"Message\":\"階段05\"}],\"Tips\":[{\"Value\":0.33,\"Message\":\"提示01\"},{\"Value\":0.66,\"Message\":\"提示02\"},{\"Value\":1,\"Message\":\"提示03\"}]}");
        }
    }
}
