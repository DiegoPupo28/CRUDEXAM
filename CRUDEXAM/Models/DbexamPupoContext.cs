using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDEXAM.Models;

public partial class DbexamPupoContext : DbContext
{
    public DbexamPupoContext()
    {
    }

    public DbexamPupoContext(DbContextOptions<DbexamPupoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }
    //Eliminamos la conexion que estaba aqui por que lo hicimos en el secret
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__CATEGORI__A3C02A107B9AFB40");

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.DescripcionCat)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacionCat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCat)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__PRODUCTO__09889210626D1EAD");

            entity.ToTable("PRODUCTO");

            entity.Property(e => e.DescripcionProd)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacionProd)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreProd)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.oCategoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_Categoria");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
