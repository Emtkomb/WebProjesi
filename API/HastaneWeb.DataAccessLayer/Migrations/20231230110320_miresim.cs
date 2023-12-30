using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneWeb.DataAccessLayer.Migrations
{
    public partial class miresim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resim",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resim",
                table: "AspNetUsers");
        }
    }
}
