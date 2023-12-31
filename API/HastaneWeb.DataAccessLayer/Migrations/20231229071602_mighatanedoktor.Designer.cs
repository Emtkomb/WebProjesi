﻿// <auto-generated />
using System;
using HastaneWeb.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HastaneWeb.DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231229071602_mighatanedoktor")]
    partial class mighatanedoktor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HastaneWeb.EntityLayer.Concrete.Birim", b =>
                {
                    b.Property<int>("BirimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BirimID"), 1L, 1);

                    b.Property<int?>("HastaneID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BirimID");

                    b.HasIndex("HastaneID");

                    b.ToTable("Birimler");
                });

            modelBuilder.Entity("HastaneWeb.EntityLayer.Concrete.Doktor", b =>
                {
                    b.Property<int>("DoktorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoktorID"), 1L, 1);

                    b.Property<int?>("BirimID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CikisTarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoktorMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorTelefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("GirisTarih")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HastaneID")
                        .HasColumnType("int");

                    b.HasKey("DoktorID");

                    b.HasIndex("BirimID");

                    b.HasIndex("HastaneID");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("HastaneWeb.EntityLayer.Concrete.Hastane", b =>
                {
                    b.Property<int?>("HastaneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("HastaneID"), 1L, 1);

                    b.Property<string>("HastaneAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HastaneAdresi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HastaneResim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HastaneTelefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HastaneID");

                    b.ToTable("Hastaneler");
                });

            modelBuilder.Entity("HastaneWeb.EntityLayer.Concrete.Hizmet", b =>
                {
                    b.Property<int>("HizmetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HizmetID"), 1L, 1);

                    b.Property<string>("HizmetAciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HizmetIcon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HizmetTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HizmetID");

                    b.ToTable("Hizmetler");
                });

            modelBuilder.Entity("HastaneWeb.EntityLayer.Concrete.Randevu", b =>
                {
                    b.Property<int>("RandevuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RandevuID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sikayet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RandevuID");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("HastaneWeb.EntityLayer.Concrete.Birim", b =>
                {
                    b.HasOne("HastaneWeb.EntityLayer.Concrete.Hastane", "Hastane")
                        .WithMany("Birimler")
                        .HasForeignKey("HastaneID");

                    b.Navigation("Hastane");
                });

            modelBuilder.Entity("HastaneWeb.EntityLayer.Concrete.Doktor", b =>
                {
                    b.HasOne("HastaneWeb.EntityLayer.Concrete.Birim", "Birim")
                        .WithMany("Doktorlar")
                        .HasForeignKey("BirimID");

                    b.HasOne("HastaneWeb.EntityLayer.Concrete.Hastane", "Hastane")
                        .WithMany("Doktorlar")
                        .HasForeignKey("HastaneID");

                    b.Navigation("Birim");

                    b.Navigation("Hastane");
                });

            modelBuilder.Entity("HastaneWeb.EntityLayer.Concrete.Birim", b =>
                {
                    b.Navigation("Doktorlar");
                });

            modelBuilder.Entity("HastaneWeb.EntityLayer.Concrete.Hastane", b =>
                {
                    b.Navigation("Birimler");

                    b.Navigation("Doktorlar");
                });
#pragma warning restore 612, 618
        }
    }
}
