﻿// <auto-generated />
using System;
using CreateDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CreateDb.Migrations
{
    [DbContext(typeof(DecimalFloatTailZeroContext))]
    partial class DecimalFloatTailZeroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CreateDb.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("ID")
                        .UseIdentityColumn();

                    b.Property<string>("BusinessTax")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasComment("營業稅");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Guid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("名稱");

                    b.Property<string>("SubTotal")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasComment("小計");

                    b.Property<string>("Total")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasComment("總計");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasIndex("Guid")
                        .IsUnique()
                        .HasDatabaseName("IX_Order_Guid");

                    b.ToTable("Order", "dbo");
                });

            modelBuilder.Entity("CreateDb.OrderDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasComment("金額");

                    b.Property<string>("Comment")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("備註");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasComment("數量");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Guid");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("項目");

                    b.Property<Guid>("OrderGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("訂單 Guid");

                    b.Property<string>("UnitPrice")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasComment("單價");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasIndex("Guid")
                        .IsUnique()
                        .HasDatabaseName("IX_OrderDetail_Guid");

                    b.HasIndex("OrderGuid");

                    b.ToTable("OrderDetail", "dbo");
                });

            modelBuilder.Entity("CreateDb.OrderDetail", b =>
                {
                    b.HasOne("CreateDb.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderGuid")
                        .HasConstraintName("FK_OrderDetail_OrderGuid_Order_Guid")
                        .HasPrincipalKey("Guid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
