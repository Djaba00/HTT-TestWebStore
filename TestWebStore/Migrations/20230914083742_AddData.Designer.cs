﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestWebStore.DataAccess.ApplicationContext;

#nullable disable

namespace HTT_TestWeb.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230914083742_AddData")]
    partial class AddData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestWebStore.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Электроника"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Посуда"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Компьютерная переферия"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Мебель"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Спорт"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Автомобили"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Продукты питания"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Бытовая техника"
                        });
                });

            modelBuilder.Entity("TestWebStore.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("inStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 8,
                            Description = "Это холодильник",
                            Name = "Холодильник",
                            Price = 10000,
                            inStock = 50
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 8,
                            Description = "Это плита",
                            Name = "Плита",
                            Price = 8000,
                            inStock = 70
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 8,
                            Description = "Это стиральная машина",
                            Name = "Стиральная машина",
                            Price = 6000,
                            inStock = 30
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Description = "Это диван",
                            Name = "Диван",
                            Price = 5000,
                            inStock = 60
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 4,
                            Description = "Это шкаф",
                            Name = "Шкаф",
                            Price = 15000,
                            inStock = 20
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 5,
                            Description = "Это беговая дорожка",
                            Name = "Беговая дорожка",
                            Price = 20000,
                            inStock = 50
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 6,
                            Description = "Это Lada Vesta",
                            Name = "Lada Vesta",
                            Price = 1500000,
                            inStock = 10
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = "Это клавиатура",
                            Name = "Клавиатура",
                            Price = 3000,
                            inStock = 70
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Description = "Это компьютерная мышь",
                            Name = "Компьютерная мышь",
                            Price = 2000,
                            inStock = 70
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            Description = "Это сковорода",
                            Name = "Сковорода",
                            Price = 3000,
                            inStock = 25
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 7,
                            Description = "Это чизбургер",
                            Name = "Чизбургер",
                            Price = 50,
                            inStock = 100
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 1,
                            Description = "Это телевизор",
                            Name = "Телевизор",
                            Price = 30000,
                            inStock = 50
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 1,
                            Description = "Это телефон",
                            Name = "Телефон",
                            Price = 25000,
                            inStock = 50
                        });
                });

            modelBuilder.Entity("TestWebStore.Models.Entities.Product", b =>
                {
                    b.HasOne("TestWebStore.Models.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TestWebStore.Models.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}