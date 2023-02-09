using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITRI_Project.Migrations
{
    public partial class changeNodeStruct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Nodes",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Nodes",
                newName: "orderID");

            migrationBuilder.RenameColumn(
                name: "NodeID",
                table: "Nodes",
                newName: "nodeID");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Nodes",
                newName: "key");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Nodes",
                newName: "scriptParameter");

            migrationBuilder.AddColumn<bool>(
                name: "hasFixedRep",
                table: "Nodes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "hints",
                table: "Nodes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "question",
                table: "Nodes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "questionAudio",
                table: "Nodes",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                defaultValueSql: "'[]'");

            migrationBuilder.AddColumn<string>(
                name: "response",
                table: "Nodes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "responseAudio",
                table: "Nodes",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                defaultValueSql: "'[]'");

            migrationBuilder.AddColumn<string>(
                name: "variableKey",
                table: "Nodes",
                type: "varchar(max)",
                unicode: false,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hasFixedRep",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "hints",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "question",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "questionAudio",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "response",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "responseAudio",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "variableKey",
                table: "Nodes");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Nodes",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "orderID",
                table: "Nodes",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "nodeID",
                table: "Nodes",
                newName: "NodeID");

            migrationBuilder.RenameColumn(
                name: "key",
                table: "Nodes",
                newName: "Key");

            migrationBuilder.RenameColumn(
                name: "scriptParameter",
                table: "Nodes",
                newName: "Content");
        }
    }
}
