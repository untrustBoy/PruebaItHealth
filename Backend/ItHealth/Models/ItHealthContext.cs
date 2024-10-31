using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ItHealth.Models;

public partial class ItHealthContext : DbContext
{
    public ItHealthContext()
    {
    }

    public ItHealthContext(DbContextOptions<ItHealthContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=MIKE\\SQLEXPRESS; database=itHealth; Integrated Security=true; trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__estado__FBB0EDC1FFC9FC67");

            entity.ToTable("estado");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__genero__0F8349881EAD4583");

            entity.ToTable("genero");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__paciente__C93DB49B779CF62F");

            entity.ToTable("pacientes");

            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fechaNacimiento");
            entity.Property(e => e.Genero).HasColumnName("genero");
            entity.Property(e => e.NombrePaciente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombrePaciente");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(50)
                .HasColumnName("numeroTelefono");
            entity.Property(e => e.TipoDocumento).HasColumnName("tipoDocumento");

            entity.HasOne(d => d.ActivoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.Activo)
                .HasConstraintName("FK_pacientes_estado");

            entity.HasOne(d => d.GeneroNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.Genero)
                .HasConstraintName("FK_pacientes_genero");

            entity.HasOne(d => d.TipoDocumentoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.TipoDocumento)
                .HasConstraintName("FK_pacientes_TipoDocumento");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__TipoDocu__9E3A29A5C0423C0B");

            entity.ToTable("TipoDocumento");

            entity.Property(e => e.Abravicacion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("abravicacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
