using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneWeb.DataAccessLayer.Migrations
{
    public partial class migrandevudoktor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoktorName",
                table: "Randevular");

            migrationBuilder.AddColumn<int>(
                name: "DoktorID",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_DoktorID",
                table: "Randevular",
                column: "DoktorID");

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

            migrationBuilder.DropIndex(
                name: "IX_Randevular_DoktorID",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "DoktorID",
                table: "Randevular");

            migrationBuilder.AddColumn<string>(
                name: "DoktorName",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
