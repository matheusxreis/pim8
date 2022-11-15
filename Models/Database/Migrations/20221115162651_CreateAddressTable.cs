using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pim8.Models.Database.Migrations
{
    public partial class CreateAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    place = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<string>(type: "text", nullable: false),
                    cep = table.Column<string>(type: "text", nullable: false),
                    neighborhood = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    complement = table.Column<string>(type: "text", nullable: true),
                    user = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");
        }
    }
}
