using System;
using System.Collections.Generic;
using DPA.Practica0123200299.CORE.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DPA.Practica0123200299.CORE.Infrastructure.Data;

public partial class UniversidadBdContext : DbContext
{
    public UniversidadBdContext()
    {
    }

    public UniversidadBdContext(DbContextOptions<UniversidadBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrera> Carrera { get; set; }

    public virtual DbSet<Curso> Curso { get; set; }

    public virtual DbSet<DetalleMatricula> DetalleMatricula { get; set; }

    public virtual DbSet<Estudiante> Estudiante { get; set; }

    public virtual DbSet<Matricula> Matricula { get; set; }

    public virtual DbSet<Profesor> Profesor { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KARENJACKELINE\\SQLEXPRESS;Database=UniversidadBD;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.IdCarrera).HasName("PK__Carrera__82525F2697368420");

            entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");
            entity.Property(e => e.DuracionAnios).HasColumnName("duracion_anios");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A")
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.Facultad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("facultad");
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_carrera");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK__Curso__5D3F75029BD0E351");

            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.Ciclo).HasColumnName("ciclo");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");
            entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");
            entity.Property(e => e.NombreCurso)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_curso");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Curso)
                .HasForeignKey(d => d.IdCarrera)
                .HasConstraintName("FK__Curso__id_carrer__52593CB8");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.Curso)
                .HasForeignKey(d => d.IdProfesor)
                .HasConstraintName("FK__Curso__id_profes__534D60F1");
        });

        modelBuilder.Entity<DetalleMatricula>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__Detalle___4F1332DEC71B61A8");

            entity.ToTable("Detalle_Matricula");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A")
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.IdMatricula).HasColumnName("id_matricula");
            entity.Property(e => e.NotaFinal)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("nota_final");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.DetalleMatricula)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("FK__Detalle_M__id_cu__5AEE82B9");

            entity.HasOne(d => d.IdMatriculaNavigation).WithMany(p => p.DetalleMatricula)
                .HasForeignKey(d => d.IdMatricula)
                .HasConstraintName("FK__Detalle_M__id_ma__59FA5E80");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PK__Estudian__E0B2763C09824327");

            entity.HasIndex(e => e.Dni, "UQ__Estudian__D87608A712505704").IsUnique();

            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.CorreoInstitucional)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo_institucional");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dni");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombres");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Estudiante)
                .HasForeignKey(d => d.IdCarrera)
                .HasConstraintName("FK__Estudiant__id_ca__4D94879B");
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.IdMatricula).HasName("PK__Matricul__1D7CF00BE10B3100");

            entity.Property(e => e.IdMatricula).HasColumnName("id_matricula");
            entity.Property(e => e.FechaMatricula).HasColumnName("fecha_matricula");
            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.Periodo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("periodo");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Matricula)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("FK__Matricula__id_es__5629CD9C");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.IdProfesor).HasName("PK__Profesor__159ED6178FBF11BB");

            entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.CorreoInstitucional)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo_institucional");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("especialidad");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombres");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
