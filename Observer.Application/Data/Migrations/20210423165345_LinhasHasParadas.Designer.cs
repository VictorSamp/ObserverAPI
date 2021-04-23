﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObserverAPI.Data;

namespace ObserverAPI.Data.Migrations
{
    [DbContext(typeof(ObserverDbContext))]
    [Migration("20210423165345_LinhasHasParadas")]
    partial class LinhasHasParadas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LinhaParada", b =>
                {
                    b.Property<long>("LinhasId")
                        .HasColumnType("bigint");

                    b.Property<long>("ParadasId")
                        .HasColumnType("bigint");

                    b.HasKey("LinhasId", "ParadasId");

                    b.HasIndex("ParadasId");

                    b.ToTable("LinhaParada");
                });

            modelBuilder.Entity("ObserverAPI.Entities.Linha", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Linhas");
                });

            modelBuilder.Entity("ObserverAPI.Entities.Parada", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paradas");
                });

            modelBuilder.Entity("ObserverAPI.Entities.Veiculo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("LinhaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LinhaId")
                        .IsUnique();

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("LinhaParada", b =>
                {
                    b.HasOne("ObserverAPI.Entities.Linha", null)
                        .WithMany()
                        .HasForeignKey("LinhasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObserverAPI.Entities.Parada", null)
                        .WithMany()
                        .HasForeignKey("ParadasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ObserverAPI.Entities.Veiculo", b =>
                {
                    b.HasOne("ObserverAPI.Entities.Linha", null)
                        .WithOne()
                        .HasForeignKey("ObserverAPI.Entities.Veiculo", "LinhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
