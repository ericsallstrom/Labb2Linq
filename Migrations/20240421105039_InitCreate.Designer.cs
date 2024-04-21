﻿// <auto-generated />
using System;
using Labb2Linq.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb2Linq.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240421105039_InitCreate")]
    partial class InitCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb2Linq.Models.ClassList", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClassId");

                    b.ToTable("ClassLists");

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            ClassName = "NET23"
                        },
                        new
                        {
                            ClassId = 2,
                            ClassName = "JAVA23"
                        },
                        new
                        {
                            ClassId = 3,
                            ClassName = "ITSÄK23"
                        },
                        new
                        {
                            ClassId = 4,
                            ClassName = "NE23"
                        });
                });

            modelBuilder.Entity("Labb2Linq.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CourseName = "Programmering 1"
                        },
                        new
                        {
                            CourseId = 2,
                            CourseName = "Programmering 2"
                        },
                        new
                        {
                            CourseId = 3,
                            CourseName = "Infrastruktur 1"
                        },
                        new
                        {
                            CourseId = 4,
                            CourseName = "Infrastruktur 2"
                        });
                });

            modelBuilder.Entity("Labb2Linq.Models.CourseTeacher", b =>
                {
                    b.Property<int>("CourseTeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseTeacherId"));

                    b.Property<int>("FkCourseId")
                        .HasColumnType("int");

                    b.Property<int>("FkTeacherId")
                        .HasColumnType("int");

                    b.HasKey("CourseTeacherId");

                    b.HasIndex("FkCourseId");

                    b.HasIndex("FkTeacherId");

                    b.ToTable("CourseTeachers");

                    b.HasData(
                        new
                        {
                            CourseTeacherId = 1,
                            FkCourseId = 1,
                            FkTeacherId = 1
                        },
                        new
                        {
                            CourseTeacherId = 2,
                            FkCourseId = 1,
                            FkTeacherId = 2
                        },
                        new
                        {
                            CourseTeacherId = 3,
                            FkCourseId = 2,
                            FkTeacherId = 1
                        },
                        new
                        {
                            CourseTeacherId = 4,
                            FkCourseId = 2,
                            FkTeacherId = 2
                        },
                        new
                        {
                            CourseTeacherId = 5,
                            FkCourseId = 3,
                            FkTeacherId = 3
                        },
                        new
                        {
                            CourseTeacherId = 6,
                            FkCourseId = 3,
                            FkTeacherId = 4
                        },
                        new
                        {
                            CourseTeacherId = 7,
                            FkCourseId = 4,
                            FkTeacherId = 3
                        },
                        new
                        {
                            CourseTeacherId = 8,
                            FkCourseId = 4,
                            FkTeacherId = 4
                        });
                });

            modelBuilder.Entity("Labb2Linq.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentId"));

                    b.Property<int>("FkCourseId")
                        .HasColumnType("int");

                    b.Property<int>("FkStudentId")
                        .HasColumnType("int");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("FkCourseId");

                    b.HasIndex("FkStudentId");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            EnrollmentId = 1,
                            FkCourseId = 1,
                            FkStudentId = 1
                        },
                        new
                        {
                            EnrollmentId = 2,
                            FkCourseId = 1,
                            FkStudentId = 2
                        },
                        new
                        {
                            EnrollmentId = 3,
                            FkCourseId = 1,
                            FkStudentId = 3
                        },
                        new
                        {
                            EnrollmentId = 4,
                            FkCourseId = 1,
                            FkStudentId = 4
                        },
                        new
                        {
                            EnrollmentId = 5,
                            FkCourseId = 3,
                            FkStudentId = 5
                        },
                        new
                        {
                            EnrollmentId = 6,
                            FkCourseId = 3,
                            FkStudentId = 6
                        },
                        new
                        {
                            EnrollmentId = 7,
                            FkCourseId = 3,
                            FkStudentId = 7
                        },
                        new
                        {
                            EnrollmentId = 8,
                            FkCourseId = 3,
                            FkStudentId = 8
                        },
                        new
                        {
                            EnrollmentId = 9,
                            FkCourseId = 2,
                            FkStudentId = 1
                        },
                        new
                        {
                            EnrollmentId = 10,
                            FkCourseId = 2,
                            FkStudentId = 2
                        },
                        new
                        {
                            EnrollmentId = 11,
                            FkCourseId = 2,
                            FkStudentId = 3
                        },
                        new
                        {
                            EnrollmentId = 12,
                            FkCourseId = 2,
                            FkStudentId = 4
                        },
                        new
                        {
                            EnrollmentId = 13,
                            FkCourseId = 4,
                            FkStudentId = 5
                        },
                        new
                        {
                            EnrollmentId = 14,
                            FkCourseId = 4,
                            FkStudentId = 6
                        },
                        new
                        {
                            EnrollmentId = 15,
                            FkCourseId = 4,
                            FkStudentId = 7
                        },
                        new
                        {
                            EnrollmentId = 16,
                            FkCourseId = 4,
                            FkStudentId = 8
                        });
                });

            modelBuilder.Entity("Labb2Linq.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("FkClassId")
                        .HasColumnType("int");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("StudentId");

                    b.HasIndex("FkClassId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            FkClassId = 1,
                            StudentName = "Lisa Bengtsson"
                        },
                        new
                        {
                            StudentId = 2,
                            FkClassId = 1,
                            StudentName = "David Pettersson"
                        },
                        new
                        {
                            StudentId = 3,
                            FkClassId = 2,
                            StudentName = "Emma Gustafsson"
                        },
                        new
                        {
                            StudentId = 4,
                            FkClassId = 2,
                            StudentName = "Andreas Lindberg"
                        },
                        new
                        {
                            StudentId = 5,
                            FkClassId = 3,
                            StudentName = "Sofia Johansson"
                        },
                        new
                        {
                            StudentId = 6,
                            FkClassId = 3,
                            StudentName = "Oscar Persson"
                        },
                        new
                        {
                            StudentId = 7,
                            FkClassId = 4,
                            StudentName = "Emma Karlsson"
                        },
                        new
                        {
                            StudentId = 8,
                            FkClassId = 4,
                            StudentName = "Alexander Andersson"
                        });
                });

            modelBuilder.Entity("Labb2Linq.Models.StudentCourse", b =>
                {
                    b.Property<int>("StudentCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentCourseId"));

                    b.Property<int>("FkCourseId")
                        .HasColumnType("int");

                    b.Property<int>("FkStudentId")
                        .HasColumnType("int");

                    b.HasKey("StudentCourseId");

                    b.HasIndex("FkCourseId");

                    b.HasIndex("FkStudentId");

                    b.ToTable("StudentCourses");

                    b.HasData(
                        new
                        {
                            StudentCourseId = 1,
                            FkCourseId = 1,
                            FkStudentId = 1
                        },
                        new
                        {
                            StudentCourseId = 2,
                            FkCourseId = 1,
                            FkStudentId = 2
                        },
                        new
                        {
                            StudentCourseId = 3,
                            FkCourseId = 1,
                            FkStudentId = 3
                        },
                        new
                        {
                            StudentCourseId = 4,
                            FkCourseId = 1,
                            FkStudentId = 4
                        },
                        new
                        {
                            StudentCourseId = 5,
                            FkCourseId = 3,
                            FkStudentId = 5
                        },
                        new
                        {
                            StudentCourseId = 6,
                            FkCourseId = 3,
                            FkStudentId = 6
                        },
                        new
                        {
                            StudentCourseId = 7,
                            FkCourseId = 3,
                            FkStudentId = 7
                        },
                        new
                        {
                            StudentCourseId = 8,
                            FkCourseId = 3,
                            FkStudentId = 8
                        },
                        new
                        {
                            StudentCourseId = 9,
                            FkCourseId = 2,
                            FkStudentId = 1
                        },
                        new
                        {
                            StudentCourseId = 10,
                            FkCourseId = 2,
                            FkStudentId = 2
                        },
                        new
                        {
                            StudentCourseId = 11,
                            FkCourseId = 2,
                            FkStudentId = 3
                        },
                        new
                        {
                            StudentCourseId = 12,
                            FkCourseId = 2,
                            FkStudentId = 4
                        },
                        new
                        {
                            StudentCourseId = 13,
                            FkCourseId = 4,
                            FkStudentId = 5
                        },
                        new
                        {
                            StudentCourseId = 14,
                            FkCourseId = 4,
                            FkStudentId = 6
                        },
                        new
                        {
                            StudentCourseId = 15,
                            FkCourseId = 4,
                            FkStudentId = 7
                        },
                        new
                        {
                            StudentCourseId = 16,
                            FkCourseId = 4,
                            FkStudentId = 8
                        });
                });

            modelBuilder.Entity("Labb2Linq.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherId = 1,
                            TeacherName = "Reidar Nilsen"
                        },
                        new
                        {
                            TeacherId = 2,
                            TeacherName = "Aldor Besher"
                        },
                        new
                        {
                            TeacherId = 3,
                            TeacherName = "Erika Eriksson"
                        },
                        new
                        {
                            TeacherId = 4,
                            TeacherName = "Maria Karlsson"
                        },
                        new
                        {
                            TeacherId = 5,
                            TeacherName = "Tobias Landén"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Labb2Linq.Models.CourseTeacher", b =>
                {
                    b.HasOne("Labb2Linq.Models.Course", "Course")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("FkCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2Linq.Models.Teacher", "Teacher")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("FkTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Labb2Linq.Models.Enrollment", b =>
                {
                    b.HasOne("Labb2Linq.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("FkCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2Linq.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("FkStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Labb2Linq.Models.Student", b =>
                {
                    b.HasOne("Labb2Linq.Models.ClassList", "ClassList")
                        .WithMany("Students")
                        .HasForeignKey("FkClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassList");
                });

            modelBuilder.Entity("Labb2Linq.Models.StudentCourse", b =>
                {
                    b.HasOne("Labb2Linq.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("FkCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2Linq.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("FkStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labb2Linq.Models.ClassList", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Labb2Linq.Models.Course", b =>
                {
                    b.Navigation("CourseTeachers");

                    b.Navigation("Enrollments");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("Labb2Linq.Models.Student", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("Labb2Linq.Models.Teacher", b =>
                {
                    b.Navigation("CourseTeachers");
                });
#pragma warning restore 612, 618
        }
    }
}