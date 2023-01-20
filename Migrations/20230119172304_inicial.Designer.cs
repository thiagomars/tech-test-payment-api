﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tech_test_payment_api.Context;

#nullable disable

namespace techtestpaymentapi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230119172304_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("tech_test_payment_api.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ItensId")
                        .HasColumnType("integer")
                        .HasColumnName("id_itens");

                    b.Property<int>("VendaId")
                        .HasColumnType("integer")
                        .HasColumnName("id_venda");

                    b.HasKey("Id");

                    b.HasIndex("ItensId");

                    b.HasIndex("VendaId");

                    b.ToTable("compra");
                });

            modelBuilder.Entity("tech_test_payment_api.Models.Itens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric")
                        .HasColumnName("preco");

                    b.HasKey("Id");

                    b.ToTable("itens");
                });

            modelBuilder.Entity("tech_test_payment_api.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("data");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int>("VendedorId")
                        .HasColumnType("integer")
                        .HasColumnName("id_vendedor");

                    b.HasKey("Id");

                    b.HasIndex("VendedorId");

                    b.ToTable("venda");
                });

            modelBuilder.Entity("tech_test_payment_api.Models.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Cpf")
                        .HasColumnType("integer")
                        .HasColumnName("cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<int>("Telefone")
                        .HasColumnType("integer")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.ToTable("vendedor");
                });

            modelBuilder.Entity("tech_test_payment_api.Models.Compra", b =>
                {
                    b.HasOne("tech_test_payment_api.Models.Itens", "Itens")
                        .WithMany()
                        .HasForeignKey("ItensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tech_test_payment_api.Models.Venda", "Venda")
                        .WithMany()
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Itens");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("tech_test_payment_api.Models.Venda", b =>
                {
                    b.HasOne("tech_test_payment_api.Models.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendedor");
                });
#pragma warning restore 612, 618
        }
    }
}
