using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat_App_DAL.Migrations
{
    public partial class AddedTextfieldtoMessagetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "message",
                table: "Messages",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "message",
                table: "Messages");
        }
    }
}
