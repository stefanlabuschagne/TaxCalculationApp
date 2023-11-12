﻿// <auto-generated />
using System;
using BackendAPI.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendAPI.Migrations
{
    [DbContext(typeof(TaxDbContext))]
    partial class TaxDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackendAPI.Domain.Entities.TaxRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TaxCalculated")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TaxableAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TimeCalculated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TaxRecord");
                });
#pragma warning restore 612, 618
        }
    }
}
