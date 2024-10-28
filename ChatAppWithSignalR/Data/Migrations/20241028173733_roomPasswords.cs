using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatAppWithSignalR.Data.Migrations
{
    /// <inheritdoc />
    public partial class roomPasswords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasPassword",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPassword",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Rooms");
        }
    }
}
