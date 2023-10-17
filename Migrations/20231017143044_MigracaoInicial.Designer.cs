﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using apiUniversidade.Context;

#nullable disable

namespace apiUniversidade.Migrations
{
    [DbContext(typeof(apiUniversidadeContext))]
    [Migration("20231017143044_MigracaoInicial")]
    partial class MigracaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("apiUniversidade.Model.Aluno", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("CPF")
                        .HasColumnType("text");

                    b.Property<int?>("CursoID")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<DateTime>("dataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.HasIndex("CursoID");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("apiUniversidade.Model.Curso", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duracao")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("apiUniversidade.Model.Disciplina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("integer");

                    b.Property<int?>("CursoID")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("Semestre")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("CursoID");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("apiUniversidade.Model.Aluno", b =>
                {
                    b.HasOne("apiUniversidade.Model.Curso", null)
                        .WithMany("Alunos")
                        .HasForeignKey("CursoID");
                });

            modelBuilder.Entity("apiUniversidade.Model.Disciplina", b =>
                {
                    b.HasOne("apiUniversidade.Model.Curso", null)
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoID");
                });

            modelBuilder.Entity("apiUniversidade.Model.Curso", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("Disciplinas");
                });
#pragma warning restore 612, 618
        }
    }
}
