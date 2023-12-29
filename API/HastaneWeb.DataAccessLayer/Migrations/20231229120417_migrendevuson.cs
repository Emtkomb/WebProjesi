using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneWeb.DataAccessLayer.Migrations
{
    public partial class migrendevuson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorID",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Randevular");

            migrationBuilder.AlterColumn<string>(
                name: "TelNo",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Sikayet",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RandevuTarihi",
                table: "Randevular",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DoktorID",
                table: "Randevular",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorID",
                table: "Randevular",
                column: "DoktorID",
                principalTable: "Doktorlar",
                principalColumn: "DoktorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorID",
                table: "Randevular");

            migrationBuilder.AlterColumn<string>(
                name: "TelNo",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sikayet",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RandevuTarihi",
                table: "Randevular",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoktorID",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorID",
                table: "Randevular",
                column: "DoktorID",
                principalTable: "Doktorlar",
                principalColumn: "DoktorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
