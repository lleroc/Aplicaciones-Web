﻿// <auto-generated />
using System;
using Get_Post.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Get_Post.Migrations
{
    [DbContext(typeof(Get_PostDbContext))]
    [Migration("20250225003755_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Get_Post.Models.PreguntasModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("CreateAdd")
                        .HasColumnType("date");

                    b.Property<string>("Enunciado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoPreguntaModelId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("UpdateAdd")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("TipoPreguntaModelId");

                    b.ToTable("Preguntas");
                });

            modelBuilder.Entity("Get_Post.Models.TipoPreguntaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoPreguntas");
                });

            modelBuilder.Entity("Get_Post.Models.PreguntasModel", b =>
                {
                    b.HasOne("Get_Post.Models.TipoPreguntaModel", "TipoPreguntaModel")
                        .WithMany()
                        .HasForeignKey("TipoPreguntaModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPreguntaModel");
                });
#pragma warning restore 612, 618
        }
    }
}
