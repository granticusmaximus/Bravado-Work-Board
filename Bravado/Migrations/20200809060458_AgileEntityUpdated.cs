using Microsoft.EntityFrameworkCore.Migrations;

namespace Bravado.Migrations
{
    public partial class AgileEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Columns_ColumnID",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Columns_Boards_BoardID",
                table: "Columns");

            migrationBuilder.DropIndex(
                name: "IX_Columns_BoardID",
                table: "Columns");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ColumnID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "BoardID",
                table: "Columns");

            migrationBuilder.DropColumn(
                name: "ColumnID",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "BIDBoardID",
                table: "Columns",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CIDColumnID",
                table: "Cards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Boards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Columns_BIDBoardID",
                table: "Columns",
                column: "BIDBoardID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CIDColumnID",
                table: "Cards",
                column: "CIDColumnID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Columns_CIDColumnID",
                table: "Cards",
                column: "CIDColumnID",
                principalTable: "Columns",
                principalColumn: "ColumnID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Columns_Boards_BIDBoardID",
                table: "Columns",
                column: "BIDBoardID",
                principalTable: "Boards",
                principalColumn: "BoardID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Columns_CIDColumnID",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Columns_Boards_BIDBoardID",
                table: "Columns");

            migrationBuilder.DropIndex(
                name: "IX_Columns_BIDBoardID",
                table: "Columns");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CIDColumnID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "BIDBoardID",
                table: "Columns");

            migrationBuilder.DropColumn(
                name: "CIDColumnID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Boards");

            migrationBuilder.AddColumn<int>(
                name: "BoardID",
                table: "Columns",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColumnID",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Columns_BoardID",
                table: "Columns",
                column: "BoardID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ColumnID",
                table: "Cards",
                column: "ColumnID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Columns_ColumnID",
                table: "Cards",
                column: "ColumnID",
                principalTable: "Columns",
                principalColumn: "ColumnID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Columns_Boards_BoardID",
                table: "Columns",
                column: "BoardID",
                principalTable: "Boards",
                principalColumn: "BoardID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
