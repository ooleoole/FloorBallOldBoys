using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class OldBoysV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningAttendances_Tranings_TraningId",
                table: "UserTraningAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningEnrollments_Tranings_TraningId",
                table: "UserTraningEnrollments");

            migrationBuilder.AddColumn<int>(
                name: "TrainingId",
                table: "UserTraningEnrollments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingId",
                table: "UserTraningAttendances",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTraningEnrollments_TrainingId",
                table: "UserTraningEnrollments",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTraningAttendances_TrainingId",
                table: "UserTraningAttendances",
                column: "TrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTraningAttendances_Tranings_TrainingId",
                table: "UserTraningAttendances",
                column: "TrainingId",
                principalTable: "Tranings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTraningEnrollments_Tranings_TrainingId",
                table: "UserTraningEnrollments",
                column: "TrainingId",
                principalTable: "Tranings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningAttendances_Tranings_TrainingId",
                table: "UserTraningAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTraningEnrollments_Tranings_TrainingId",
                table: "UserTraningEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_UserTraningEnrollments_TrainingId",
                table: "UserTraningEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_UserTraningAttendances_TrainingId",
                table: "UserTraningAttendances");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "UserTraningEnrollments");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "UserTraningAttendances");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTraningAttendances_Tranings_TraningId",
                table: "UserTraningAttendances",
                column: "TraningId",
                principalTable: "Tranings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTraningEnrollments_Tranings_TraningId",
                table: "UserTraningEnrollments",
                column: "TraningId",
                principalTable: "Tranings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
