using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat_App_DAL.Migrations
{
    public partial class setuprelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Messages_channel_id",
                table: "Messages",
                column: "channel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_user_id",
                table: "Messages",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Channels_channel_id",
                table: "Messages",
                column: "channel_id",
                principalTable: "Channels",
                principalColumn: "channel_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_user_id",
                table: "Messages",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Channels_channel_id",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_user_id",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_channel_id",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_user_id",
                table: "Messages");
        }
    }
}
