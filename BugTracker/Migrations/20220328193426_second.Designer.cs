﻿// <auto-generated />
using System;
using BugTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BugTracker.Migrations
{
    [DbContext(typeof(BugTrackerContext))]
    [Migration("20220328193426_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("BugTracker")
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AssignedUsersCompanies", b =>
                {
                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("CompanyId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AssignedUsersCompanies", "BugTracker");
                });

            modelBuilder.Entity("AssignedUsersProjects", b =>
                {
                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AssignedUsersProjects", "BugTracker");
                });

            modelBuilder.Entity("AssignedUsersTickets", b =>
                {
                    b.Property<long>("TicketId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("TicketId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AssignedUsersTickets", "BugTracker");
                });

            modelBuilder.Entity("BugTracker.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Companies", "BugTracker");
                });

            modelBuilder.Entity("BugTracker.Models.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Projects", "BugTracker");
                });

            modelBuilder.Entity("BugTracker.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Roles", "BugTracker");
                });

            modelBuilder.Entity("BugTracker.Models.Ticket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("PriorityString")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("priority");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<string>("StatusString")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("TypeString")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tickets", "BugTracker");
                });

            modelBuilder.Entity("BugTracker.Models.TicketComment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("TicketId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("TicketComments", "BugTracker");
                });

            modelBuilder.Entity("BugTracker.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text")
                        .HasColumnName("photo_url");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", "BugTracker");
                });

            modelBuilder.Entity("OwnedUsersCompanies", b =>
                {
                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("CompanyId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("OwnedUsersCompanies", "BugTracker");
                });

            modelBuilder.Entity("OwnedUsersProjects", b =>
                {
                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("OwnedUsersProjects", "BugTracker");
                });

            modelBuilder.Entity("OwnedUsersTickets", b =>
                {
                    b.Property<long>("TicketId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("TicketId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("OwnedUsersTickets", "BugTracker");
                });

            modelBuilder.Entity("AssignedUsersCompanies", b =>
                {
                    b.HasOne("BugTracker.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AssignedUsersProjects", b =>
                {
                    b.HasOne("BugTracker.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AssignedUsersTickets", b =>
                {
                    b.HasOne("BugTracker.Models.Ticket", null)
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BugTracker.Models.Project", b =>
                {
                    b.HasOne("BugTracker.Models.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("BugTracker.Models.Ticket", b =>
                {
                    b.HasOne("BugTracker.Models.Project", "Project")
                        .WithMany("Tickets")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("BugTracker.Models.TicketComment", b =>
                {
                    b.HasOne("BugTracker.Models.Ticket", "Ticket")
                        .WithMany("TicketComments")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Models.User", "User")
                        .WithMany("TicketComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BugTracker.Models.User", b =>
                {
                    b.HasOne("BugTracker.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OwnedUsersCompanies", b =>
                {
                    b.HasOne("BugTracker.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OwnedUsersProjects", b =>
                {
                    b.HasOne("BugTracker.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OwnedUsersTickets", b =>
                {
                    b.HasOne("BugTracker.Models.Ticket", null)
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BugTracker.Models.Company", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("BugTracker.Models.Project", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("BugTracker.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BugTracker.Models.Ticket", b =>
                {
                    b.Navigation("TicketComments");
                });

            modelBuilder.Entity("BugTracker.Models.User", b =>
                {
                    b.Navigation("TicketComments");
                });
#pragma warning restore 612, 618
        }
    }
}
