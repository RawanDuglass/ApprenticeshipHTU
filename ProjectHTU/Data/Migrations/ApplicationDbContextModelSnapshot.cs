﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectHTU.Data;

#nullable disable

namespace ProjectHTU.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("ProjectHTU.Entities.Assignment", b =>
                {
                    b.Property<int>("assignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("assignmentId"), 1L, 1);

                    b.Property<string>("assignmentDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("assignmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("assignmentNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("documentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("trainingId")
                        .HasColumnType("int");

                    b.HasKey("assignmentId");

                    b.HasIndex("trainingId");

                    b.ToTable("assignments", (string)null);
                });

            modelBuilder.Entity("ProjectHTU.Entities.AssignmentObjectives", b =>
                {
                    b.Property<int>("assignmentId")
                        .HasColumnType("int");

                    b.Property<int>("objectiveId")
                        .HasColumnType("int");

                    b.HasKey("assignmentId", "objectiveId");

                    b.HasIndex("objectiveId");

                    b.ToTable("assignmentObjectives", (string)null);
                });

            modelBuilder.Entity("ProjectHTU.Entities.Company", b =>
                {
                    b.Property<int>("companyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("companyId"), 1L, 1);

                    b.Property<string>("companyAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("companyId");

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("ProjectHTU.Entities.Document", b =>
                {
                    b.Property<int>("documentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("documentId"), 1L, 1);

                    b.Property<int>("assignmentId")
                        .HasColumnType("int");

                    b.Property<string>("contentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("documentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("file")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("reportId")
                        .HasColumnType("int");

                    b.HasKey("documentId");

                    b.ToTable("documents", (string)null);
                });

            modelBuilder.Entity("ProjectHTU.Entities.Objective", b =>
                {
                    b.Property<int>("objectiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("objectiveId"), 1L, 1);

                    b.Property<string>("objectiveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("objectiveId");

                    b.ToTable("objectives", (string)null);
                });

            modelBuilder.Entity("ProjectHTU.Entities.ObjectiveSkills", b =>
                {
                    b.Property<int>("objectiveId")
                        .HasColumnType("int");

                    b.Property<int>("skillId")
                        .HasColumnType("int");

                    b.HasKey("objectiveId", "skillId");

                    b.HasIndex("skillId");

                    b.ToTable("objectiveSkills", (string)null);
                });

            modelBuilder.Entity("ProjectHTU.Entities.Person", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
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

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("secondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("thiredName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("ProjectHTU.Entities.Report", b =>
                {
                    b.Property<int>("reportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reportId"), 1L, 1);

                    b.Property<int>("assignmentId")
                        .HasColumnType("int");

                    b.Property<int?>("documentId")
                        .HasColumnType("int");

                    b.Property<string>("reportDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reportName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reportNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("reportStatusId")
                        .HasColumnType("int");

                    b.HasKey("reportId");

                    b.HasIndex("assignmentId");

                    b.HasIndex("reportStatusId");

                    b.ToTable("reports", (string)null);
                });

            modelBuilder.Entity("ProjectHTU.Entities.ReportLog", b =>
                {
                    b.Property<int>("reportLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reportLogId"), 1L, 1);

                    b.Property<int>("assignmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("logDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("reportDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("reportId")
                        .HasColumnType("int");

                    b.Property<string>("reportName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reportNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("reportStatusId")
                        .HasColumnType("int");

                    b.HasKey("reportLogId");

                    b.HasIndex("reportId");

                    b.ToTable("reportLogs", (string)null);
                });

            modelBuilder.Entity("ProjectHTU.Entities.ReportStatus", b =>
                {
                    b.Property<int>("reportStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reportStatusId"), 1L, 1);

                    b.Property<string>("reportStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("reportStatusId");

                    b.ToTable("reportStatuses", (string)null);
                });

            modelBuilder.Entity("ProjectHTU.Entities.School", b =>
                {
                    b.Property<int>("schoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("schoolId"), 1L, 1);

                    b.Property<string>("schoolAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("schoolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("schoolId");

                    b.ToTable("schools", (string)null);
                });

            modelBuilder.Entity("ProjectHTU.Entities.Skill", b =>
                {
                    b.Property<int>("skillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("skillId"), 1L, 1);

                    b.Property<int>("assignmentNameassignmentId")
                        .HasColumnType("int");

                    b.Property<string>("skillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("skillId");

                    b.HasIndex("assignmentNameassignmentId");

                    b.ToTable("skills", (string)null);
                });

            modelBuilder.Entity("ProjectHTU.Entities.Training", b =>
                {
                    b.Property<int>("trainigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("trainigId"), 1L, 1);

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("schoolSupervisorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("studentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("teamLeaderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("trainigId");

                    b.HasIndex("schoolSupervisorId");

                    b.HasIndex("studentId");

                    b.HasIndex("teamLeaderId");

                    b.ToTable("trainings", (string)null);
                });

            modelBuilder.Entity("ProjectHTU.Entities.TrainingObjective", b =>
                {
                    b.Property<int>("trainingId")
                        .HasColumnType("int");

                    b.Property<int>("objectiveId")
                        .HasColumnType("int");

                    b.HasKey("trainingId", "objectiveId");

                    b.HasIndex("objectiveId");

                    b.ToTable("trainingObjectives", (string)null);
                });

            modelBuilder.Entity("ProjectHTU.Entities.SchoolSupervisor", b =>
                {
                    b.HasBaseType("ProjectHTU.Entities.Person");

                    b.Property<int>("schoolId")
                        .HasColumnType("int");

                    b.HasIndex("schoolId");

                    b.HasDiscriminator().HasValue("SchoolSupervisor");
                });

            modelBuilder.Entity("ProjectHTU.Entities.Student", b =>
                {
                    b.HasBaseType("ProjectHTU.Entities.Person");

                    b.Property<string>("major")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("ProjectHTU.Entities.TeamLeader", b =>
                {
                    b.HasBaseType("ProjectHTU.Entities.Person");

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.HasIndex("companyId");

                    b.HasDiscriminator().HasValue("TeamLeader");
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
                    b.HasOne("ProjectHTU.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProjectHTU.Entities.Person", null)
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

                    b.HasOne("ProjectHTU.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProjectHTU.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectHTU.Entities.Assignment", b =>
                {
                    b.HasOne("ProjectHTU.Entities.Training", "trainings")
                        .WithMany("assignments")
                        .HasForeignKey("trainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("trainings");
                });

            modelBuilder.Entity("ProjectHTU.Entities.AssignmentObjectives", b =>
                {
                    b.HasOne("ProjectHTU.Entities.Assignment", "assignments")
                        .WithMany("assignmentObjectives")
                        .HasForeignKey("assignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectHTU.Entities.Objective", "objectives")
                        .WithMany("assignmentObjectives")
                        .HasForeignKey("objectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("assignments");

                    b.Navigation("objectives");
                });

            modelBuilder.Entity("ProjectHTU.Entities.ObjectiveSkills", b =>
                {
                    b.HasOne("ProjectHTU.Entities.Objective", "objectives")
                        .WithMany("objectiveSkills")
                        .HasForeignKey("objectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectHTU.Entities.Skill", "skills")
                        .WithMany("objectiveSkills")
                        .HasForeignKey("skillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("objectives");

                    b.Navigation("skills");
                });

            modelBuilder.Entity("ProjectHTU.Entities.Report", b =>
                {
                    b.HasOne("ProjectHTU.Entities.Assignment", "assignments")
                        .WithMany("reports")
                        .HasForeignKey("assignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectHTU.Entities.ReportStatus", "reportStatus")
                        .WithMany("reports")
                        .HasForeignKey("reportStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("assignments");

                    b.Navigation("reportStatus");
                });

            modelBuilder.Entity("ProjectHTU.Entities.ReportLog", b =>
                {
                    b.HasOne("ProjectHTU.Entities.Report", "report")
                        .WithMany()
                        .HasForeignKey("reportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("report");
                });

            modelBuilder.Entity("ProjectHTU.Entities.Skill", b =>
                {
                    b.HasOne("ProjectHTU.Entities.Assignment", "assignmentName")
                        .WithMany()
                        .HasForeignKey("assignmentNameassignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("assignmentName");
                });

            modelBuilder.Entity("ProjectHTU.Entities.Training", b =>
                {
                    b.HasOne("ProjectHTU.Entities.SchoolSupervisor", "schoolSupervisor")
                        .WithMany("trainings")
                        .HasForeignKey("schoolSupervisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectHTU.Entities.Student", "student")
                        .WithMany("trainings")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectHTU.Entities.TeamLeader", "teamLeader")
                        .WithMany("trainings")
                        .HasForeignKey("teamLeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("schoolSupervisor");

                    b.Navigation("student");

                    b.Navigation("teamLeader");
                });

            modelBuilder.Entity("ProjectHTU.Entities.TrainingObjective", b =>
                {
                    b.HasOne("ProjectHTU.Entities.Objective", "objectives")
                        .WithMany("trainingObjectives")
                        .HasForeignKey("objectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectHTU.Entities.Training", "trainings")
                        .WithMany("trainingObjectives")
                        .HasForeignKey("trainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("objectives");

                    b.Navigation("trainings");
                });

            modelBuilder.Entity("ProjectHTU.Entities.SchoolSupervisor", b =>
                {
                    b.HasOne("ProjectHTU.Entities.School", "school")
                        .WithMany("schoolSupervisors")
                        .HasForeignKey("schoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("school");
                });

            modelBuilder.Entity("ProjectHTU.Entities.TeamLeader", b =>
                {
                    b.HasOne("ProjectHTU.Entities.Company", "company")
                        .WithMany("teamLeaders")
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("company");
                });

            modelBuilder.Entity("ProjectHTU.Entities.Assignment", b =>
                {
                    b.Navigation("assignmentObjectives");

                    b.Navigation("reports");
                });

            modelBuilder.Entity("ProjectHTU.Entities.Company", b =>
                {
                    b.Navigation("teamLeaders");
                });

            modelBuilder.Entity("ProjectHTU.Entities.Objective", b =>
                {
                    b.Navigation("assignmentObjectives");

                    b.Navigation("objectiveSkills");

                    b.Navigation("trainingObjectives");
                });

            modelBuilder.Entity("ProjectHTU.Entities.ReportStatus", b =>
                {
                    b.Navigation("reports");
                });

            modelBuilder.Entity("ProjectHTU.Entities.School", b =>
                {
                    b.Navigation("schoolSupervisors");
                });

            modelBuilder.Entity("ProjectHTU.Entities.Skill", b =>
                {
                    b.Navigation("objectiveSkills");
                });

            modelBuilder.Entity("ProjectHTU.Entities.Training", b =>
                {
                    b.Navigation("assignments");

                    b.Navigation("trainingObjectives");
                });

            modelBuilder.Entity("ProjectHTU.Entities.SchoolSupervisor", b =>
                {
                    b.Navigation("trainings");
                });

            modelBuilder.Entity("ProjectHTU.Entities.Student", b =>
                {
                    b.Navigation("trainings");
                });

            modelBuilder.Entity("ProjectHTU.Entities.TeamLeader", b =>
                {
                    b.Navigation("trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
