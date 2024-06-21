﻿// <auto-generated />
using System;
using ERP.TimeTableManagement.DataService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ERP.TimeTableManagement.DataService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240618050338_TimeT2")]
    partial class TimeT2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("ERP.TimeTableManagement.Core.Entities.DaySlot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Day")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("TimetableId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TimetableId");

                    b.ToTable("DaySlots");
                });

            modelBuilder.Entity("ERP.TimeTableManagement.Core.Entities.LectureHall", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LectureHalls");
                });

            modelBuilder.Entity("ERP.TimeTableManagement.Core.Entities.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("ERP.TimeTableManagement.Core.Entities.TimeSlot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DaySlotId")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LectureHallId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ModuleId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SlotType")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DaySlotId");

                    b.HasIndex("LectureHallId");

                    b.HasIndex("ModuleId");

                    b.ToTable("TimeSlots");
                });

            modelBuilder.Entity("ERP.TimeTableManagement.Core.Entities.Timetable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("Semester")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Timetables");
                });

            modelBuilder.Entity("ERP.TimeTableManagement.Core.Entities.DaySlot", b =>
                {
                    b.HasOne("ERP.TimeTableManagement.Core.Entities.Timetable", "Timetable")
                        .WithMany("DaySlots")
                        .HasForeignKey("TimetableId");

                    b.Navigation("Timetable");
                });

            modelBuilder.Entity("ERP.TimeTableManagement.Core.Entities.TimeSlot", b =>
                {
                    b.HasOne("ERP.TimeTableManagement.Core.Entities.DaySlot", "DaySlot")
                        .WithMany("TimeSlots")
                        .HasForeignKey("DaySlotId");

                    b.HasOne("ERP.TimeTableManagement.Core.Entities.LectureHall", "LectureHall")
                        .WithMany("TimeSlots")
                        .HasForeignKey("LectureHallId");

                    b.HasOne("ERP.TimeTableManagement.Core.Entities.Module", "Module")
                        .WithMany("TimeSlots")
                        .HasForeignKey("ModuleId");

                    b.Navigation("DaySlot");

                    b.Navigation("LectureHall");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("ERP.TimeTableManagement.Core.Entities.DaySlot", b =>
                {
                    b.Navigation("TimeSlots");
                });

            modelBuilder.Entity("ERP.TimeTableManagement.Core.Entities.LectureHall", b =>
                {
                    b.Navigation("TimeSlots");
                });

            modelBuilder.Entity("ERP.TimeTableManagement.Core.Entities.Module", b =>
                {
                    b.Navigation("TimeSlots");
                });

            modelBuilder.Entity("ERP.TimeTableManagement.Core.Entities.Timetable", b =>
                {
                    b.Navigation("DaySlots");
                });
#pragma warning restore 612, 618
        }
    }
}
