using Microsoft.EntityFrameworkCore.Migrations;

namespace Bravado.Migrations
{
    public partial class CardUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RowNum",
                table: "Cards",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowNum",
                table: "Cards");
        }
    }
}
