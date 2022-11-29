using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MiBilleteraWebApi;
using MiBilleteraWebApi.Models;

namespace Entities
{
    public partial class Pil2022Context : DbContext
    {
        public Pil2022Context()
        {
        }

        public Pil2022Context(DbContextOptions<Pil2022Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Billetera> Billeteras { get; set; } = null!;
        public virtual DbSet<Moneda> Monedas { get; set; } = null!;
        public virtual DbSet<Operacion> Operacions { get; set; } = null!;
        public virtual DbSet<TipoOperacion> TipoOperacions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GCSTTLU\\SQLEXPRESS; Database=Pil2022; User=sa; Password=12345678; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Billetera>(entity =>
            {
                entity.HasKey(e => e.IdBilletera);

                entity.ToTable("Billetera");

                entity.Property(e => e.IdBilletera).HasColumnName("ID_Billetera");

                entity.Property(e => e.IdMoneda).HasColumnName("ID_Moneda");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.Saldo).HasColumnType("money");

                entity.HasOne(d => d.IdMonedaNavigation)
                    .WithMany(p => p.Billeteras)
                    .HasForeignKey(d => d.IdMoneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Billetera_Monedas");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Billeteras)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Billetera_Usuario");
            });

            modelBuilder.Entity<Moneda>(entity =>
            {
                entity.HasKey(e => e.IdMoneda);

                entity.Property(e => e.IdMoneda).HasColumnName("ID_Moneda");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Operacion>(entity =>
            {
                entity.HasKey(e => e.IdOperacion);

                entity.ToTable("Operacion");

                entity.Property(e => e.IdOperacion).HasColumnName("ID_Operacion");

                entity.Property(e => e.FechaOperacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaOperacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdBilletera).HasColumnName("ID_Billetera");

                entity.Property(e => e.IdMoneda).HasColumnName("ID_Moneda");

                entity.Property(e => e.IdTipoOperacion).HasColumnName("ID_TipoOperacion");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.Monto)
                    .HasColumnType("money")
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdBilleteraNavigation)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.IdBilletera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacion_Billetera");

                entity.HasOne(d => d.IdMonedaNavigation)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.IdMoneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacion_Monedas");

                entity.HasOne(d => d.IdTipoOperacionNavigation)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.IdTipoOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacion_TipoOperacion");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacion_Usuario");
            });

            modelBuilder.Entity<TipoOperacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoOperacion);

                entity.ToTable("TipoOperacion");

                entity.Property(e => e.IdTipoOperacion).HasColumnName("ID_TipoOperacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NombreOperacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Operacion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Dni)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dni");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaAlta")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FehcaBaja)
                    .HasColumnType("datetime")
                    .HasColumnName("fehcaBaja");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pasword)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("pasword");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
