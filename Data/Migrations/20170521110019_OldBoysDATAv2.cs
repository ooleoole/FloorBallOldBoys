using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class OldBoysDATAv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningAttendance_Training_TrainingId",
                table: "UserTraningAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningAttendance_User_UserId",
                table: "UserTraningAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningEnrollment_Training_TrainingId",
                table: "UserTraningEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningEnrollment_User_UserId",
                table: "UserTraningEnrollment");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Training",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Training",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTraningAttendance_Training_TrainingId",
                table: "UserTraningAttendance",
                column: "TrainingId",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTraningAttendance_User_UserId",
                table: "UserTraningAttendance",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTraningEnrollment_Training_TrainingId",
                table: "UserTraningEnrollment",
                column: "TrainingId",
                principalTable: "Training",
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
                name: "FK_UserTraningAttendance_Training_TrainingId",
                table: "UserTraningAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningAttendance_User_UserId",
                table: "UserTraningAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningEnrollment_Training_TrainingId",
                table: "UserTraningEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningEnrollment_User_UserId",
                table: "UserTraningEnrollment");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Training");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTraningAttendance_Training_TrainingId",
                table: "UserTraningAttendance",
                column: "TrainingId",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTraningAttendance_User_UserId",
                table: "UserTraningAttendance",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTraningEnrollment_Training_TrainingId",
                table: "UserTraningEnrollment",
                column: "TrainingId",
                principalTable: "Training",
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
