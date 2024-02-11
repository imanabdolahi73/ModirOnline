﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModirOnline.ProductManagement.Persistence.Context;

#nullable disable

namespace ModirOnlline.ProductManagement.Persistence.Migrations
{
    [DbContext(typeof(DbContextProductManagment))]
    partial class DbContextProductManagmentModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ModirOnlline.ProductManagement.Domain.Entities.Material", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid?>("DeleteByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InsertByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("bit");

                    b.Property<long>("MaterialCategoryId")
                        .HasColumnType("bigint");

                    b.Property<int>("MaterialUnitType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdateByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MaterialCategoryId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("ModirOnlline.ProductManagement.Domain.Entities.MaterialCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid?>("DeleteByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InsertByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdateByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MaterialCategories");
                });

            modelBuilder.Entity("ModirOnlline.ProductManagement.Domain.Entities.MaterialUsed", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid?>("DeleteByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InsertByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("MaterialId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdateByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("ProductId");

                    b.ToTable("MaterialUseds");
                });

            modelBuilder.Entity("ModirOnlline.ProductManagement.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid?>("DeleteByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InsertByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("bit");

                    b.Property<string>("PhotoAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdateByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ModirOnlline.ProductManagement.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid?>("DeleteByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InsertByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdateByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("ModirOnlline.ProductManagement.Domain.Entities.Material", b =>
                {
                    b.HasOne("ModirOnlline.ProductManagement.Domain.Entities.MaterialCategory", "MaterialCategory")
                        .WithMany("Materials")
                        .HasForeignKey("MaterialCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaterialCategory");
                });

            modelBuilder.Entity("ModirOnlline.ProductManagement.Domain.Entities.MaterialUsed", b =>
                {
                    b.HasOne("ModirOnlline.ProductManagement.Domain.Entities.Material", "Material")
                        .WithMany("MaterialUseds")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModirOnlline.ProductManagement.Domain.Entities.Product", "Product")
                        .WithMany("MaterialUseds")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ModirOnlline.ProductManagement.Domain.Entities.Product", b =>
                {
                    b.HasOne("ModirOnlline.ProductManagement.Domain.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("ModirOnlline.ProductManagement.Domain.Entities.Material", b =>
                {
                    b.Navigation("MaterialUseds");
                });

            modelBuilder.Entity("ModirOnlline.ProductManagement.Domain.Entities.MaterialCategory", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("ModirOnlline.ProductManagement.Domain.Entities.Product", b =>
                {
                    b.Navigation("MaterialUseds");
                });

            modelBuilder.Entity("ModirOnlline.ProductManagement.Domain.Entities.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
