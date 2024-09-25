﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolWebSite.Infrastructure.Data;

#nullable disable

namespace SchoolWebSite.Infrastructure.Migrations
{
    [DbContext(typeof(ApplictionDBContext))]
    partial class ApplictionDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolProject.Data.Entities.Department", b =>
                {
                    b.Property<int>("DID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DID"));

                    b.Property<string>("DNameAr")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("DNameEn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("InsManger")
                        .HasColumnType("int");

                    b.HasKey("DID");

                    b.HasIndex("InsManger")
                        .IsUnique()
                        .HasFilter("[InsManger] IS NOT NULL");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.DepartmetSubject", b =>
                {
                    b.Property<int>("SubID")
                        .HasColumnType("int");

                    b.Property<int>("DID")
                        .HasColumnType("int");

                    b.HasKey("SubID", "DID");

                    b.HasIndex("DID");

                    b.ToTable("departmetSubjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Student", b =>
                {
                    b.Property<int>("StudID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("DID")
                        .HasColumnType("int");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("StudID");

                    b.HasIndex("DID");

                    b.ToTable("students");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.StudentSubject", b =>
                {
                    b.Property<int>("SubID")
                        .HasColumnType("int");

                    b.Property<int>("StudID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Grade")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SubID", "StudID");

                    b.HasIndex("StudID");

                    b.ToTable("studentSubjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Subjects", b =>
                {
                    b.Property<int>("SubID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubID"));

                    b.Property<DateTime>("Period")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectNameAr")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SubjectNameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubID");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("SchoolWebSite.Data.Entities.Instructor", b =>
                {
                    b.Property<int>("InsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InsId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DID")
                        .HasColumnType("int");

                    b.Property<string>("INameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("INameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("InsId");

                    b.HasIndex("DID");

                    b.HasIndex("SupervisorId");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("SchoolWebSite.Data.Entities.InstructorSubject", b =>
                {
                    b.Property<int>("SubId")
                        .HasColumnType("int");

                    b.Property<int>("InsId")
                        .HasColumnType("int");

                    b.HasKey("SubId", "InsId");

                    b.HasIndex("InsId");

                    b.ToTable("InstructorSubject");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Department", b =>
                {
                    b.HasOne("SchoolWebSite.Data.Entities.Instructor", "Instructor")
                        .WithOne("deptManger")
                        .HasForeignKey("SchoolProject.Data.Entities.Department", "InsManger")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.DepartmetSubject", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Department", "Department")
                        .WithMany("DepartmentSubjects")
                        .HasForeignKey("DID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Data.Entities.Subjects", "Subject")
                        .WithMany("DepartmetsSubjects")
                        .HasForeignKey("SubID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Student", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.StudentSubject", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Student", "Student")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("StudID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Data.Entities.Subjects", "Subject")
                        .WithMany("StudentsSubjects")
                        .HasForeignKey("SubID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolWebSite.Data.Entities.Instructor", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Department", "department")
                        .WithMany("Instructors")
                        .HasForeignKey("DID");

                    b.HasOne("SchoolWebSite.Data.Entities.Instructor", "Supervisor")
                        .WithMany("Instructors")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Supervisor");

                    b.Navigation("department");
                });

            modelBuilder.Entity("SchoolWebSite.Data.Entities.InstructorSubject", b =>
                {
                    b.HasOne("SchoolWebSite.Data.Entities.Instructor", "instructor")
                        .WithMany("InstructorSubjects")
                        .HasForeignKey("InsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Data.Entities.Subjects", "subject")
                        .WithMany("InstructorSubjects")
                        .HasForeignKey("SubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("instructor");

                    b.Navigation("subject");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Department", b =>
                {
                    b.Navigation("DepartmentSubjects");

                    b.Navigation("Instructors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Student", b =>
                {
                    b.Navigation("StudentSubjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Subjects", b =>
                {
                    b.Navigation("DepartmetsSubjects");

                    b.Navigation("InstructorSubjects");

                    b.Navigation("StudentsSubjects");
                });

            modelBuilder.Entity("SchoolWebSite.Data.Entities.Instructor", b =>
                {
                    b.Navigation("InstructorSubjects");

                    b.Navigation("Instructors");

                    b.Navigation("deptManger")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
