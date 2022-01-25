using Microsoft.EntityFrameworkCore.Migrations;

namespace Mystore.Api.Migrations
{
    public partial class ApplicantsToProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProjectId",
                table: "AspNetUsers",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Projects_ProjectId",
                table: "AspNetUsers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Projects_ProjectId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProjectId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "AspNetUsers");
        }
    }
}
