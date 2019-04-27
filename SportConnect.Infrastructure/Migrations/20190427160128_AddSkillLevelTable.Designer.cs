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
    [Migration("20190427160128_AddSkillLevelTable")]
    partial class AddSkillLevelTable
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

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("EventPlace");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDateTime");

                    b.HasKey("Id");

                    b.ToTable("EventType");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.Role", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.SportEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<Guid?>("EventPlaceId");

                    b.Property<int?>("EventTypeId");

                    b.Property<int>("MaximumNumberOfParticipants");

                    b.Property<Guid>("SportEventManager");

                    b.Property<int>("SportSkillLevelId");

                    b.HasKey("Id");

                    b.HasIndex("EventPlaceId");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("SportSkillLevelId");

                    b.ToTable("SportEvents");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.SportSkillLevel", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("CreationDateTime");

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

                    b.HasKey("Id");

                    b.ToTable("SportType");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<string>("Email");

                    b.Property<int?>("FavouriteSportTypeId");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<int?>("RoleId");

                    b.Property<int>("UserRoleId");

                    b.HasKey("Id");

                    b.HasIndex("FavouriteSportTypeId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.UserSportEvent", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("SportEventId");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<Guid>("Id");

                    b.HasKey("UserId", "SportEventId");

                    b.HasIndex("SportEventId");

                    b.ToTable("UserSportEvents");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.EventPlace", b =>
                {
                    b.HasOne("SportConnect.Core.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
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
                });

            modelBuilder.Entity("SportConnect.Core.Domain.User", b =>
                {
                    b.HasOne("SportConnect.Core.Domain.SportType", "FavouriteSportType")
                        .WithMany()
                        .HasForeignKey("FavouriteSportTypeId");

                    b.HasOne("SportConnect.Core.Domain.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("SportConnect.Core.Domain.UserSportEvent", b =>
                {
                    b.HasOne("SportConnect.Core.Domain.SportEvent", "SportEvent")
                        .WithMany("ConfirmedEventParticipant")
                        .HasForeignKey("SportEventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportConnect.Core.Domain.User", "User")
                        .WithMany("ConfirmedSportEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
