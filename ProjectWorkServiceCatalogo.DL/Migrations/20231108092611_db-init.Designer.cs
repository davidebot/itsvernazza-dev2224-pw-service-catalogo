﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectWorkServiceCatalogo.DL;

#nullable disable

namespace ProjectWorkServiceCatalogo.DL.Migrations
{
    [DbContext(typeof(CatalogoServiceDbContext))]
    [Migration("20231108092611_db-init")]
    partial class dbinit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjectWorkServiceCatalogo.DL.Models.TbCategoria", b =>
                {
                    b.Property<long>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("IdCategoria"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("NOME");

                    b.HasKey("IdCategoria");

                    b.ToTable("CATEGORIA");
                });
#pragma warning restore 612, 618
        }
    }
}
