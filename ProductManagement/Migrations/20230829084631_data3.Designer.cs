﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductManagement;

#nullable disable

namespace ProductManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230829084631_data3")]
    partial class data3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductManagement.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("Avartar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("DecentralizationId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResetPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetPasswordTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("User_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("DecentralizationId");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("ProductManagement.Models.Decentralization", b =>
                {
                    b.Property<int>("DecentralizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DecentralizationId"));

                    b.Property<string>("Authorrity_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Create_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("DecentralizationId");

                    b.ToTable("decentralizations");
                });

            modelBuilder.Entity("ProductManagement.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<double>("Actual_Price")
                        .HasColumnType("float");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Full_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order_StatusId")
                        .HasColumnType("int");

                    b.Property<double>("Orginal_Price")
                        .HasColumnType("float");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("Order_StatusId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("UserId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("ProductManagement.Models.Order_detail", b =>
                {
                    b.Property<int>("Order_DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Order_DetailId"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price_total")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Order_DetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("orders_detail");
                });

            modelBuilder.Entity("ProductManagement.Models.Order_status", b =>
                {
                    b.Property<int>("Order_StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Order_StatusId"));

                    b.Property<string>("Status_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Order_StatusId");

                    b.ToTable("order_Statuses");
                });

            modelBuilder.Entity("ProductManagement.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payment_method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("PaymentId");

                    b.ToTable("payment");
                });

            modelBuilder.Entity("ProductManagement.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Avartar_image_product")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Create_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("Name_product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Product_TypeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Update_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("number_of_views")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("Product_TypeId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("ProductManagement.Models.Product_image", b =>
                {
                    b.Property<int>("Product_ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_ImageId"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image_product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Product_ImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("product_Images");
                });

            modelBuilder.Entity("ProductManagement.Models.Product_review", b =>
                {
                    b.Property<int>("Product_ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_ReviewId"));

                    b.Property<string>("Content_rated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content_seen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("Point_evaluation")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Product_ReviewId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("product_Reviews");
                });

            modelBuilder.Entity("ProductManagement.Models.Product_type", b =>
                {
                    b.Property<int>("Product_TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_TypeId"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image_type_product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_product_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Product_TypeId");

                    b.ToTable("product_Types");
                });

            modelBuilder.Entity("ProductManagement.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("User_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("ProductManagement.Models.Account", b =>
                {
                    b.HasOne("ProductManagement.Models.Decentralization", "Decentralization")
                        .WithMany("Accounts")
                        .HasForeignKey("DecentralizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Decentralization");
                });

            modelBuilder.Entity("ProductManagement.Models.Order", b =>
                {
                    b.HasOne("ProductManagement.Models.Order_status", "Order_Status")
                        .WithMany("Orders")
                        .HasForeignKey("Order_StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductManagement.Models.Payment", "Payment")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductManagement.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order_Status");

                    b.Navigation("Payment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProductManagement.Models.Order_detail", b =>
                {
                    b.HasOne("ProductManagement.Models.Order", "Order")
                        .WithMany("Order_Details")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductManagement.Models.Product", "Product")
                        .WithMany("Order_Details")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductManagement.Models.Product", b =>
                {
                    b.HasOne("ProductManagement.Models.Product_type", "Product_Type")
                        .WithMany("Products")
                        .HasForeignKey("Product_TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product_Type");
                });

            modelBuilder.Entity("ProductManagement.Models.Product_image", b =>
                {
                    b.HasOne("ProductManagement.Models.Product", "Product")
                        .WithMany("Product_Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductManagement.Models.Product_review", b =>
                {
                    b.HasOne("ProductManagement.Models.Product", "Product")
                        .WithMany("Product_Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductManagement.Models.User", "User")
                        .WithMany("Product_Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProductManagement.Models.User", b =>
                {
                    b.HasOne("ProductManagement.Models.Account", "Account")
                        .WithOne("User")
                        .HasForeignKey("ProductManagement.Models.User", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ProductManagement.Models.Account", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("ProductManagement.Models.Decentralization", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("ProductManagement.Models.Order", b =>
                {
                    b.Navigation("Order_Details");
                });

            modelBuilder.Entity("ProductManagement.Models.Order_status", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ProductManagement.Models.Payment", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ProductManagement.Models.Product", b =>
                {
                    b.Navigation("Order_Details");

                    b.Navigation("Product_Images");

                    b.Navigation("Product_Reviews");
                });

            modelBuilder.Entity("ProductManagement.Models.Product_type", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ProductManagement.Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Product_Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
