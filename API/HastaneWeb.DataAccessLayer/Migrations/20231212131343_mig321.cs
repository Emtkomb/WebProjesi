using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneWeb.DataAccessLayer.Migrations
{
    public partial class mig321 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Birimler_BirimID",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorID",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hastaneler_HastaneID",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_BirimID",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_HastaneID",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "BirimID",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "HastaneID",
                table: "Randevular");

            migrationBuilder.AlterColumn<int>(
                name: "DoktorID",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_Randevular_Doktorlar_DoktorID",
                table: "Randevular");

            migrationBuilder.AlterColumn<int>(
                name: "DoktorID",
                table: "Randevular",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BirimID",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HastaneID",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_BirimID",
                table: "Randevular",
                column: "BirimID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_HastaneID",
                table: "Randevular",
                column: "HastaneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Birimler_BirimID",
                table: "Randevular",
                column: "BirimID",
                principalTable: "Birimler",
                principalColumn: "BirimID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorID",
                table: "Randevular",
                column: "DoktorID",
                principalTable: "Doktorlar",
                principalColumn: "DoktorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hastaneler_HastaneID",
                table: "Randevular",
                column: "HastaneID",
                principalTable: "Hastaneler",
                principalColumn: "HastaneID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
