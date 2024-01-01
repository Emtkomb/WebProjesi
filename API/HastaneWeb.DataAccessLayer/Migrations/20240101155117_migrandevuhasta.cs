using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneWeb.DataAccessLayer.Migrations
{
    public partial class migrandevuhasta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Randevular");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Randevular",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_AppUserId",
                table: "Randevular",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_AspNetUsers_AppUserId",
                table: "Randevular",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_AspNetUsers_AppUserId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_AppUserId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Randevular");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
