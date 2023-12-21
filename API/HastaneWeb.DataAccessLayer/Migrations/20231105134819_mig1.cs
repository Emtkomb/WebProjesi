using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneWeb.DataAccessLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    DoktorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorBirim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorMail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.DoktorID);
                });

            migrationBuilder.CreateTable(
                name: "Hastaneler",
                columns: table => new
                {
                    HastaneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaneAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastaneAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastaneTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastaneler", x => x.HastaneID);
                });

            migrationBuilder.CreateTable(
                name: "Hizmetler",
                columns: table => new
                {
                    HizmetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HizmetIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HizmetTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HizmetAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hizmetler", x => x.HizmetID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doktorlar");

            migrationBuilder.DropTable(
                name: "Hastaneler");

            migrationBuilder.DropTable(
                name: "Hizmetler");
        }
    }
}
