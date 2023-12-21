using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneWeb.DataAccessLayer.Migrations
{
    public partial class mig123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoktorBirim",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "Hastanesi",
                table: "Doktorlar");

            migrationBuilder.AddColumn<int>(
                name: "BirimID",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoktorID",
                table: "Randevular",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HastaneID",
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

            migrationBuilder.CreateTable(
                name: "Birimler",
                columns: table => new
                {
                    BirimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birimler", x => x.BirimID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_BirimID",
                table: "Randevular",
                column: "BirimID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_DoktorID",
                table: "Randevular",
                column: "DoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_HastaneID",
                table: "Randevular",
                column: "HastaneID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_Birimler_BirimID",
                table: "Doktorlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_Hastaneler_HastaneID",
                table: "Doktorlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Birimler_BirimID",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorID",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hastaneler_HastaneID",
                table: "Randevular");

            migrationBuilder.DropTable(
                name: "Birimler");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_BirimID",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_DoktorID",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_HastaneID",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_BirimID",
                table: "Doktorlar");

            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_HastaneID",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "BirimID",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "DoktorID",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "HastaneID",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "BirimID",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "HastaneID",
                table: "Doktorlar");

            migrationBuilder.AddColumn<string>(
                name: "DoktorBirim",
                table: "Doktorlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Hastanesi",
                table: "Doktorlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
