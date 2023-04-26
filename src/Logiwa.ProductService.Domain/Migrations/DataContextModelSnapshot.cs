﻿// <auto-generated />
using System;
using Logiwa.ProductService.Domain.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Logiwa.ProductService.Domain.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean")
                        .HasColumnName("deleted");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_category");

                    b.HasIndex("Deleted")
                        .HasDatabaseName("ix_category_deleted");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("Logiwa.ProductService.Domain.Data.EntityFramework.Entities.ProductCategoryStocks.ProductCategoryStock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean")
                        .HasColumnName("deleted");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<int>("MinStockQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("min_stock_quantity");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_product_category_stock");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_product_category_stock_category_id");

                    b.HasIndex("Deleted")
                        .HasDatabaseName("ix_product_category_stock_deleted");

                    b.HasIndex("ProductId")
                        .IsUnique()
                        .HasDatabaseName("ix_product_category_stock_product_id");

                    b.ToTable("product_category_stock", (string)null);
                });

            modelBuilder.Entity("Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean")
                        .HasColumnName("deleted");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("stock_quantity");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_product");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_product_category_id");

                    b.HasIndex("Deleted")
                        .HasDatabaseName("ix_product_deleted");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("Logiwa.ProductService.Domain.Data.EntityFramework.Entities.ProductCategoryStocks.ProductCategoryStock", b =>
                {
                    b.HasOne("Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_category_stock_category_category_id");

                    b.HasOne("Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Products.Product", "Product")
                        .WithOne("ProductCategoryStock")
                        .HasForeignKey("Logiwa.ProductService.Domain.Data.EntityFramework.Entities.ProductCategoryStocks.ProductCategoryStock", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_category_stock_products_product_id");

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Products.Product", b =>
                {
                    b.HasOne("Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_product_category_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Products.Product", b =>
                {
                    b.Navigation("ProductCategoryStock");
                });
#pragma warning restore 612, 618
        }
    }
}
