﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using evoFlix.Models;

namespace evoFlix.Migrations
{
    [DbContext(typeof(UnitOfWork))]
    [Migration("20220131164440_database")]
    partial class database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("evoFlix.Models.FilmModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Actors")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DirectorName")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("ImdbRating")
                        .HasColumnType("float");

                    b.Property<string>("Plot")
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Poster")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Rated")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseYear")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("RunTime")
                        .HasColumnType("time");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("FilmTable");
                });

            modelBuilder.Entity("evoFlix.Models.SourceModel", b =>
                {
                    b.Property<Guid>("FimSourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FileModified")
                        .HasColumnType("date");

                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FilmLocation")
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("FimSourceId");

                    b.HasIndex("FilmId");

                    b.ToTable("SourceTable");
                });

            modelBuilder.Entity("evoFlix.Models.SubtitleModel", b =>
                {
                    b.Property<Guid>("SubtitleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SubtitleLanguage")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubtitleLocation")
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("SubtitleId");

                    b.HasIndex("FilmId");

                    b.ToTable("SubtitleTable");
                });

            modelBuilder.Entity("evoFlix.Models.UserModel", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ProfilPitcure")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("ValidAccount")
                        .HasColumnType("BIT");

                    b.HasKey("UserId");

                    b.ToTable("UserTable");
                });

            modelBuilder.Entity("evoFlix.Models.WatchModel", b =>
                {
                    b.Property<Guid>("WatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("WatchedTime")
                        .HasColumnType("time");

                    b.HasKey("WatchId");

                    b.HasIndex("FilmId");

                    b.HasIndex("UserId");

                    b.ToTable("WatchTable");
                });

            modelBuilder.Entity("evoFlix.Models.SourceModel", b =>
                {
                    b.HasOne("evoFlix.Models.FilmModel", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");
                });

            modelBuilder.Entity("evoFlix.Models.SubtitleModel", b =>
                {
                    b.HasOne("evoFlix.Models.FilmModel", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");
                });

            modelBuilder.Entity("evoFlix.Models.WatchModel", b =>
                {
                    b.HasOne("evoFlix.Models.FilmModel", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("evoFlix.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
