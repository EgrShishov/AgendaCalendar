﻿// <auto-generated />
using System;
using System.Collections.Generic;
using AgendaCalendar.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgendaCalendar.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240522174732_AddWorkingHoursAndMeetingsModels")]
    partial class AddWorkingHoursAndMeetingsModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("CalendarColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CalendarDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<int>>("SubscribersId")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.DailyWorkingHours", b =>
                {
                    b.Property<int>("WorkingHoursId")
                        .HasColumnType("integer");

                    b.Property<int>("Day")
                        .HasColumnType("integer");

                    b.Property<TimeSpan?>("EndTime")
                        .HasColumnType("interval");

                    b.Property<TimeSpan?>("StartTime")
                        .HasColumnType("interval");

                    b.HasKey("WorkingHoursId", "Day");

                    b.ToTable("DailyWorkingHours");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("CalendarId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.Invitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MeetingId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.HasIndex("UserId");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.Meeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.Reminder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CalendarId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("NotificationInterval")
                        .HasColumnType("interval");

                    b.Property<DateTime>("ReminderTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("BirthdayDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("MeetingId")
                        .HasColumnType("integer");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.WorkingHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Day")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WorkingHours");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.DailyWorkingHours", b =>
                {
                    b.HasOne("AgendaCalendar.Domain.Entities.WorkingHours", "WorkingHours")
                        .WithMany("DailyHours")
                        .HasForeignKey("WorkingHoursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkingHours");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.Event", b =>
                {
                    b.HasOne("AgendaCalendar.Domain.Entities.Calendar", null)
                        .WithMany("Events")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("AgendaCalendar.Domain.Entities.RecurrenceRule", "ReccurenceRules", b1 =>
                        {
                            b1.Property<int>("EventId")
                                .HasColumnType("integer");

                            b1.Property<List<string>>("byweekday")
                                .IsRequired()
                                .HasColumnType("text[]");

                            b1.Property<string>("dtstart")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("freq")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<int>("interval")
                                .HasColumnType("integer");

                            b1.Property<string>("until")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("EventId");

                            b1.ToTable("Events");

                            b1.WithOwner()
                                .HasForeignKey("EventId");
                        });

                    b.OwnsOne("System.Collections.Generic.List<AgendaCalendar.Domain.Entities.EventParticipant>", "EventParticipants", b1 =>
                        {
                            b1.Property<int>("EventId")
                                .HasColumnType("integer");

                            b1.Property<int>("Capacity")
                                .HasColumnType("integer");

                            b1.HasKey("EventId");

                            b1.ToTable("Events");

                            b1.WithOwner()
                                .HasForeignKey("EventId");
                        });

                    b.Navigation("EventParticipants")
                        .IsRequired();

                    b.Navigation("ReccurenceRules")
                        .IsRequired();
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.Invitation", b =>
                {
                    b.HasOne("AgendaCalendar.Domain.Entities.Meeting", "Meeting")
                        .WithMany("Invitations")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgendaCalendar.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meeting");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.Meeting", b =>
                {
                    b.HasOne("AgendaCalendar.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.Reminder", b =>
                {
                    b.HasOne("AgendaCalendar.Domain.Entities.Calendar", null)
                        .WithMany("Reminders")
                        .HasForeignKey("CalendarId");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.User", b =>
                {
                    b.HasOne("AgendaCalendar.Domain.Entities.Meeting", null)
                        .WithMany("Participants")
                        .HasForeignKey("MeetingId");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.WorkingHours", b =>
                {
                    b.HasOne("AgendaCalendar.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.Calendar", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Reminders");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.Meeting", b =>
                {
                    b.Navigation("Invitations");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("AgendaCalendar.Domain.Entities.WorkingHours", b =>
                {
                    b.Navigation("DailyHours");
                });
#pragma warning restore 612, 618
        }
    }
}
