using Microsoft.EntityFrameworkCore.Migrations;

namespace FloorBallOldBoysWEB.Migrations
{
    public partial class OldBosyWEB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Address_City_Street_ZipCode",
                table: "Address",
                columns: new[] { "City", "Street", "ZipCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Address_City_Street_ZipCode",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
