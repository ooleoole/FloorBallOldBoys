using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class OldBoysDATAV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "ZipCode",
                "Address",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                "Street",
                "Address",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                "City",
                "Address",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddUniqueConstraint(
                "AK_Address_City_Street_ZipCode",
                "Address",
                new[] {"City", "Street", "ZipCode"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                "AK_Address_City_Street_ZipCode",
                "Address");

            migrationBuilder.AlterColumn<string>(
                "ZipCode",
                "Address",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                "Street",
                "Address",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                "City",
                "Address",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}