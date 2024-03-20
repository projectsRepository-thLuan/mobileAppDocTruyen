using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webdoctruyen.Migrations
{
    /// <inheritdoc />
    public partial class Createdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "danhgia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    noidung = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    idtaikhoan = table.Column<int>(name: "id_taikhoan", type: "int", nullable: false),
                    idtruyen = table.Column<int>(name: "id_truyen", type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "taikhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    tentaikhoan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    matkhau = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phanquyen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "truyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    tentruyen = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    noidung = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    anh = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    idtk = table.Column<int>(name: "id_tk", type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "voice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    link = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    nhanvat = table.Column<int>(type: "int", nullable: false),
                    idtruyen = table.Column<int>(name: "id_truyen", type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "danhgia");

            migrationBuilder.DropTable(
                name: "taikhoan");

            migrationBuilder.DropTable(
                name: "truyen");

            migrationBuilder.DropTable(
                name: "voice");
        }
    }
}
