﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockTraderBroker.Data;

namespace StockTraderBroker.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200603183332_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockTraderBroker.Models.StockTrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StockAmount")
                        .HasColumnType("int");

                    b.Property<int?>("StockBuyerId")
                        .HasColumnType("int");

                    b.Property<double>("StockPrice")
                        .HasColumnType("float");

                    b.Property<int>("StockSellerId")
                        .HasColumnType("int");

                    b.Property<bool>("StockTransferComplete")
                        .HasColumnType("bit");

                    b.Property<double?>("TaxAmount")
                        .HasColumnType("float");

                    b.Property<bool>("TransactionComplete")
                        .HasColumnType("bit");

                    b.Property<int>("TransferStockId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StockTrade");
                });
#pragma warning restore 612, 618
        }
    }
}
