using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFood.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_imageId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Products_imageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "imageId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "imageId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    path = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_imageId",
                table: "Products",
                column: "imageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_imageId",
                table: "Products",
                column: "imageId",
                principalTable: "Images",
                principalColumn: "id");
        }
    }
}
