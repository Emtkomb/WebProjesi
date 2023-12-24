using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneWeb.DataAccessLayer.Migrations
{
    public partial class migbirimdoktor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BirimID",
                table: "Doktorlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_BirimID",
                table: "Doktorlar",
                column: "BirimID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktorlar_Birimler_BirimID",
                table: "Doktorlar",
                column: "BirimID",
                principalTable: "Birimler",
                principalColumn: "BirimID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_Birimler_BirimID",
                table: "Doktorlar");

            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_BirimID",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "BirimID",
                table: "Doktorlar");
        }
    }
}
