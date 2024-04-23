﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("API.Models.Consulta", b =>
                {
                    b.Property<int?>("ConsultaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ConsultaCriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConsultaData")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConsultaNotas")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ConsultaId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("API.Models.Paciente", b =>
                {
                    b.Property<int?>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PacienteCpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("PacienteData")
                        .HasColumnType("TEXT");

                    b.Property<string>("PacienteGenero")
                        .HasColumnType("TEXT");

                    b.Property<string>("PacienteNome")
                        .HasColumnType("TEXT");

                    b.Property<string>("PacienteNotas")
                        .HasColumnType("TEXT");

                    b.Property<string>("PacienteTelefone")
                        .HasColumnType("TEXT");

                    b.HasKey("PacienteId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("API.Models.Consulta", b =>
                {
                    b.HasOne("API.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId");

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
