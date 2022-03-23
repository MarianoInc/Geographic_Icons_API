﻿// <auto-generated />
using System;
using Geographic_Icons_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChallengeAlternativo.API.Migrations
{
    [DbContext(typeof(GeographicIconsContext))]
    partial class GeographicIconsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Geographic_Icons_API.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContinentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Population")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("CityId");

                    b.HasIndex("ContinentId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Geographic_Icons_API.Continent", b =>
                {
                    b.Property<int>("ContinentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContinentDenomination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContinentPicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContinentId");

                    b.ToTable("Continents");
                });

            modelBuilder.Entity("Geographic_Icons_API.GeographicIcon", b =>
                {
                    b.Property<int>("GeographicIconId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GeographicIconDenomination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeographicIconPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("History")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GeographicIconId");

                    b.HasIndex("CityId");

                    b.ToTable("GeographicIcons");
                });

            modelBuilder.Entity("Geographic_Icons_API.City", b =>
                {
                    b.HasOne("Geographic_Icons_API.Continent", "Continent")
                        .WithMany("Cities")
                        .HasForeignKey("ContinentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Geographic_Icons_API.GeographicIcon", b =>
                {
                    b.HasOne("Geographic_Icons_API.City", "City")
                        .WithMany("GeographicIcon")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
