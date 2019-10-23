using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class PatronRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Patrons_PatronID",
                table: "Copies");

            migrationBuilder.DropIndex(
                name: "IX_Copies_PatronID",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "PatronID",
                table: "Copies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatronID",
                table: "Copies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Copies_PatronID",
                table: "Copies",
                column: "PatronID");

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Patrons_PatronID",
                table: "Copies",
                column: "PatronID",
                principalTable: "Patrons",
                principalColumn: "PatronID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
