﻿// <auto-generated />
using System;
using Ecommerce.Infrastructure.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce.Infrastructure.Migrations
{
    [DbContext(typeof(EfCoreContext))]
    [Migration("20250101015236_TestMigration")]
    partial class TestMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecommerce.Domain.ProductAggregate.Entities.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategories", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.ProductAggregate.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SellerId");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ProductProductCategory", b =>
                {
                    b.Property<Guid>("ProductCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductCategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategoryLink", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.ProductAggregate.Entities.ProductCategory", b =>
                {
                    b.HasOne("Ecommerce.Domain.ProductAggregate.Product", null)
                        .WithMany("Categories")
                        .HasForeignKey("ProductId");

                    b.OwnsOne("Ecommerce.Domain.ProductAggregate.ValueObjects.ProductCategoryName", "Name", b1 =>
                        {
                            b1.Property<Guid>("ProductCategoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("Name");

                            b1.HasKey("ProductCategoryId");

                            b1.ToTable("ProductCategories");

                            b1.WithOwner()
                                .HasForeignKey("ProductCategoryId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Ecommerce.Domain.ProductAggregate.Product", b =>
                {
                    b.OwnsOne("Ecommerce.Domain.Common.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(3)
                                .HasColumnType("nvarchar(3)")
                                .HasColumnName("PriceCurrency");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("PriceValue");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("Ecommerce.Domain.ProductAggregate.Entities.ProductImage", "Thumbnail", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FileName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<long?>("FileSize")
                                .HasColumnType("bigint");

                            b1.Property<string>("FileType")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id", "ProductId");

                            b1.HasIndex("ProductId")
                                .IsUnique();

                            b1.ToTable("ProductThumbnails", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("Ecommerce.Domain.ProductAggregate.Entities.ProductImages", "Images", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ProductImageId");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("BackImageUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FrontImageUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LeftImageUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("RightImageUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id", "ProductId");

                            b1.HasIndex("ProductId")
                                .IsUnique();

                            b1.ToTable("ProductImages", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsMany("Ecommerce.Domain.ProductAggregate.Entities.ProductReview", "Reviews", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ReviewId");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("nvarchar(1000)");

                            b1.HasKey("Id", "ProductId");

                            b1.HasIndex("ProductId");

                            b1.ToTable("ProductReviews", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ProductId");

                            b1.OwnsOne("Ecommerce.Domain.ProductAggregate.ValueObjects.Rating", "Rating", b2 =>
                                {
                                    b2.Property<Guid>("ProductReviewId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("ProductReviewProductId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<decimal>("Value")
                                        .HasColumnType("decimal(18,2)")
                                        .HasColumnName("Rating");

                                    b2.HasKey("ProductReviewId", "ProductReviewProductId");

                                    b2.ToTable("ProductReviews");

                                    b2.WithOwner()
                                        .HasForeignKey("ProductReviewId", "ProductReviewProductId");
                                });

                            b1.OwnsOne("Ecommerce.Domain.UserAggregate.ValueObjects.UserId", "AuthorId", b2 =>
                                {
                                    b2.Property<Guid>("ProductReviewId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("ProductReviewProductId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("Value")
                                        .HasColumnType("uniqueidentifier")
                                        .HasColumnName("AuthorId");

                                    b2.HasKey("ProductReviewId", "ProductReviewProductId");

                                    b2.ToTable("ProductReviews");

                                    b2.WithOwner()
                                        .HasForeignKey("ProductReviewId", "ProductReviewProductId");
                                });

                            b1.Navigation("AuthorId")
                                .IsRequired();

                            b1.Navigation("Rating")
                                .IsRequired();
                        });

                    b.OwnsMany("Ecommerce.Domain.ProductAggregate.Entities.ProductTag", "Tags", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("TagId");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("TagName");

                            b1.HasKey("Id", "ProductId");

                            b1.HasIndex("ProductId");

                            b1.ToTable("ProductTags", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("Ecommerce.Domain.ProductAggregate.Entities.Promotion", "Promotion", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ProductPromotionId");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("DiscountPercentage")
                                .HasColumnType("int");

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("datetime2");

                            b1.HasKey("Id", "ProductId");

                            b1.HasIndex("ProductId")
                                .IsUnique();

                            b1.ToTable("ProductPromotions", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("Ecommerce.Domain.ProductAggregate.ValueObjects.Rating", "AverageRating", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("decimal(18,2)")
                                .HasDefaultValue(0m)
                                .HasColumnName("AverageRating");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("Ecommerce.Domain.ProductAggregate.ValueObjects.ProductDescription", "Description", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("nvarchar(1000)")
                                .HasColumnName("Description");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("Ecommerce.Domain.ProductAggregate.ValueObjects.ProductName", "Name", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("Name");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("Ecommerce.Domain.ProductAggregate.ValueObjects.Stock", "Stock", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Reserved")
                                .HasColumnType("int")
                                .HasColumnName("StockReserved");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");

                            b1.OwnsOne("Ecommerce.Domain.ProductAggregate.ValueObjects.Quantity", "Quantity", b2 =>
                                {
                                    b2.Property<Guid>("StockProductId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<int>("Value")
                                        .HasColumnType("int")
                                        .HasColumnName("StockQuantity");

                                    b2.HasKey("StockProductId");

                                    b2.ToTable("Products");

                                    b2.WithOwner()
                                        .HasForeignKey("StockProductId");
                                });

                            b1.Navigation("Quantity")
                                .IsRequired();
                        });

                    b.Navigation("AverageRating")
                        .IsRequired();

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Images")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("Promotion")
                        .IsRequired();

                    b.Navigation("Reviews");

                    b.Navigation("Stock")
                        .IsRequired();

                    b.Navigation("Tags");

                    b.Navigation("Thumbnail")
                        .IsRequired();
                });

            modelBuilder.Entity("Ecommerce.Domain.UserAggregate.User", b =>
                {
                    b.OwnsOne("Ecommerce.Domain.Common.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Ecommerce.Domain.Common.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(512)
                                .HasColumnType("nvarchar(512)")
                                .HasColumnName("Password");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Ecommerce.Domain.Common.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("nvarchar(15)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Ecommerce.Domain.UserAggregate.ValueObjects.Name", "FirstName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("FirstName");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Ecommerce.Domain.UserAggregate.ValueObjects.Name", "LastName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("LastName");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("FirstName")
                        .IsRequired();

                    b.Navigation("LastName")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });

            modelBuilder.Entity("ProductProductCategory", b =>
                {
                    b.HasOne("Ecommerce.Domain.ProductAggregate.Entities.ProductCategory", null)
                        .WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.Domain.ProductAggregate.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ecommerce.Domain.ProductAggregate.Product", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
