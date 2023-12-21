using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneWeb.DataAccessLayer.Migrations
{
    public partial class sonmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoktorID",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BirimID",
                table: "Doktorlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HastaneID",
                table: "Doktorlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_DoktorID",
                table: "Randevular",
                column: "DoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_BirimID",
                table: "Doktorlar",
                column: "BirimID");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_HastaneID",
                table: "Doktorlar",
                column: "HastaneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktorlar_Birimler_BirimID",
                table: "Doktorlar",
                column: "BirimID",
                principalTable: "Birimler",
                principalColumn: "BirimID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doktorlar_Hastaneler_HastaneID",
                table: "Doktorlar",
                column: "HastaneID",
                principalTable: "Hastaneler",
                principalColumn: "HastaneID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorID",
                table: "Randevular",
                column: "DoktorID",
                principalTable: "Doktorlar",
                principalColumn: "DoktorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_Birimler_BirimID",
                table: "Doktorlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_Hastaneler_HastaneID",
                table: "Doktorlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorID",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_DoktorID",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_BirimID",
                table: "Doktorlar");

            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_HastaneID",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "DoktorID",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "BirimID",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "HastaneID",
                table: "Doktorlar");
        }
    }
}
