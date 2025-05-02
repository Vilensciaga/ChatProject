using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddeUserChatsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChat_Chats_ChatId",
                table: "UserChat");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChat_Users_UserId",
                table: "UserChat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChat",
                table: "UserChat");

            migrationBuilder.RenameTable(
                name: "UserChat",
                newName: "UserChats");

            migrationBuilder.RenameIndex(
                name: "IX_UserChat_ChatId",
                table: "UserChats",
                newName: "IX_UserChats_ChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChats",
                table: "UserChats",
                columns: new[] { "UserId", "ChatId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserChats_Chats_ChatId",
                table: "UserChats",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChats_Users_UserId",
                table: "UserChats",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChats_Chats_ChatId",
                table: "UserChats");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChats_Users_UserId",
                table: "UserChats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChats",
                table: "UserChats");

            migrationBuilder.RenameTable(
                name: "UserChats",
                newName: "UserChat");

            migrationBuilder.RenameIndex(
                name: "IX_UserChats_ChatId",
                table: "UserChat",
                newName: "IX_UserChat_ChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChat",
                table: "UserChat",
                columns: new[] { "UserId", "ChatId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserChat_Chats_ChatId",
                table: "UserChat",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChat_Users_UserId",
                table: "UserChat",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
