﻿// <auto-generated />
using System;
using MagicMansion_MansionAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicMansionMansionAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230124175135_TestAddMansionsToDb")]
    partial class TestAddMansionsToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicMansion_MansionAPI.Models.Mansion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Mansions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "",
                            CreatedDate = new DateTime(2023, 1, 24, 23, 51, 35, 850, DateTimeKind.Local).AddTicks(3136),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://sun9-14.userapi.com/impg/0wx3laWZz-W3ClxGfdu8NfzKB4_IG9wtkhjyLg/WOb7pesENtQ.jpg?size=800x509&quality=95&sign=bcfc866301bd2269c19f794c24d19707&type=album",
                            Name = "Royal Mansion",
                            Occupancy = 4,
                            Rate = 200.0,
                            Sqft = 550,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "",
                            CreatedDate = new DateTime(2023, 1, 24, 23, 51, 35, 850, DateTimeKind.Local).AddTicks(3147),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://sun9-30.userapi.com/impg/-xKq2aYv0vQMhz43SVPaRJvg-txJovhjIB0Kkw/4qHK5FADbpo.jpg?size=800x509&quality=95&sign=6e0ade8c4be3b87f67e281baae33bec8&type=album",
                            Name = "Premium Pool Mansion",
                            Occupancy = 4,
                            Rate = 300.0,
                            Sqft = 550,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "",
                            CreatedDate = new DateTime(2023, 1, 24, 23, 51, 35, 850, DateTimeKind.Local).AddTicks(3149),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://sun9-86.userapi.com/impg/K21KcfdcWKql89Nlv9B6Y5Cgeo7sMIlshAXHfw/D4lcWaxEd0w.jpg?size=800x509&quality=95&sign=4d9ebe62cef615f5592510d3cacb784c&type=album",
                            Name = "Luxury Pool Mansion",
                            Occupancy = 4,
                            Rate = 400.0,
                            Sqft = 750,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Amenity = "",
                            CreatedDate = new DateTime(2023, 1, 24, 23, 51, 35, 850, DateTimeKind.Local).AddTicks(3151),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://sun9-85.userapi.com/impg/YGMw5mpK17Y1bZIyI-aqVHZ3KLCFFu-Hz7tYxg/CVRKxwkblk0.jpg?size=800x509&quality=95&sign=cc4494bacaf276443a6f504da371b80a&type=album",
                            Name = "Diamond Mansion",
                            Occupancy = 4,
                            Rate = 550.0,
                            Sqft = 900,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Amenity = "",
                            CreatedDate = new DateTime(2023, 1, 24, 23, 51, 35, 850, DateTimeKind.Local).AddTicks(3152),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://sun9-46.userapi.com/impg/UZGqGTyJoTs-7eB0Yt-Bq5CK3HZRN7GneiOl0g/VghlnFMXU9A.jpg?size=800x509&quality=95&sign=4dd7b21a7c9f62d68d1daf7d5ffcb756&type=album",
                            Name = "Diamond Pool Mansion",
                            Occupancy = 4,
                            Rate = 600.0,
                            Sqft = 1100,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MagicMansion_MansionAPI.Models.MansionNumber", b =>
                {
                    b.Property<int>("MansionNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MansionID")
                        .HasColumnType("int");

                    b.Property<string>("SpecialDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MansionNo");

                    b.HasIndex("MansionID");

                    b.ToTable("MansionNumbers");
                });

            modelBuilder.Entity("MagicMansion_MansionAPI.Models.MansionNumber", b =>
                {
                    b.HasOne("MagicMansion_MansionAPI.Models.Mansion", "Mansion")
                        .WithMany()
                        .HasForeignKey("MansionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mansion");
                });
#pragma warning restore 612, 618
        }
    }
}
