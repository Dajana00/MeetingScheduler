﻿// <auto-generated />
using System;
using MeetingScheduler;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeetingScheduler.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20241031220739_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MeetingScheduler.Domain.Model.Leave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CheckedByAdminId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CheckedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ColorHex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Leaves", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("MeetingScheduler.Domain.Model.Meeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ColorHex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("HostId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HostId");

                    b.ToTable("Meetings", (string)null);
                });

            modelBuilder.Entity("MeetingScheduler.Domain.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MeetingId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("MeetingScheduler.Domain.Model.DayOff", b =>
                {
                    b.HasBaseType("MeetingScheduler.Domain.Model.Leave");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("DaysOff", (string)null);
                });

            modelBuilder.Entity("MeetingScheduler.Domain.Model.SickLeave", b =>
                {
                    b.HasBaseType("MeetingScheduler.Domain.Model.Leave");

                    b.Property<string>("MedicalCertificate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SickLeaves", (string)null);
                });

            modelBuilder.Entity("MeetingScheduler.Domain.Model.SpecialEvent", b =>
                {
                    b.HasBaseType("MeetingScheduler.Domain.Model.Leave");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SpecialEvents", (string)null);
                });

            modelBuilder.Entity("MeetingScheduler.Domain.Model.Vacation", b =>
                {
                    b.HasBaseType("MeetingScheduler.Domain.Model.Leave");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Vacations", (string)null);
                });

            modelBuilder.Entity("MeetingScheduler.Domain.Model.Leave", b =>
                {
                    b.HasOne("MeetingScheduler.Domain.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MeetingScheduler.Domain.Model.Meeting", b =>
                {
                    b.HasOne("MeetingScheduler.Domain.Model.User", "Host")
                        .WithMany()
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Host");
                });

            modelBuilder.Entity("MeetingScheduler.Domain.Model.User", b =>
                {
                    b.HasOne("MeetingScheduler.Domain.Model.Meeting", null)
                        .WithMany("Participants")
                        .HasForeignKey("MeetingId");
                });

            modelBuilder.Entity("MeetingScheduler.Domain.Model.DayOff", b =>
                {
                    b.HasOne("MeetingScheduler.Domain.Model.Leave", null)
                        .WithOne()
                        .HasForeignKey("MeetingScheduler.Domain.Model.DayOff", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MeetingScheduler.Domain.Model.SickLeave", b =>
                {
                    b.HasOne("MeetingScheduler.Domain.Model.Leave", null)
                        .WithOne()
                        .HasForeignKey("MeetingScheduler.Domain.Model.SickLeave", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MeetingScheduler.Domain.Model.SpecialEvent", b =>
                {
                    b.HasOne("MeetingScheduler.Domain.Model.Leave", null)
                        .WithOne()
                        .HasForeignKey("MeetingScheduler.Domain.Model.SpecialEvent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MeetingScheduler.Domain.Model.Vacation", b =>
                {
                    b.HasOne("MeetingScheduler.Domain.Model.Leave", null)
                        .WithOne()
                        .HasForeignKey("MeetingScheduler.Domain.Model.Vacation", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MeetingScheduler.Domain.Model.Meeting", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}