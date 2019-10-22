using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class NewOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Books_CopiesID",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CopiesID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "CopyQuantity",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Copies",
                columns: table => new
                {
                    CopiesID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookID = table.Column<int>(nullable: false),
                    isCheckedOut = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copies", x => x.CopiesID);
                    table.ForeignKey(
                        name: "FK_Copies_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Copies_BookID",
                table: "Copies",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Copies_CopiesID",
                table: "Checkouts",
                column: "CopiesID",
                principalTable: "Copies",
                principalColumn: "CopiesID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Copies_CopiesID",
                table: "Checkouts");

            migrationBuilder.DropTable(
                name: "Copies");

            migrationBuilder.DropColumn(
                name: "CopyQuantity",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Books",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CopiesID",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Books",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Books_CopiesID",
                table: "Checkouts",
                column: "CopiesID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
