using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneWeb.DataAccessLayer.Migrations
{
    public partial class hastane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorNameDoktorID",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hastaneler_HastaneAdiHastaneID",
                table: "Randevular");

            migrationBuilder.RenameColumn(
                name: "HastaneAdiHastaneID",
                table: "Randevular",
                newName: "HastaneID");

            migrationBuilder.RenameColumn(
                name: "DoktorNameDoktorID",
                table: "Randevular",
                newName: "DoktorID");

            migrationBuilder.RenameIndex(
                name: "IX_Randevular_HastaneAdiHastaneID",
                table: "Randevular",
                newName: "IX_Randevular_HastaneID");

            migrationBuilder.RenameIndex(
                name: "IX_Randevular_DoktorNameDoktorID",
                table: "Randevular",
                newName: "IX_Randevular_DoktorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorID",
                table: "Randevular",
                column: "DoktorID",
                principalTable: "Doktorlar",
                principalColumn: "DoktorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hastaneler_HastaneID",
                table: "Randevular",
                column: "HastaneID",
                principalTable: "Hastaneler",
                principalColumn: "HastaneID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorID",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hastaneler_HastaneID",
                table: "Randevular");

            migrationBuilder.RenameColumn(
                name: "HastaneID",
                table: "Randevular",
                newName: "HastaneAdiHastaneID");

            migrationBuilder.RenameColumn(
                name: "DoktorID",
                table: "Randevular",
                newName: "DoktorNameDoktorID");

            migrationBuilder.RenameIndex(
                name: "IX_Randevular_HastaneID",
                table: "Randevular",
                newName: "IX_Randevular_HastaneAdiHastaneID");

            migrationBuilder.RenameIndex(
                name: "IX_Randevular_DoktorID",
                table: "Randevular",
                newName: "IX_Randevular_DoktorNameDoktorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorNameDoktorID",
                table: "Randevular",
                column: "DoktorNameDoktorID",
                principalTable: "Doktorlar",
                principalColumn: "DoktorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hastaneler_HastaneAdiHastaneID",
                table: "Randevular",
                column: "HastaneAdiHastaneID",
                principalTable: "Hastaneler",
                principalColumn: "HastaneID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
