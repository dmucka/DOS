﻿// <auto-generated />
using System;
using DOS_DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DOS_DAL.Migrations
{
    [DbContext(typeof(DOSContext))]
    partial class DOSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DOS_DAL.ManufacturingStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Edited")
                        .HasColumnType("datetime2");

                    b.Property<int>("EditedById")
                        .HasColumnType("int");

                    b.Property<decimal>("Humidity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(8,4)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("Intensity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(8,4)")
                        .HasDefaultValue(0m);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProcessId")
                        .HasColumnType("int");

                    b.Property<decimal>("Temperature")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(8,4)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("Wavelength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(8,4)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("EditedById");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProcessId");

                    b.ToTable("ManufacturingStep");
                });

            modelBuilder.Entity("DOS_DAL.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("Customer")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("datetime2");

                    b.Property<int>("EditedById")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasMaxLength(1023)
                        .HasColumnType("nvarchar(1023)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EditedById");

                    b.HasIndex("ProductId");

                    b.HasIndex("SerialNumber")
                        .IsUnique();

                    b.ToTable("Order");
                });

            modelBuilder.Entity("DOS_DAL.Process", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Process");
                });

            modelBuilder.Entity("DOS_DAL.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1023)
                        .HasColumnType("nvarchar(1023)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Product");
                });

            modelBuilder.Entity("DOS_DAL.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Role");
                });

            modelBuilder.Entity("DOS_DAL.Tolerance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Edited")
                        .HasColumnType("datetime2");

                    b.Property<int>("EditedById")
                        .HasColumnType("int");

                    b.Property<decimal>("MaxValue")
                        .HasColumnType("decimal(8,4)");

                    b.Property<decimal>("MinValue")
                        .HasColumnType("decimal(8,4)");

                    b.Property<int>("ProcessId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ValueName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("EditedById");

                    b.HasIndex("ProcessId");

                    b.HasIndex("ProductId");

                    b.ToTable("Tolerance");
                });

            modelBuilder.Entity("DOS_DAL.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProductProcess", b =>
                {
                    b.Property<int>("ProcessId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProcessId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductProcess");
                });

            modelBuilder.Entity("DOS_DAL.ManufacturingStep", b =>
                {
                    b.HasOne("DOS_DAL.User", "EditedBy")
                        .WithMany()
                        .HasForeignKey("EditedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DOS_DAL.Order", "Order")
                        .WithMany("ManufacturingSteps")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DOS_DAL.Process", "Process")
                        .WithMany()
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EditedBy");

                    b.Navigation("Order");

                    b.Navigation("Process");
                });

            modelBuilder.Entity("DOS_DAL.Order", b =>
                {
                    b.HasOne("DOS_DAL.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DOS_DAL.User", "EditedBy")
                        .WithMany()
                        .HasForeignKey("EditedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DOS_DAL.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("EditedBy");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DOS_DAL.Tolerance", b =>
                {
                    b.HasOne("DOS_DAL.User", "EditedBy")
                        .WithMany()
                        .HasForeignKey("EditedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DOS_DAL.Process", "Process")
                        .WithMany()
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DOS_DAL.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EditedBy");

                    b.Navigation("Process");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DOS_DAL.User", b =>
                {
                    b.HasOne("DOS_DAL.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ProductProcess", b =>
                {
                    b.HasOne("DOS_DAL.Process", null)
                        .WithMany()
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DOS_DAL.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DOS_DAL.Order", b =>
                {
                    b.Navigation("ManufacturingSteps");
                });
#pragma warning restore 612, 618
        }
    }
}