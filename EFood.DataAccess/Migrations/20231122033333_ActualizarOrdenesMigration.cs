using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFood.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarOrdenesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientLastName",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientLastName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
