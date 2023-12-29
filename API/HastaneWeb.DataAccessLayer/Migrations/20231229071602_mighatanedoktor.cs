using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneWeb.DataAccessLayer.Migrations
{
    public partial class mighatanedoktor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HastaneID",
                table: "Doktorlar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_HastaneID",
                table: "Doktorlar",
                column: "HastaneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktorlar_Hastaneler_HastaneID",
                table: "Doktorlar",
                column: "HastaneID",
                principalTable: "Hastaneler",
                principalColumn: "HastaneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_Hastaneler_HastaneID",
                table: "Doktorlar");

            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_HastaneID",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "HastaneID",
                table: "Doktorlar");
        }
    }
}
