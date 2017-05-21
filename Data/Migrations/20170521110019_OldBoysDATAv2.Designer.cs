using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Data.Context;

namespace Data.Migrations
{
    [DbContext(typeof(EllosOldBoysContext))]
    [Migration("20170521110019_OldBoysDATAv2")]
    partial class OldBoysDATAv2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<string>("ZipCode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Domain.Entities.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatorId");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Info");

                    b.Property<bool>("IsCancelled");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Lastname")
                        .HasMaxLength(45);

                    b.Property<string>("Phonenumber");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired()
                        .HasMaxLength(13);

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.HasIndex("AddressId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entities.UserTraningAttendance", b =>
                {
                    b.Property<int>("TrainingId");

                    b.Property<int>("UserId");

                    b.HasKey("TrainingId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTraningAttendance");
                });

            modelBuilder.Entity("Domain.Entities.UserTraningEnrollment", b =>
                {
                    b.Property<int>("TrainingId");

                    b.Property<int>("UserId");

                    b.HasKey("TrainingId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTraningEnrollment");
                });

            modelBuilder.Entity("Domain.Entities.Training", b =>
                {
                    b.HasOne("Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.UserTraningAttendance", b =>
                {
                    b.HasOne("Domain.Entities.Training", "Training")
                        .WithMany("ActualAttendance")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("AttendedTranings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Entities.UserTraningEnrollment", b =>
                {
                    b.HasOne("Domain.Entities.Training", "Training")
                        .WithMany("EnrolledUsers")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("EnrolledTranings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
        }
    }
}
