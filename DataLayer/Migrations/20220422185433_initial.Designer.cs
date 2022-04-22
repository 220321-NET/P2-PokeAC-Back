﻿// <auto-generated />
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(PACDBContext))]
    [Migration("20220422185433_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Pokemon", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("attack")
                        .HasColumnType("integer");

                    b.Property<int>("childID")
                        .HasColumnType("integer");

                    b.Property<string>("combatAI")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("defense")
                        .HasColumnType("integer");

                    b.Property<int>("hp")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("parentID")
                        .HasColumnType("integer");

                    b.Property<int>("rarity")
                        .HasColumnType("integer");

                    b.Property<int>("special")
                        .HasColumnType("integer");

                    b.Property<string>("specialAttack")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("type1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("type2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("losses")
                        .HasColumnType("integer");

                    b.Property<int>("matches")
                        .HasColumnType("integer");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("wins")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}