using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFood.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarForeignKeysyTablaOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentProcessors_paymentProcessorId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Statuses_statusId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_paymentProcessorId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_statusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "paymentProcessorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "statusId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "paymentProcessorId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "statusId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_paymentProcessorId",
                table: "Orders",
                column: "paymentProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_statusId",
                table: "Orders",
                column: "statusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentProcessors_paymentProcessorId",
                table: "Orders",
                column: "paymentProcessorId",
                principalTable: "PaymentProcessors",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Statuses_statusId",
                table: "Orders",
                column: "statusId",
                principalTable: "Statuses",
                principalColumn: "id");
        }
    }
}
