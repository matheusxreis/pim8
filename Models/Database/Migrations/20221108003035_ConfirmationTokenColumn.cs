using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pim8.Models.Database.Migrations
{
    public partial class ConfirmationTokenColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "confirmation_token",
                table: "users",
                nullable: true
            );
            migrationBuilder.AddColumn<Boolean>(
                name: "active",
                table: "users",
                defaultValue: false
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "confirmation_token",
                table: "users"
            );
             migrationBuilder.DropColumn(
                name: "active",
                table: "users"
            );
        }
    }
}
