﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HHPW_BE.Migrations
{
    [DbContext(typeof(HHPWDbContext))]
    partial class HHPWDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HHPW.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("ItemId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            Name = "Pepperoni Pizza",
                            Price = 20
                        },
                        new
                        {
                            ItemId = 2,
                            Name = "Cheese Pizza",
                            Price = 18
                        },
                        new
                        {
                            ItemId = 3,
                            Name = "Veggie Supreme Pizza",
                            Price = 22
                        },
                        new
                        {
                            ItemId = 4,
                            Name = "8pc Hot Wings",
                            Price = 16
                        },
                        new
                        {
                            ItemId = 5,
                            Name = "Ranch",
                            Price = 2
                        },
                        new
                        {
                            ItemId = 6,
                            Name = "Hot Sauce",
                            Price = 3
                        },
                        new
                        {
                            ItemId = 7,
                            Name = "Garlic Bread",
                            Price = 14
                        },
                        new
                        {
                            ItemId = 8,
                            Name = "Spicy Marg Pizza",
                            Price = 19
                        });
                });

            modelBuilder.Entity("HHPW.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime?>("CloseTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPhone")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PaymentType")
                        .HasColumnType("text");

                    b.Property<int>("RevTotal")
                        .HasColumnType("integer");

                    b.Property<int>("Tip")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CustomerName = "Roz Doyle",
                            CustomerPhone = "(615)123-4567",
                            Email = "roz@kacl.org",
                            IsOpen = true,
                            IsPhone = true,
                            OrderTime = new DateTime(2024, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            RevTotal = 100,
                            Tip = 0,
                            UserId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            CustomerName = "Frasier Crane",
                            CustomerPhone = "(615)111-2222",
                            Email = "frasier@kacl.org",
                            IsOpen = true,
                            IsPhone = false,
                            OrderTime = new DateTime(2024, 4, 3, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            RevTotal = 40,
                            Tip = 0,
                            UserId = 2
                        },
                        new
                        {
                            OrderId = 3,
                            CloseTime = new DateTime(2024, 4, 3, 6, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerName = "Daphne Moon",
                            CustomerPhone = "(615)222-4567",
                            Email = "daphnemoon@hotmail.com",
                            IsOpen = false,
                            IsPhone = true,
                            OrderTime = new DateTime(2024, 4, 3, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentType = "Debit",
                            RevTotal = 70,
                            Tip = 30,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("HHPW.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("OrderItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemId = 1,
                            ItemId = 1,
                            OrderId = 1
                        },
                        new
                        {
                            OrderItemId = 2,
                            ItemId = 1,
                            OrderId = 1
                        },
                        new
                        {
                            OrderItemId = 3,
                            ItemId = 3,
                            OrderId = 2
                        });
                });

            modelBuilder.Entity("HHPW.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("FirebaseKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FirebaseKey = "BcS4IidUlKN6C5itScUEufIaQAG3",
                            Name = "Lilith Sternin"
                        },
                        new
                        {
                            UserId = 2,
                            FirebaseKey = "firebaseKey2",
                            Name = "Niles Crane"
                        });
                });

            modelBuilder.Entity("HHPW.Models.OrderItem", b =>
                {
                    b.HasOne("HHPW.Models.Item", "Item")
                        .WithMany("Order")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HHPW.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("HHPW.Models.Item", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("HHPW.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
