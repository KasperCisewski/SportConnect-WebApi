﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportConnect.Infrastructure.Data;

namespace SportConnect.Infrastructure.Migrations
{
    [DbContext(typeof(SportConnectContext))]
    [Migration("20190514063419_AddIsDeletedFlagOnBaseModel")]
    partial class AddIsDeletedFlagOnBaseModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportConnect.Core.Domain.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CityName");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<int>("HouseNumber");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.EventPlace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("EventPlace");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.EventType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EventType");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.Message", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("SportEventId");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<Guid>("Id");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("MessageContent");

                    b.HasKey("UserId", "SportEventId");

                    b.HasIndex("SportEventId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.Role", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.SportEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<DateTime>("EventEndDate");

                    b.Property<DateTime>("EventEndTime");

                    b.Property<string>("EventName");

                    b.Property<Guid?>("EventPlaceId");

                    b.Property<DateTime>("EventStartDate");

                    b.Property<DateTime>("EventStartTime");

                    b.Property<int?>("EventTypeId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("MaximumNumberOfParticipants");

                    b.Property<int>("MinimumNumberOfParticipants");

                    b.Property<Guid>("SportEventManagerId");

                    b.Property<int>("SportSkillLevelId");

                    b.Property<int>("SportTypeId");

                    b.HasKey("Id");

                    b.HasIndex("EventPlaceId");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("SportSkillLevelId");

                    b.HasIndex("SportTypeId");

                    b.ToTable("SportEvent");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.SportSkillLevel", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SportSkillLevel");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.SportType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("ProposedNumberOfParticipants");

                    b.Property<string>("SportName");

                    b.HasKey("Id");

                    b.ToTable("SportType");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<string>("Email");

                    b.Property<int>("FavouriteSportTypeId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("FavouriteSportTypeId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.UserLogRecords", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogRecords");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.UserSportEvent", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("SportEventId");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<Guid>("Id");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("UserId", "SportEventId");

                    b.HasIndex("SportEventId");

                    b.ToTable("UserSportEvent");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.EventPlace", b =>
                {
                    b.HasOne("SportConnect.Core.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.Message", b =>
                {
                    b.HasOne("SportConnect.Core.Domain.SportEvent", "SportEvent")
                        .WithMany("Messages")
                        .HasForeignKey("SportEventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SportConnect.Core.Domain.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SportConnect.Core.Domain.SportEvent", b =>
                {
                    b.HasOne("SportConnect.Core.Domain.EventPlace", "EventPlace")
                        .WithMany()
                        .HasForeignKey("EventPlaceId");

                    b.HasOne("SportConnect.Core.Domain.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId");

                    b.HasOne("SportConnect.Core.Domain.SportSkillLevel", "ProposedEventSkillLevel")
                        .WithMany()
                        .HasForeignKey("SportSkillLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportConnect.Core.Domain.SportType", "SportType")
                        .WithMany()
                        .HasForeignKey("SportTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportConnect.Core.Domain.User", b =>
                {
                    b.HasOne("SportConnect.Core.Domain.SportType", "FavouriteSportType")
                        .WithMany()
                        .HasForeignKey("FavouriteSportTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportConnect.Core.Domain.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportConnect.Core.Domain.UserLogRecords", b =>
                {
                    b.HasOne("SportConnect.Core.Domain.User")
                        .WithMany("UserLogRecords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportConnect.Core.Domain.UserSportEvent", b =>
                {
                    b.HasOne("SportConnect.Core.Domain.SportEvent", "SportEvent")
                        .WithMany("ConfirmedEventParticipants")
                        .HasForeignKey("SportEventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SportConnect.Core.Domain.User", "User")
                        .WithMany("ConfirmedSportEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
