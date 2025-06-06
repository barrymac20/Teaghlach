﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teaghlach.Data;

#nullable disable

namespace Teaghlach.Migrations
{
    [DbContext(typeof(TeaghlachContext))]
    [Migration("20250521132506_AddFamilyRoleAndSeedDate")]
    partial class AddFamilyRoleAndSeedDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Teaghlach.Data.Chore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssignedToId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToId");

                    b.ToTable("Chores");
                });

            modelBuilder.Entity("Teaghlach.Models.EventCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("EventCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "School"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Birthday"
                        });
                });

            modelBuilder.Entity("Teaghlach.Models.EventSubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EventCategoryId");

                    b.ToTable("EventSubCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventCategoryId = 1,
                            Name = "Parent-Teacher Meeting"
                        },
                        new
                        {
                            Id = 2,
                            EventCategoryId = 1,
                            Name = "School Play"
                        },
                        new
                        {
                            Id = 3,
                            EventCategoryId = 2,
                            Name = "Football"
                        },
                        new
                        {
                            Id = 4,
                            EventCategoryId = 2,
                            Name = "Camogie"
                        },
                        new
                        {
                            Id = 5,
                            EventCategoryId = 3,
                            Name = "Child's Birthday"
                        },
                        new
                        {
                            Id = 6,
                            EventCategoryId = 3,
                            Name = "Party"
                        });
                });

            modelBuilder.Entity("Teaghlach.Models.FamilyEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AllDay")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Color")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EventCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("EventSubCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("FamilyMemberId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EventCategoryId");

                    b.HasIndex("EventSubCategoryId");

                    b.HasIndex("FamilyMemberId");

                    b.ToTable("FamilyEvents");
                });

            modelBuilder.Entity("Teaghlach.Models.FamilyMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("FamilyRoleId")
                        .HasColumnType("int");

                    b.Property<int?>("FamilySubRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Role")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("FamilyRoleId");

                    b.HasIndex("FamilySubRoleId");

                    b.ToTable("FamilyMembers");
                });

            modelBuilder.Entity("Teaghlach.Models.FamilyRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("FamilyRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Parent"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Child"
                        });
                });

            modelBuilder.Entity("Teaghlach.Models.FamilySubRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FamilyRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FamilyRoleId");

                    b.ToTable("FamilySubRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FamilyRoleId = 1,
                            Name = "Father"
                        },
                        new
                        {
                            Id = 2,
                            FamilyRoleId = 1,
                            Name = "Mother"
                        },
                        new
                        {
                            Id = 3,
                            FamilyRoleId = 2,
                            Name = "Son"
                        },
                        new
                        {
                            Id = 4,
                            FamilyRoleId = 2,
                            Name = "Daughter"
                        });
                });

            modelBuilder.Entity("Teaghlach.Data.Chore", b =>
                {
                    b.HasOne("Teaghlach.Models.FamilyMember", "AssignedTo")
                        .WithMany("Chores")
                        .HasForeignKey("AssignedToId");

                    b.Navigation("AssignedTo");
                });

            modelBuilder.Entity("Teaghlach.Models.EventSubCategory", b =>
                {
                    b.HasOne("Teaghlach.Models.EventCategory", "EventCategory")
                        .WithMany("EventSubCategories")
                        .HasForeignKey("EventCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventCategory");
                });

            modelBuilder.Entity("Teaghlach.Models.FamilyEvent", b =>
                {
                    b.HasOne("Teaghlach.Models.EventCategory", "EventCategory")
                        .WithMany()
                        .HasForeignKey("EventCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Teaghlach.Models.EventSubCategory", "EventSubCategory")
                        .WithMany()
                        .HasForeignKey("EventSubCategoryId");

                    b.HasOne("Teaghlach.Models.FamilyMember", "FamilyMember")
                        .WithMany()
                        .HasForeignKey("FamilyMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventCategory");

                    b.Navigation("EventSubCategory");

                    b.Navigation("FamilyMember");
                });

            modelBuilder.Entity("Teaghlach.Models.FamilyMember", b =>
                {
                    b.HasOne("Teaghlach.Models.FamilyRole", "FamilyRole")
                        .WithMany()
                        .HasForeignKey("FamilyRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Teaghlach.Models.FamilySubRole", "FamilySubRole")
                        .WithMany()
                        .HasForeignKey("FamilySubRoleId");

                    b.Navigation("FamilyRole");

                    b.Navigation("FamilySubRole");
                });

            modelBuilder.Entity("Teaghlach.Models.FamilySubRole", b =>
                {
                    b.HasOne("Teaghlach.Models.FamilyRole", "FamilyRole")
                        .WithMany("FamilySubRoles")
                        .HasForeignKey("FamilyRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FamilyRole");
                });

            modelBuilder.Entity("Teaghlach.Models.EventCategory", b =>
                {
                    b.Navigation("EventSubCategories");
                });

            modelBuilder.Entity("Teaghlach.Models.FamilyMember", b =>
                {
                    b.Navigation("Chores");
                });

            modelBuilder.Entity("Teaghlach.Models.FamilyRole", b =>
                {
                    b.Navigation("FamilySubRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
