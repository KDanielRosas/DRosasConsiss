using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class DrosasConsissContext : DbContext
{
    public DrosasConsissContext()
    {
    }

    public DrosasConsissContext(DbContextOptions<DrosasConsissContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= DRosasConsiss; User ID=sa; TrustServerCertificate=True; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.IdDetalleFactura).HasName("PK__Detalle___DB5F46317AC04413");

            entity.ToTable("Detalle_Facturas");

            entity.HasOne(d => d.FolioFacturaNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.FolioFactura)
                .HasConstraintName("FK__Detalle_F__Folio__182C9B23");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Detalle_F__IdPro__1920BF5C");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FolioFactura).HasName("PK__Facturas__26BDA59EAC564163");

            entity.Property(e => e.Fecha).HasColumnType("date");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__Facturas__IdProv__15502E78");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Personas__A4788141A99C5E91");

            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Habilidades)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("habilidades");
            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210F4C406D5");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(15, 2)");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__E8B631AF655A06AB");

            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
