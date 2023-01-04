﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEB.Contexto;

#nullable disable

namespace WEB.Migrations
{
    [DbContext(typeof(DbContexto))]
    [Migration("20230104020817_MinhaMigracao")]
    partial class MinhaMigracao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WEB.Models.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("carro_id");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int")
                        .HasColumnName("marca_id");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int")
                        .HasColumnName("modelo_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("WEB.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(155)")
                        .HasColumnName("email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("endereco");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(155)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("WEB.Models.Configuracao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("configuracao_id");

                    b.Property<int>("DiaDeLocacao")
                        .HasColumnType("int")
                        .HasColumnName("dia_de_locacao");

                    b.HasKey("Id");

                    b.ToTable("configuracoes");
                });

            modelBuilder.Entity("WEB.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("marca_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("WEB.Models.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("modelo_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("WEB.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pedido_id");

                    b.Property<int>("CarroId")
                        .HasColumnType("int")
                        .HasColumnName("carro_id");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("DATETIME")
                        .HasColumnName("data_entrega");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("DATETIME")
                        .HasColumnName("data_alocacao");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
