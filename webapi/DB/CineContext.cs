using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi.DB;

public partial class CineContext : DbContext
{
    public CineContext()
    {
    }

    public CineContext(DbContextOptions<CineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=Cine; Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Venta>(entity =>
        {
            entity.Property(e => e.Asiento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Clasificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodigoPelicula)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
