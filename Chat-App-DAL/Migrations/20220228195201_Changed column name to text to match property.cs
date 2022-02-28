using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat_App_DAL.Migrations
{
    public partial class Changedcolumnnametotexttomatchproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "message",
                table: "Messages",
                newName: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "text",
                table: "Messages",
                newName: "message");
        }
    }
}
