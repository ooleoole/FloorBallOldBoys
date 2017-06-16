using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class OldBoysV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_UserTraningAttendance_User_UserId",
                "UserTraningAttendance");

            migrationBuilder.DropForeignKey(
                "FK_UserTraningEnrollment_User_UserId",
                "UserTraningEnrollment");

            migrationBuilder.AddForeignKey(
                "FK_UserTraningAttendance_User_UserId",
                "UserTraningAttendance",
                "UserId",
                "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_UserTraningEnrollment_User_UserId",
                "UserTraningEnrollment",
                "UserId",
                "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_UserTraningAttendance_User_UserId",
                "UserTraningAttendance");

            migrationBuilder.DropForeignKey(
                "FK_UserTraningEnrollment_User_UserId",
                "UserTraningEnrollment");

            migrationBuilder.AddForeignKey(
                "FK_UserTraningAttendance_User_UserId",
                "UserTraningAttendance",
                "UserId",
                "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_UserTraningEnrollment_User_UserId",
                "UserTraningEnrollment",
                "UserId",
                "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}