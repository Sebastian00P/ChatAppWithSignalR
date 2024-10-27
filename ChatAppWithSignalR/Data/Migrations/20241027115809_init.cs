using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatAppWithSignalR.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoomEntityChatRoomId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ChatRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ChatRoomId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChatRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomEntityChatRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Rooms_RoomEntityChatRoomId",
                        column: x => x.RoomEntityChatRoomId,
                        principalTable: "Rooms",
                        principalColumn: "ChatRoomId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoomEntityChatRoomId",
                table: "AspNetUsers",
                column: "RoomEntityChatRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RoomEntityChatRoomId",
                table: "Messages",
                column: "RoomEntityChatRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Rooms_RoomEntityChatRoomId",
                table: "AspNetUsers",
                column: "RoomEntityChatRoomId",
                principalTable: "Rooms",
                principalColumn: "ChatRoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Rooms_RoomEntityChatRoomId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoomEntityChatRoomId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoomEntityChatRoomId",
                table: "AspNetUsers");
        }
    }
}
