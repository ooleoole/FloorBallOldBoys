using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Data.Context;

namespace Data.Migrations
{
    [DbContext(typeof(EllosOldBoysContext))]
    [Migration("20170517172259_OldBoys")]
    partial class OldBoys
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

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Domain.Entities.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatorId");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Info");

                    b.Property<bool>("IsCancelled");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Tranings");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<string>("Lastname")
                        .HasMaxLength(45);

                    b.Property<string>("Phonenumber");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Domain.Entities.UserTraningAttendance", b =>
                {
                    b.Property<int>("TraningId");

                    b.Property<int>("UserId");

                    b.HasKey("TraningId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTraningAttendances");
                });

            modelBuilder.Entity("Domain.Entities.UserTraningEnrollment", b =>
                {
                    b.Property<int>("TraningId");

                    b.Property<int>("UserId");

                    b.HasKey("TraningId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTraningEnrollments");
                });

            modelBuilder.Entity("Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("Domain.Entities.User");


                    b.ToTable("Admin");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Domain.Entities.Training", b =>
                {
                    b.HasOne("Domain.Entities.Admin", "Creator")
                        .WithMany("CreatedTranings")
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
                        .HasForeignKey("TraningId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("AttendedTranings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.UserTraningEnrollment", b =>
                {
                    b.HasOne("Domain.Entities.Training", "Training")
                        .WithMany("EnrolledUsers")
                        .HasForeignKey("TraningId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("EnrolledTranings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
