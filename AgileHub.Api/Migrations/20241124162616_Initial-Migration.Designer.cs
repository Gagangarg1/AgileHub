﻿// <auto-generated />
using System;
using AgileHub.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgileHub.Api.Migrations
{
    [DbContext(typeof(AgileHubDbContext))]
    [Migration("20241124162616_Initial-Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgileHub.Api.Models.Domain.Avatar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Extention")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Avatars");
                });

            modelBuilder.Entity("AgileHub.Api.Models.Domain.PokerPlanning.EstimationSystem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.PrimitiveCollection<string>("Values")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EstimationSystems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("37005290-7729-4dd9-a3ec-22047d5ba636"),
                            Name = "Scrum",
                            Values = "[\"1/2\",\"1\",\"2\",\"3\",\"5\",\"8\",\"13\",\"20\",\"40\",\"100\",\"Coffee\"]"
                        },
                        new
                        {
                            Id = new Guid("69d1b033-099e-41e9-8e13-2ddeb98a4095"),
                            Name = "Fibonacci",
                            Values = "[\"1\",\"3\",\"5\",\"8\",\"13\",\"21\",\"34\",\"Coffee\"]"
                        },
                        new
                        {
                            Id = new Guid("1a947dcb-463d-43a3-868e-ca1f9b65461f"),
                            Name = "Sequential",
                            Values = "[\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"10\",\"11\",\"12\",\"13\",\"Coffee\"]"
                        },
                        new
                        {
                            Id = new Guid("a4721373-cc8f-43c0-81a6-60676d2c024c"),
                            Name = "T-Shirt",
                            Values = "[\"XS\",\"S\",\"M\",\"L\",\"XL\",\"XXL\",\"XXXL\",\"Coffeee\"]"
                        });
                });

            modelBuilder.Entity("AgileHub.Api.Models.Domain.PokerPlanning.PlanningRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AnyOneCanRevealCards")
                        .HasColumnType("bit");

                    b.Property<bool>("AutoRevealCards")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EnableAnimation")
                        .HasColumnType("bit");

                    b.Property<Guid>("EstimationSystemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("EveryoneIsAllowedToManageStories")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ShowTimer")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("EstimationSystemId");

                    b.ToTable("PlanningRooms");
                });

            modelBuilder.Entity("AgileHub.Api.Models.Domain.PokerPlanning.Story", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JiraId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PlanningRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlanningRoomId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("AgileHub.Api.Models.Domain.PokerPlanning.Vote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StoryPoint")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("AgileHub.Api.Models.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AvatarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PlanningRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AvatarId");

                    b.HasIndex("PlanningRoomId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AgileHub.Api.Models.Domain.PokerPlanning.PlanningRoom", b =>
                {
                    b.HasOne("AgileHub.Api.Models.Domain.PokerPlanning.EstimationSystem", "EstimationSystem")
                        .WithMany()
                        .HasForeignKey("EstimationSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstimationSystem");
                });

            modelBuilder.Entity("AgileHub.Api.Models.Domain.PokerPlanning.Story", b =>
                {
                    b.HasOne("AgileHub.Api.Models.Domain.PokerPlanning.PlanningRoom", null)
                        .WithMany("Stories")
                        .HasForeignKey("PlanningRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgileHub.Api.Models.Domain.PokerPlanning.Vote", b =>
                {
                    b.HasOne("AgileHub.Api.Models.Domain.PokerPlanning.Story", "Story")
                        .WithMany("Votes")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgileHub.Api.Models.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Story");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AgileHub.Api.Models.Domain.User", b =>
                {
                    b.HasOne("AgileHub.Api.Models.Domain.Avatar", "Avatar")
                        .WithMany()
                        .HasForeignKey("AvatarId");

                    b.HasOne("AgileHub.Api.Models.Domain.PokerPlanning.PlanningRoom", null)
                        .WithMany("PlanningRoomUsers")
                        .HasForeignKey("PlanningRoomId");

                    b.Navigation("Avatar");
                });

            modelBuilder.Entity("AgileHub.Api.Models.Domain.PokerPlanning.PlanningRoom", b =>
                {
                    b.Navigation("PlanningRoomUsers");

                    b.Navigation("Stories");
                });

            modelBuilder.Entity("AgileHub.Api.Models.Domain.PokerPlanning.Story", b =>
                {
                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
