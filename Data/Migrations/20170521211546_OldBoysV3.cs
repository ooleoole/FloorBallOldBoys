using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class OldBoysV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningAttendance_User_UserId",
                table: "UserTraningAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningEnrollment_User_UserId",
                table: "UserTraningEnrollment");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTraningAttendance_User_UserId",
                table: "UserTraningAttendance",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTraningEnrollment_User_UserId",
                table: "UserTraningEnrollment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningAttendance_User_UserId",
                table: "UserTraningAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningEnrollment_User_UserId",
                table: "UserTraningEnrollment");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTraningAttendance_User_UserId",
                table: "UserTraningAttendance",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTraningEnrollment_User_UserId",
                table: "UserTraningEnrollment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
