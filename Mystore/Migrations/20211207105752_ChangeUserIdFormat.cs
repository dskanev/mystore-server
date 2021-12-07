using Microsoft.EntityFrameworkCore.Migrations;

namespace Mystore.Api.Migrations
{
    public partial class ChangeUserIdFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_AspNetUsers_UserId1",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_UserId1",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserDetails");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserDetails",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_AspNetUsers_UserId",
                table: "UserDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_AspNetUsers_UserId",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UserDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId1",
                table: "UserDetails",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_AspNetUsers_UserId1",
                table: "UserDetails",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
