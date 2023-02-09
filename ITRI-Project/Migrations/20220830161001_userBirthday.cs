using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITRI_Project.Migrations
{
    public partial class userBirthday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "UserInfo",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "UserInfo");
        }
    }
}
