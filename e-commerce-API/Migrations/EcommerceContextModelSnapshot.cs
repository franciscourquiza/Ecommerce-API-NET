﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using e_commerce_API.Context;

#nullable disable

namespace e_commerce_API.Migrations
{
    [DbContext(typeof(EcommerceContext))]
    partial class EcommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("e_commerce_API.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<float>("OrderPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientEmail");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("e_commerce_API.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("SizeClothes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StyleClothes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypeClothes")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("e_commerce_API.Data.Entities.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Email");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("e_commerce_API.Data.Entities.Admin", b =>
                {
                    b.HasBaseType("e_commerce_API.Data.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("e_commerce_API.Data.Entities.Client", b =>
                {
                    b.HasBaseType("e_commerce_API.Data.Entities.User");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Dni")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("e_commerce_API.Data.Entities.SuperAdmin", b =>
                {
                    b.HasBaseType("e_commerce_API.Data.Entities.User");

                    b.HasDiscriminator().HasValue("SuperAdmin");
                });

            modelBuilder.Entity("e_commerce_API.Data.Entities.Order", b =>
                {
                    b.HasOne("e_commerce_API.Data.Entities.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("e_commerce_API.Data.Entities.Product", b =>
                {
                    b.HasOne("e_commerce_API.Data.Entities.Order", null)
                        .WithMany("OrderedProducts")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("e_commerce_API.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderedProducts");
                });

            modelBuilder.Entity("e_commerce_API.Data.Entities.Client", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
