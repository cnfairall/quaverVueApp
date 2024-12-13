﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuaverEd_App.Data;

#nullable disable

namespace QuaverEd_App.Server.Migrations
{
    [DbContext(typeof(QuaverEd_AppDbContext))]
    [Migration("20241212233959_Initial_Create")]
    partial class Initial_Create
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuaverEd_App.Server.Models.Repository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GithubId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastPushDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumStars")
                        .HasColumnType("int");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepoDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Repository");
                });
#pragma warning restore 612, 618
        }
    }
}
