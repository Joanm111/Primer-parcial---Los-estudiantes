using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Primer_parcial___Los_estudiantes.Models
{
    public partial class PrimerParcialContext : DbContext
    {
        public PrimerParcialContext()
        {
        }

        public PrimerParcialContext(DbContextOptions<PrimerParcialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudiantes> Estudiantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-448GVJA;Database=PrimerParcial;User Id=joan;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.Property(e => e.Ano).HasColumnName("ano");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Asignatura)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.CodAsignatura)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Periodo)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Pp1).HasColumnName("PP1");

                entity.Property(e => e.Pp2).HasColumnName("PP2");

                entity.Property(e => e.Pp3).HasColumnName("PP3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
