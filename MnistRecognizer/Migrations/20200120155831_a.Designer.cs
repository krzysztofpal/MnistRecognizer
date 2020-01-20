﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MnistRecognizer.Modules.Database;

namespace MnistRecognizer.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20200120155831_a")]
    partial class a
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MnistRecognizer.Models.HistoryModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nazwaObrazka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numerPrzedstawiany")
                        .HasColumnType("int");

                    b.Property<string>("resultsString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("History");
                });

            modelBuilder.Entity("MnistRecognizer.Models.Layer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KernelLength")
                        .HasColumnType("int");

                    b.Property<int>("KernelWidth")
                        .HasColumnType("int");

                    b.Property<int>("NetworkID")
                        .HasColumnType("int");

                    b.Property<int>("Padding")
                        .HasColumnType("int");

                    b.Property<int>("Stride")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NetworkID");

                    b.ToTable("Layers");
                });

            modelBuilder.Entity("MnistRecognizer.Models.NetworkModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ID");

                    b.ToTable("Networks");
                });

            modelBuilder.Entity("MnistRecognizer.Models.Layer", b =>
                {
                    b.HasOne("MnistRecognizer.Models.NetworkModel", "Network")
                        .WithMany("Layers")
                        .HasForeignKey("NetworkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}