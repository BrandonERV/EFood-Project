using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFood.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarDiscountTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountTickets_AspNetUsers_UserId",
                table: "DiscountTickets");

            migrationBuilder.DropIndex(
                name: "IX_DiscountTickets_UserId",
                table: "DiscountTickets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DiscountTickets");

            migrationBuilder.DropColumn(
                name: "status",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserDiscountTickets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ticketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiscountTickets", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserDiscountTickets_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UserDiscountTickets_DiscountTickets_ticketId",
                        column: x => x.ticketId,
                        principalTable: "DiscountTickets",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountTickets_ticketId",
                table: "UserDiscountTickets",
                column: "ticketId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountTickets_userId",
                table: "UserDiscountTickets",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDiscountTickets");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DiscountTickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "AspNetUsers",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiscountTickets_UserId",
                table: "DiscountTickets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountTickets_AspNetUsers_UserId",
                table: "DiscountTickets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
