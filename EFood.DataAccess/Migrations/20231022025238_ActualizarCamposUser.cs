using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFood.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarCamposUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logbooks_Users_userId",
                table: "Logbooks");

            migrationBuilder.DropTable(
                name: "UserDiscountTickets");

            migrationBuilder.DropTable(
                name: "UserOrders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "AspNetUsers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetUsers",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Logbooks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DiscountTickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "AspNetUsers",
                type: "varchar(80)",
                unicode: false,
                maxLength: 80,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "AspNetUsers",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "AspNetUsers",
                type: "varchar(80)",
                unicode: false,
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "securityAnswer",
                table: "AspNetUsers",
                type: "varchar(80)",
                unicode: false,
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "securityQuestion",
                table: "AspNetUsers",
                type: "varchar(80)",
                unicode: false,
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "AspNetUsers",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Logbooks_AspNetUsers_userId",
                table: "Logbooks",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountTickets_AspNetUsers_UserId",
                table: "DiscountTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Logbooks_AspNetUsers_userId",
                table: "Logbooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_DiscountTickets_UserId",
                table: "DiscountTickets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DiscountTickets");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "securityAnswer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "securityQuestion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "status",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "AspNetUsers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Logbooks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldUnicode: false,
                oldMaxLength: 80);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    securityAnswer = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    securityQuestion = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    status = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserDiscountTickets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticketId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiscountTickets", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserDiscountTickets_DiscountTickets_ticketId",
                        column: x => x.ticketId,
                        principalTable: "DiscountTickets",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UserDiscountTickets_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UserOrders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ordersId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrders", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserOrders_Orders_ordersId",
                        column: x => x.ordersId,
                        principalTable: "Orders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UserOrders_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
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

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_ordersId",
                table: "UserOrders",
                column: "ordersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_userId",
                table: "UserOrders",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logbooks_Users_userId",
                table: "Logbooks",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
