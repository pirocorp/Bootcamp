﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recrutment.Api.Data;

#nullable disable

namespace Recrutment.Api.Migrations
{
    [DbContext(typeof(RecrutmentDbContext))]
    [Migration("20211218165305_Interviews")]
    partial class Interviews
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Recrutment.Api.Data.Models.Candidate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecruiterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RecruiterId");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("Recrutment.Api.Data.Models.CandidateSkill", b =>
                {
                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<string>("CandidateId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SkillId", "CandidateId");

                    b.HasIndex("CandidateId");

                    b.ToTable("CandidatesSkills");
                });

            modelBuilder.Entity("Recrutment.Api.Data.Models.Interview", b =>
                {
                    b.Property<string>("RecruiterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("JobId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CandidateId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RecruiterId", "JobId", "CandidateId");

                    b.HasIndex("CandidateId");

                    b.HasIndex("JobId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("Recrutment.Api.Data.Models.Job", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasPrecision(38, 18)
                        .HasColumnType("decimal(38,18)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Recrutment.Api.Data.Models.JobSkill", b =>
                {
                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<string>("JobId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SkillId", "JobId");

                    b.HasIndex("JobId");

                    b.ToTable("JobsSkills");
                });

            modelBuilder.Entity("Recrutment.Api.Data.Models.Recruiter", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Recruiters");
                });

            modelBuilder.Entity("Recrutment.Api.Data.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Recrutment.Api.Data.Models.Candidate", b =>
                {
                    b.HasOne("Recrutment.Api.Data.Models.Recruiter", "Recruiter")
                        .WithMany("Candidates")
                        .HasForeignKey("RecruiterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recruiter");
                });

            modelBuilder.Entity("Recrutment.Api.Data.Models.CandidateSkill", b =>
                {
                    b.HasOne("Recrutment.Api.Data.Models.Candidate", "Candidate")
                        .WithMany("Skills")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Recrutment.Api.Data.Models.Skill", "Skill")
                        .WithMany("Candidates")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Recrutment.Api.Data.Models.Interview", b =>
                {
                    b.HasOne("Recrutment.Api.Data.Models.Candidate", "Candidate")
                        .WithMany("Interviews")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recrutment.Api.Data.Models.Job", "Job")
                        .WithMany("Interviews")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recrutment.Api.Data.Models.Recruiter", "Recruiter")
                        .WithMany("Interviews")
                        .HasForeignKey("RecruiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Job");

                    b.Navigation("Recruiter");
                });

            modelBuilder.Entity("Recrutment.Api.Data.Models.JobSkill", b =>
                {
                    b.HasOne("Recrutment.Api.Data.Models.Job", "Job")
                        .WithMany("Skills")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Recrutment.Api.Data.Models.Skill", "Skill")
                        .WithMany("Jobs")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Recrutment.Api.Data.Models.Candidate", b =>
                {
                    b.Navigation("Interviews");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Recrutment.Api.Data.Models.Job", b =>
                {
                    b.Navigation("Interviews");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Recrutment.Api.Data.Models.Recruiter", b =>
                {
                    b.Navigation("Candidates");

                    b.Navigation("Interviews");
                });

            modelBuilder.Entity("Recrutment.Api.Data.Models.Skill", b =>
                {
                    b.Navigation("Candidates");

                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}