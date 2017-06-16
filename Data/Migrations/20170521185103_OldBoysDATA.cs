using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class OldBoysDATA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Address",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Address", x => x.Id); });

            migrationBuilder.CreateTable(
                "User",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Firstname = table.Column<string>(maxLength: 45, nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    Lastname = table.Column<string>(maxLength: 45, nullable: true),
                    Phonenumber = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    SocialSecurityNumber = table.Column<string>(maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.UniqueConstraint("AK_User_Email", x => x.Email);
                    table.ForeignKey(
                        "FK_User_Address_AddressId",
                        x => x.AddressId,
                        "Address",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Training",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Info = table.Column<string>(nullable: true),
                    IsCancelled = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        "FK_Training_User_CreatorId",
                        x => x.CreatorId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserTraningAttendance",
                table => new
                {
                    TrainingId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTraningAttendance", x => new {x.TrainingId, x.UserId});
                    table.ForeignKey(
                        "FK_UserTraningAttendance_Training_TrainingId",
                        x => x.TrainingId,
                        "Training",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserTraningAttendance_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserTraningEnrollment",
                table => new
                {
                    TrainingId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTraningEnrollment", x => new {x.TrainingId, x.UserId});
                    table.ForeignKey(
                        "FK_UserTraningEnrollment_Training_TrainingId",
                        x => x.TrainingId,
                        "Training",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserTraningEnrollment_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Training_CreatorId",
                "Training",
                "CreatorId");

            migrationBuilder.CreateIndex(
                "IX_User_AddressId",
                "User",
                "AddressId");

            migrationBuilder.CreateIndex(
                "IX_UserTraningAttendance_UserId",
                "UserTraningAttendance",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_UserTraningEnrollment_UserId",
                "UserTraningEnrollment",
                "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "UserTraningAttendance");

            migrationBuilder.DropTable(
                "UserTraningEnrollment");

            migrationBuilder.DropTable(
                "Training");

            migrationBuilder.DropTable(
                "User");

            migrationBuilder.DropTable(
                "Address");
        }
    }
}