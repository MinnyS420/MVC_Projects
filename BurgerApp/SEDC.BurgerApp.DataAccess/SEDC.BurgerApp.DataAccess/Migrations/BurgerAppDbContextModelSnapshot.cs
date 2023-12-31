﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.BurgerApp.DataAccess.Data;

#nullable disable

namespace SEDC.BurgerApp.DataAccess.Migrations
{
    [DbContext(typeof(BurgerAppDbContext))]
    partial class BurgerAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SEDC.BurgerApp.Domain.Models.Burger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("HasFries")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVegan")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVegetarian")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Burgers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HasFries = false,
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Chicken Burger",
                            Price = 2.0
                        },
                        new
                        {
                            Id = 2,
                            HasFries = true,
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Ham Burger",
                            Price = 3.0
                        },
                        new
                        {
                            Id = 3,
                            HasFries = true,
                            IsVegan = false,
                            IsVegetarian = true,
                            Name = "Veggie Burger",
                            Price = 2.0
                        },
                        new
                        {
                            Id = 4,
                            HasFries = true,
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Cheeseburger",
                            Price = 3.5
                        },
                        new
                        {
                            Id = 5,
                            HasFries = true,
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Double Cheeseburger",
                            Price = 5.0
                        },
                        new
                        {
                            Id = 6,
                            HasFries = true,
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Bacon Burger",
                            Price = 4.5
                        },
                        new
                        {
                            Id = 7,
                            HasFries = true,
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Fish Burger",
                            Price = 3.7999999999999998
                        },
                        new
                        {
                            Id = 8,
                            HasFries = true,
                            IsVegan = true,
                            IsVegetarian = true,
                            Name = "Mushroom Burger",
                            Price = 3.2000000000000002
                        },
                        new
                        {
                            Id = 9,
                            HasFries = true,
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "BBQ Burger",
                            Price = 4.0
                        },
                        new
                        {
                            Id = 10,
                            HasFries = true,
                            IsVegan = true,
                            IsVegetarian = true,
                            Name = "Vegan Burger",
                            Price = 3.5
                        });
                });

            modelBuilder.Entity("SEDC.BurgerApp.Domain.Models.BurgerOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BurgerId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BurgerId");

                    b.HasIndex("OrderId");

                    b.ToTable("BurgerOrder");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BurgerId = 1,
                            OrderId = 1
                        },
                        new
                        {
                            Id = 2,
                            BurgerId = 1,
                            OrderId = 1
                        },
                        new
                        {
                            Id = 3,
                            BurgerId = 3,
                            OrderId = 2
                        },
                        new
                        {
                            Id = 4,
                            BurgerId = 2,
                            OrderId = 3
                        });
                });

            modelBuilder.Entity("SEDC.BurgerApp.Domain.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("ClosesAt")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("OpensAt")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Skopje",
                            ClosesAt = new TimeSpan(0, 22, 0, 0, 0),
                            Name = "Tehno Burgeri",
                            OpensAt = new TimeSpan(0, 7, 0, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            Address = "Bitola",
                            ClosesAt = new TimeSpan(0, 22, 0, 0, 0),
                            Name = "Anhoch Burgeri",
                            OpensAt = new TimeSpan(0, 7, 0, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            Address = "Veles",
                            ClosesAt = new TimeSpan(0, 22, 0, 0, 0),
                            Name = "Setek Burgeri",
                            OpensAt = new TimeSpan(0, 7, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("SEDC.BurgerApp.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Ilinden",
                            FullName = "Bob Bobsky",
                            IsDelivered = true,
                            LocationId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Marion",
                            FullName = "Boki Boksan",
                            IsDelivered = false,
                            LocationId = 2
                        },
                        new
                        {
                            Id = 3,
                            Address = "Marion",
                            FullName = "Jhon Wick",
                            IsDelivered = false,
                            LocationId = 3
                        });
                });

            modelBuilder.Entity("SEDC.BurgerApp.Domain.Models.BurgerOrder", b =>
                {
                    b.HasOne("SEDC.BurgerApp.Domain.Models.Burger", "Burger")
                        .WithMany("BurgerOrders")
                        .HasForeignKey("BurgerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SEDC.BurgerApp.Domain.Models.Order", "Order")
                        .WithMany("BurgerOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Burger");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("SEDC.BurgerApp.Domain.Models.Order", b =>
                {
                    b.HasOne("SEDC.BurgerApp.Domain.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("SEDC.BurgerApp.Domain.Models.Burger", b =>
                {
                    b.Navigation("BurgerOrders");
                });

            modelBuilder.Entity("SEDC.BurgerApp.Domain.Models.Order", b =>
                {
                    b.Navigation("BurgerOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
