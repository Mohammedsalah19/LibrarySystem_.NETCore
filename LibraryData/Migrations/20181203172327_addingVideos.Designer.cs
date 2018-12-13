﻿// <auto-generated />
using System;
using LibraryData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryData.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20181203172327_addingVideos")]
    partial class addingVideos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryData.Models.BranchHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CloseTime");

                    b.Property<int>("DayOfWeek");

                    b.Property<int>("OpenTime");

                    b.HasKey("Id");

                    b.ToTable("BranchHours");
                });

            modelBuilder.Entity("LibraryData.Models.CheckOutHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CheckedIn");

                    b.Property<DateTime>("CheckedOut");

                    b.Property<int>("LibraryAssetId");

                    b.Property<int>("LibraryCardId");

                    b.HasKey("Id");

                    b.HasIndex("LibraryAssetId");

                    b.HasIndex("LibraryCardId");

                    b.ToTable("CheckOutHistoies");
                });

            modelBuilder.Entity("LibraryData.Models.Checkouts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LibaryCardId");

                    b.Property<int>("LibraryAssetsId");

                    b.Property<DateTime>("Since");

                    b.Property<DateTime>("Until");

                    b.HasKey("Id");

                    b.HasIndex("LibaryCardId");

                    b.HasIndex("LibraryAssetsId");

                    b.ToTable("Checkouts");
                });

            modelBuilder.Entity("LibraryData.Models.Holds", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HoldPlaced");

                    b.Property<int?>("LibaryCardId");

                    b.Property<int?>("LibraryAssetId");

                    b.HasKey("Id");

                    b.HasIndex("LibaryCardId");

                    b.HasIndex("LibraryAssetId");

                    b.ToTable("holds");
                });

            modelBuilder.Entity("LibraryData.Models.LibaryCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<decimal>("Fees");

                    b.HasKey("Id");

                    b.ToTable("LibaryCards");
                });

            modelBuilder.Entity("LibraryData.Models.LibraryAssets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("ImgUrl");

                    b.Property<int?>("LocationId");

                    b.Property<int>("NumOfCopies");

                    b.Property<int>("StatusId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("StatusId");

                    b.ToTable("LibraryAssets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("LibraryAssets");
                });

            modelBuilder.Entity("LibraryData.Models.LibraryBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("ImgUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("OpenDate");

                    b.Property<string>("telephone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("LibraryBranchs");
                });

            modelBuilder.Entity("LibraryData.Models.Patarn", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("FristName");

                    b.Property<string>("LastName");

                    b.Property<int?>("LibaryCardId");

                    b.Property<int?>("LibraryBranchId");

                    b.Property<string>("TelephoneNumber");

                    b.HasKey("id");

                    b.HasIndex("LibaryCardId");

                    b.HasIndex("LibraryBranchId");

                    b.ToTable("Patrons");
                });

            modelBuilder.Entity("LibraryData.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("LibraryData.Models.Book", b =>
                {
                    b.HasBaseType("LibraryData.Models.LibraryAssets");

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("DeweyIndex")
                        .IsRequired();

                    b.Property<string>("ISBN")
                        .IsRequired();

                    b.ToTable("Book");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("LibraryData.Models.Video", b =>
                {
                    b.HasBaseType("LibraryData.Models.LibraryAssets");

                    b.Property<string>("Director")
                        .IsRequired();

                    b.ToTable("Video");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("LibraryData.Models.CheckOutHistory", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryAssets", "LibraryAsset")
                        .WithMany()
                        .HasForeignKey("LibraryAssetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryData.Models.LibaryCard", "LibraryCard")
                        .WithMany()
                        .HasForeignKey("LibraryCardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryData.Models.Checkouts", b =>
                {
                    b.HasOne("LibraryData.Models.LibaryCard", "LibaryCard")
                        .WithMany("Checkouts")
                        .HasForeignKey("LibaryCardId");

                    b.HasOne("LibraryData.Models.LibraryAssets", "LibraryAssets")
                        .WithMany()
                        .HasForeignKey("LibraryAssetsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryData.Models.Holds", b =>
                {
                    b.HasOne("LibraryData.Models.LibaryCard", "LibaryCard")
                        .WithMany()
                        .HasForeignKey("LibaryCardId");

                    b.HasOne("LibraryData.Models.LibraryAssets", "LibraryAsset")
                        .WithMany()
                        .HasForeignKey("LibraryAssetId");
                });

            modelBuilder.Entity("LibraryData.Models.LibraryAssets", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryBranch", "Location")
                        .WithMany("LibraryAssets")
                        .HasForeignKey("LocationId");

                    b.HasOne("LibraryData.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryData.Models.Patarn", b =>
                {
                    b.HasOne("LibraryData.Models.LibaryCard", "LibaryCard")
                        .WithMany()
                        .HasForeignKey("LibaryCardId");

                    b.HasOne("LibraryData.Models.LibraryBranch", "LibraryBranch")
                        .WithMany("patrons")
                        .HasForeignKey("LibraryBranchId");
                });
#pragma warning restore 612, 618
        }
    }
}