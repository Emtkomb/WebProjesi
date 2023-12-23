using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneWeb.DataAccessLayer.Migrations
{
    public partial class migrandevu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Birim",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DoktorName",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sikayet",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birim",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "DoktorName",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "Sikayet",
                table: "Randevular");
        }
    }
}
