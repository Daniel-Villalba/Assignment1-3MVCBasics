﻿// <auto-generated />
using System;
using MVCBasics.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCBasics.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220531184015_Seeded some data")]
    partial class Seededsomedata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCBasics.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Gothenburg"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Stockholm"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            Name = "Malmoe"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 2,
                            Name = "Oslo"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 2,
                            Name = "Bergen"
                        });
                });

            modelBuilder.Entity("MVCBasics.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CitiesId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sweden"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Norway"
                        });
                });

            modelBuilder.Entity("MVCBasics.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonCityId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("PersonCityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            Name = "Adam Andersson",
                            PersonCityId = 1,
                            PhoneNumber = "+4631445511"
                        },
                        new
                        {
                            PersonId = 2,
                            Name = "Bengt Bengtsson",
                            PersonCityId = 1,
                            PhoneNumber = "+4631548422"
                        },
                        new
                        {
                            PersonId = 3,
                            Name = "Cesar Cederquist",
                            PersonCityId = 4,
                            PhoneNumber = "+4731443433"
                        },
                        new
                        {
                            PersonId = 4,
                            Name = "David Dalquist",
                            PersonCityId = 5,
                            PhoneNumber = "+47314434242"
                        });
                });

            modelBuilder.Entity("MVCBasics.Models.City", b =>
                {
                    b.HasOne("MVCBasics.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("MVCBasics.Models.Person", b =>
                {
                    b.HasOne("MVCBasics.Models.City", "PersonCity")
                        .WithMany("People")
                        .HasForeignKey("PersonCityId");
                });
#pragma warning restore 612, 618
        }
    }
}
