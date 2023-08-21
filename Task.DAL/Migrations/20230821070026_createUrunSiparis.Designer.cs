﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task.DAL.Context;

#nullable disable

namespace Task.DAL.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20230821070026_createUrunSiparis")]
    partial class createUrunSiparis
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task.EntityLayer.Entities.Kategori", b =>
                {
                    b.Property<int>("KategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategoriId"));

                    b.Property<string>("KategoriAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UstKategoriId")
                        .HasColumnType("int");

                    b.HasKey("KategoriId");

                    b.ToTable("Kategoris");
                });

            modelBuilder.Entity("Task.EntityLayer.Entities.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KullaniciId"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciRol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TCKimlikNo")
                        .HasColumnType("int");

                    b.Property<int>("Telefon")
                        .HasColumnType("int");

                    b.HasKey("KullaniciId");

                    b.HasIndex("RolId");

                    b.ToTable("Kullanicis");
                });

            modelBuilder.Entity("Task.EntityLayer.Entities.Marka", b =>
                {
                    b.Property<int>("MarkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarkaId"));

                    b.Property<string>("MarkaAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MarkaId");

                    b.ToTable("Markas");
                });

            modelBuilder.Entity("Task.EntityLayer.Entities.Model", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModelId"));

                    b.Property<string>("ModelAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModelId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("Task.EntityLayer.Entities.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"));

                    b.Property<string>("RolAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolId");

                    b.ToTable("Rols");
                });

            modelBuilder.Entity("Task.EntityLayer.Entities.Siparis", b =>
                {
                    b.Property<int>("SiparisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiparisId"));

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<bool>("SatinAlindiMi")
                        .HasColumnType("bit");

                    b.HasKey("SiparisId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Siparis");
                });

            modelBuilder.Entity("Task.EntityLayer.Entities.Urun", b =>
                {
                    b.Property<int>("UrunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UrunId"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gorsel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<int>("MarkaId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.Property<float>("Ucret")
                        .HasColumnType("real");

                    b.Property<string>("UrunAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("YayindaMi")
                        .HasColumnType("bit");

                    b.HasKey("UrunId");

                    b.HasIndex("KategoriId");

                    b.HasIndex("MarkaId");

                    b.HasIndex("ModelId");

                    b.ToTable("Uruns");
                });

            modelBuilder.Entity("UrunSiparis", b =>
                {
                    b.Property<int>("SiparisId")
                        .HasColumnType("int");

                    b.Property<int>("UrunId")
                        .HasColumnType("int");

                    b.Property<int>("Adet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("SiparisId", "UrunId");

                    b.HasIndex("UrunId");

                    b.ToTable("UrunSiparis");
                });

            modelBuilder.Entity("Task.EntityLayer.Entities.Kullanici", b =>
                {
                    b.HasOne("Task.EntityLayer.Entities.Rol", "Rol")
                        .WithMany("Kullanicis")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Task.EntityLayer.Entities.Siparis", b =>
                {
                    b.HasOne("Task.EntityLayer.Entities.Kullanici", "Kullanici")
                        .WithMany("Siparis")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("Task.EntityLayer.Entities.Urun", b =>
                {
                    b.HasOne("Task.EntityLayer.Entities.Kategori", "Kategori")
                        .WithMany("Uruns")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task.EntityLayer.Entities.Marka", "Marka")
                        .WithMany("Uruns")
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task.EntityLayer.Entities.Model", "Model")
                        .WithMany("Uruns")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");

                    b.Navigation("Marka");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("UrunSiparis", b =>
                {
                    b.HasOne("Task.EntityLayer.Entities.Siparis", null)
                        .WithMany()
                        .HasForeignKey("SiparisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task.EntityLayer.Entities.Urun", null)
                        .WithMany()
                        .HasForeignKey("UrunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Task.EntityLayer.Entities.Kategori", b =>
                {
                    b.Navigation("Uruns");
                });

            modelBuilder.Entity("Task.EntityLayer.Entities.Kullanici", b =>
                {
                    b.Navigation("Siparis");
                });

            modelBuilder.Entity("Task.EntityLayer.Entities.Marka", b =>
                {
                    b.Navigation("Uruns");
                });

            modelBuilder.Entity("Task.EntityLayer.Entities.Model", b =>
                {
                    b.Navigation("Uruns");
                });

            modelBuilder.Entity("Task.EntityLayer.Entities.Rol", b =>
                {
                    b.Navigation("Kullanicis");
                });
#pragma warning restore 612, 618
        }
    }
}
