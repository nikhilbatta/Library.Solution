using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class Tuesday9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Books_BookID",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "CopyQuantity",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookID",
                table: "Copies",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PatronID",
                table: "Copies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Copies_PatronID",
                table: "Copies",
                column: "PatronID");

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Books_BookID",
                table: "Copies",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Patrons_PatronID",
                table: "Copies",
                column: "PatronID",
                principalTable: "Patrons",
                principalColumn: "PatronID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Books_BookID",
                table: "Copies");

            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Patrons_PatronID",
                table: "Copies");

            migrationBuilder.DropIndex(
                name: "IX_Copies_PatronID",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "PatronID",
                table: "Copies");

            migrationBuilder.AlterColumn<int>(
                name: "BookID",
                table: "Copies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CopyQuantity",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Books_BookID",
                table: "Copies",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
