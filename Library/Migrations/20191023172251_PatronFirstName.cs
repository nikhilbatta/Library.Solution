using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class PatronFirstName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Patrons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Patrons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Patrons");
        }
    }
}
