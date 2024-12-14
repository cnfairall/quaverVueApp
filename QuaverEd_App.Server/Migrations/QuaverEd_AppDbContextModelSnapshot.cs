﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuaverEd_App.Data;

#nullable disable

namespace QuaverEd_App.Server.Migrations
{
    [DbContext(typeof(QuaverEd_AppDbContext))]
    partial class QuaverEd_AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("QuaverEd_App.Server.Models.Repository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GithubId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastPushDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NumStars")
                        .HasColumnType("int");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RepoDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RepoName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RepoUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Repository");
                });
#pragma warning restore 612, 618
        }
    }
}
