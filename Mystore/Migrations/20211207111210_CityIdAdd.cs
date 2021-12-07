using Microsoft.EntityFrameworkCore.Migrations;

namespace Mystore.Api.Migrations
{
    public partial class CityIdAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Cities_CityId",
                table: "UserDetails");

            migrationBuilder.AlterColumn<long>(
                name: "CityId",
                table: "UserDetails",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Cities_CityId",
                table: "UserDetails",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Cities_CityId",
                table: "UserDetails");

            migrationBuilder.AlterColumn<long>(
                name: "CityId",
                table: "UserDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Cities_CityId",
                table: "UserDetails",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
