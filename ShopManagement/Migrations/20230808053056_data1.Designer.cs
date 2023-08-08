﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopManagement;

#nullable disable

namespace ShopManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230808053056_data1")]
    partial class data1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopManagement.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ShopManagement.Models.ProductDetail", b =>
                {
                    b.Property<int>("ProductDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductDetailId"));

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductDetailName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("ShellPrice")
                        .HasColumnType("float");

                    b.HasKey("ProductDetailId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("ShopManagement.Models.ProductDetailPropertyDetail", b =>
                {
                    b.Property<int>("ProductDetailPropertyDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductDetailPropertyDetailId"));

                    b.Property<int>("ProductDetailId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyDetailId")
                        .HasColumnType("int");

                    b.HasKey("ProductDetailPropertyDetailId");

                    b.HasIndex("ProductDetailId");

                    b.HasIndex("ProductId");

                    b.HasIndex("PropertyDetailId");

                    b.ToTable("ProductDetailPropertyDetails");
                });

            modelBuilder.Entity("ShopManagement.Models.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertySort")
                        .HasColumnType("int");

                    b.HasKey("PropertyId");

                    b.HasIndex("ProductId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("ShopManagement.Models.PropertyDetail", b =>
                {
                    b.Property<int>("PropertyDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyDetailId"));

                    b.Property<string>("PropertyDetailCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyDetailDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("PropertyDetailId");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyDetails");
                });

            modelBuilder.Entity("ShopManagement.Models.ProductDetailPropertyDetail", b =>
                {
                    b.HasOne("ShopManagement.Models.ProductDetail", "ProductDetail")
                        .WithMany("ProductDetailPropertyDetails")
                        .HasForeignKey("ProductDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopManagement.Models.Product", "Product")
                        .WithMany("ProductDetailPropertyDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopManagement.Models.PropertyDetail", "PropertyDetail")
                        .WithMany("ProductDetailPropertyDetails")
                        .HasForeignKey("PropertyDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductDetail");

                    b.Navigation("PropertyDetail");
                });

            modelBuilder.Entity("ShopManagement.Models.Property", b =>
                {
                    b.HasOne("ShopManagement.Models.Product", "Product")
                        .WithMany("Properties")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopManagement.Models.PropertyDetail", b =>
                {
                    b.HasOne("ShopManagement.Models.Property", "Property")
                        .WithMany("PropertyDetails")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("ShopManagement.Models.Product", b =>
                {
                    b.Navigation("ProductDetailPropertyDetails");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("ShopManagement.Models.ProductDetail", b =>
                {
                    b.Navigation("ProductDetailPropertyDetails");
                });

            modelBuilder.Entity("ShopManagement.Models.Property", b =>
                {
                    b.Navigation("PropertyDetails");
                });

            modelBuilder.Entity("ShopManagement.Models.PropertyDetail", b =>
                {
                    b.Navigation("ProductDetailPropertyDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
