﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoresService.EntityFramework.Context;

#nullable disable

namespace StoresService.EntityFramework.Migrations
{
    [DbContext(typeof(StoresServiceDbContext))]
    partial class StoresServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompanySupplier", b =>
                {
                    b.Property<int>("CompaniesCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("SuppliersSupplierId")
                        .HasColumnType("int");

                    b.HasKey("CompaniesCompanyId", "SuppliersSupplierId");

                    b.HasIndex("SuppliersSupplierId");

                    b.ToTable("CompanySupplier");
                });

            modelBuilder.Entity("StoreSupplier", b =>
                {
                    b.Property<int>("StoresStoreId")
                        .HasColumnType("int");

                    b.Property<int>("SuppliersSupplierId")
                        .HasColumnType("int");

                    b.HasKey("StoresStoreId", "SuppliersSupplierId");

                    b.HasIndex("SuppliersSupplierId");

                    b.ToTable("StoreSupplier");
                });

            modelBuilder.Entity("StoresService.EntityFramework.Entities.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("StoresService.EntityFramework.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("StoresService.EntityFramework.Entities.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("StoresService.EntityFramework.Entities.StoreProduct", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("StoreId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("StoreProducts");
                });

            modelBuilder.Entity("StoresService.EntityFramework.Entities.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("CompanySupplier", b =>
                {
                    b.HasOne("StoresService.EntityFramework.Entities.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoresService.EntityFramework.Entities.Supplier", null)
                        .WithMany()
                        .HasForeignKey("SuppliersSupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreSupplier", b =>
                {
                    b.HasOne("StoresService.EntityFramework.Entities.Store", null)
                        .WithMany()
                        .HasForeignKey("StoresStoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoresService.EntityFramework.Entities.Supplier", null)
                        .WithMany()
                        .HasForeignKey("SuppliersSupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoresService.EntityFramework.Entities.Product", b =>
                {
                    b.HasOne("StoresService.EntityFramework.Entities.Company", null)
                        .WithMany("Products")
                        .HasForeignKey("CompanyId");

                    b.HasOne("StoresService.EntityFramework.Entities.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("StoresService.EntityFramework.Entities.StoreProduct", b =>
                {
                    b.HasOne("StoresService.EntityFramework.Entities.Product", "Product")
                        .WithMany("StoreProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoresService.EntityFramework.Entities.Store", "Store")
                        .WithMany("StoreProducts")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("StoresService.EntityFramework.Entities.Company", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StoresService.EntityFramework.Entities.Product", b =>
                {
                    b.Navigation("StoreProducts");
                });

            modelBuilder.Entity("StoresService.EntityFramework.Entities.Store", b =>
                {
                    b.Navigation("StoreProducts");
                });

            modelBuilder.Entity("StoresService.EntityFramework.Entities.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
