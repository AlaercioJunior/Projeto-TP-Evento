﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP_MS_Evento;

#nullable disable

namespace TP_MS_Evento.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Entidades.EntidadeEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Atracao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Cancelado")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("QuantidadeIngresso")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantidadeVendida")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ValorIngresso")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Evento");
                });
#pragma warning restore 612, 618
        }
    }
}
