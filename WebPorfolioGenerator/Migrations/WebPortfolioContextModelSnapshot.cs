﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using WebPorfolioGenerator.DAL;

namespace WebPorfolioGenerator.Migrations
{
    [DbContext(typeof(DAL.WebPortfolioContext))]
    partial class WebPortfolioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebPorfolioGenerator.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<int>("PostId");

                    b.Property<DateTime>("Published");

                    b.HasKey("CommentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WebPorfolioGenerator.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cargo")
                        .HasMaxLength(200);

                    b.Property<int>("PortfolioId");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebPorfolioGenerator.Models.Font", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FontFamily");

                    b.Property<string>("FontName");

                    b.Property<string>("Link");

                    b.Property<string>("Style");

                    b.HasKey("Id");

                    b.ToTable("Fonts");
                });

            modelBuilder.Entity("WebPorfolioGenerator.Models.Galery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PortfolioId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Galerys");
                });

            modelBuilder.Entity("WebPorfolioGenerator.Models.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PortfolioId");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("WebPorfolioGenerator.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MenuId");

                    b.Property<string>("MenuName");

                    b.Property<int>("MenuOrder");

                    b.Property<string>("Url");

                    b.HasKey("MenuItemId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("WebPorfolioGenerator.Models.Portfolio", b =>
                {
                    b.Property<int>("PortfolioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstColor")
                        .HasMaxLength(8);

                    b.Property<int>("FontId");

                    b.Property<string>("PortfolioName")
                        .HasMaxLength(200);

                    b.Property<string>("PortfolioSurname")
                        .HasMaxLength(200);

                    b.Property<string>("SecondColor")
                        .HasMaxLength(8);

                    b.Property<string>("UrlBackgroundImage")
                        .HasMaxLength(500);

                    b.HasKey("PortfolioId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("WebPorfolioGenerator.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .HasMaxLength(2000);

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<int>("PortfolioId");

                    b.Property<string>("Subtitle")
                        .HasMaxLength(200);

                    b.Property<string>("Title")
                        .HasMaxLength(200);

                    b.HasKey("PostId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("WebPorfolioGenerator.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Name")
                        .HasMaxLength(200);

                    b.Property<int>("PostId");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("WebPorfolioGenerator.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birth");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(120);

                    b.Property<string>("MovilePhone")
                        .HasMaxLength(120);

                    b.Property<string>("Name")
                        .HasMaxLength(120);

                    b.Property<string>("Password")
                        .HasMaxLength(120);

                    b.Property<string>("Phone")
                        .HasMaxLength(120);

                    b.Property<int>("RolId");

                    b.Property<string>("Surname")
                        .HasMaxLength(120);

                    b.Property<string>("UserName")
                        .HasMaxLength(20);

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("WebPorfolioGenerator.Models.Client", b =>
                {
                    b.HasBaseType("WebPorfolioGenerator.Models.User");

                    b.Property<string>("BussinesName");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("PortfolioId");

                    b.Property<string>("PortfolioInfo");

                    b.ToTable("Clients");

                    b.HasDiscriminator().HasValue("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
