﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using University.Data.Data;

#nullable disable

namespace University.Data.Migrations
{
    [DbContext(typeof(UniversityContext))]
    [Migration("20220211133014_CourseTemporal")]
    partial class CourseTemporal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("University.Entities.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("University.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Course", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb
                                .HasPeriodStart("PeriodStart")
                                .HasColumnName("PeriodStart");
                            ttb
                                .HasPeriodEnd("PeriodEnd")
                                .HasColumnName("PeriodEnd");
                        }
                    ));
                });

            modelBuilder.Entity("University.Entities.Enrollment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("University.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("University.Entities.Adress", b =>
                {
                    b.HasOne("University.Entities.Student", "Student")
                        .WithOne("Adress")
                        .HasForeignKey("University.Entities.Adress", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("University.Entities.Enrollment", b =>
                {
                    b.HasOne("University.Entities.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Entities.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("University.Entities.Student", b =>
                {
                    b.OwnsOne("University.Entities.Name", "Name", b1 =>
                        {
                            b1.Property<int>("StudentId")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LastName");

                            b1.HasKey("StudentId");

                            b1.ToTable("Student");

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("University.Entities.Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("University.Entities.Student", b =>
                {
                    b.Navigation("Adress")
                        .IsRequired();

                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
