﻿// <auto-generated />
using System;
using AgroConnect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgroConnect.Migrations
{
    [DbContext(typeof(AgroConnectDbContext))]
    [Migration("20240601235805_Migracao004_Correcao001_RelacionamentoGadoGadoHistorico")]
    partial class Migracao004_Correcao001_RelacionamentoGadoGadoHistorico
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AgroConnect.Models.Gado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HistoricoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Peso")
                        .HasColumnType("double precision");

                    b.Property<string>("Raca")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HistoricoId")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.ToTable("gados");
                });

            modelBuilder.Entity("AgroConnect.Models.GadoHistorico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Reproducao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Saude")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Vacina")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("gadoHistoricos");
                });

            modelBuilder.Entity("AgroConnect.Models.Plantacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataColheita")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataPlantio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("plantacoes");
                });

            modelBuilder.Entity("AgroConnect.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("AgroConnect.Models.Gado", b =>
                {
                    b.HasOne("AgroConnect.Models.GadoHistorico", "Historico")
                        .WithOne()
                        .HasForeignKey("AgroConnect.Models.Gado", "HistoricoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroConnect.Models.Usuario", "Usuario")
                        .WithMany("Gados")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Historico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AgroConnect.Models.Plantacao", b =>
                {
                    b.HasOne("AgroConnect.Models.Usuario", "Usuario")
                        .WithMany("Plantacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AgroConnect.Models.Usuario", b =>
                {
                    b.Navigation("Gados");

                    b.Navigation("Plantacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
