﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarehouseInformationSystem.Data;

#nullable disable

namespace WarehouseInformationSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221124213958_test3")]
    partial class test3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WarehouseInformationSystem.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.CategoryOfProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("CategoryOfProducts");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.Location", b =>
                {
                    b.Property<int>("WarehouseNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("RackNumber")
                        .HasColumnType("int");

                    b.Property<int>("ShelfNumber")
                        .HasColumnType("int");

                    b.HasKey("WarehouseNumber");

                    b.HasIndex("AddressId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryOfProductId")
                        .HasColumnType("int");

                    b.Property<string>("Characteristic")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<int>("LocationWarehouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal?>("PurchasePrice")
                        .HasPrecision(20, 2)
                        .HasColumnType("decimal(20,2)");

                    b.Property<decimal>("SalePrice")
                        .HasPrecision(20, 2)
                        .HasColumnType("decimal(20,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryOfProductId");

                    b.HasIndex("LocationWarehouseNumber");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("SecondName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.Employee", b =>
                {
                    b.HasBaseType("WarehouseInformationSystem.Model.User");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasPrecision(20, 2)
                        .HasColumnType("decimal(20,2)");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PostId");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.Location", b =>
                {
                    b.HasOne("WarehouseInformationSystem.Model.Address", "Address")
                        .WithMany("Locations")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.Product", b =>
                {
                    b.HasOne("WarehouseInformationSystem.Model.CategoryOfProduct", "CategoryOfProduct")
                        .WithMany("Products")
                        .HasForeignKey("CategoryOfProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseInformationSystem.Model.Location", "Location")
                        .WithMany("Products")
                        .HasForeignKey("LocationWarehouseNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryOfProduct");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.Employee", b =>
                {
                    b.HasOne("WarehouseInformationSystem.Model.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseInformationSystem.Model.Post", "Post")
                        .WithMany("Employees")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.Address", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.CategoryOfProduct", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.Location", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WarehouseInformationSystem.Model.Post", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
