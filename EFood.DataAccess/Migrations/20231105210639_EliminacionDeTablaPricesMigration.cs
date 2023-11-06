using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFood.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EliminacionDeTablaPricesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrices_Prices_priceId",
                table: "ProductPrices");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.RenameColumn(
                name: "priceId",
                table: "ProductPrices",
                newName: "priceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPrices_priceId",
                table: "ProductPrices",
                newName: "IX_ProductPrices_priceTypeId");

            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "ProductPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrices_PriceTypes_priceTypeId",
                table: "ProductPrices",
                column: "priceTypeId",
                principalTable: "PriceTypes",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrices_PriceTypes_priceTypeId",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "ProductPrices");

            migrationBuilder.RenameColumn(
                name: "priceTypeId",
                table: "ProductPrices",
                newName: "priceId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPrices_priceTypeId",
                table: "ProductPrices",
                newName: "IX_ProductPrices_priceId");

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    priceTypeId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.id);
                    table.ForeignKey(
                        name: "FK_Prices_PriceTypes_priceTypeId",
                        column: x => x.priceTypeId,
                        principalTable: "PriceTypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_priceTypeId",
                table: "Prices",
                column: "priceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrices_Prices_priceId",
                table: "ProductPrices",
                column: "priceId",
                principalTable: "Prices",
                principalColumn: "id");
        }
    }
}
