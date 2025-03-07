using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DesdeBDD.Models;

public partial class JardineriaDbContext : DbContext
{
    public JardineriaDbContext()
    {
    }

    public JardineriaDbContext(DbContextOptions<JardineriaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<GamaProducto> GamaProductos { get; set; }

    public virtual DbSet<Oficina> Oficinas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=jardineria;User Id=sa;Password=123; Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CodigoCliente).HasName("PK__cliente__4D182E8D1C0CAB60");

            entity.Property(e => e.CodigoCliente).ValueGeneratedNever();
            entity.Property(e => e.ApellidoContacto).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CodigoEmpleadoRepVentas).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CodigoPostal).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.LimiteCredito).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.LineaDireccion2).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.NombreContacto).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Pais).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Region).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.CodigoEmpleadoRepVentasNavigation).WithMany(p => p.Clientes).HasConstraintName("FK__cliente__codigo___38996AB5");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => new { e.CodigoPedido, e.CodigoProducto }).HasName("PK__detalle___3AD5D561184AB9E3");

            entity.HasOne(d => d.CodigoPedidoNavigation).WithMany(p => p.DetallePedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_p__codig__440B1D61");

            entity.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.DetallePedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_p__codig__44FF419A");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.CodigoEmpleado).HasName("PK__empleado__CDEF1DDE9A8F1CE2");

            entity.Property(e => e.CodigoEmpleado).ValueGeneratedNever();
            entity.Property(e => e.Apellido2).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CodigoJefe).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Puesto).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.CodigoJefeNavigation).WithMany(p => p.InverseCodigoJefeNavigation).HasConstraintName("FK__empleado__codigo__2C3393D0");

            entity.HasOne(d => d.CodigoOficinaNavigation).WithMany(p => p.Empleados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__empleado__codigo__2B3F6F97");
        });

        modelBuilder.Entity<GamaProducto>(entity =>
        {
            entity.HasKey(e => e.Gama).HasName("PK__gama_pro__4877EEE4F69ED750");
        });

        modelBuilder.Entity<Oficina>(entity =>
        {
            entity.HasKey(e => e.CodigoOficina).HasName("PK__oficina__754CF298685845EF");

            entity.Property(e => e.LineaDireccion2).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Region).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => new { e.CodigoCliente, e.IdTransaccion }).HasName("PK__pago__CCF58284BF1D1C2C");

            entity.HasOne(d => d.CodigoClienteNavigation).WithMany(p => p.Pagos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pago__codigo_cli__47DBAE45");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.CodigoPedido).HasName("PK__pedido__BBD0C51B1D8FBF8F");

            entity.Property(e => e.CodigoPedido).ValueGeneratedNever();
            entity.Property(e => e.FechaEntrega).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.CodigoClienteNavigation).WithMany(p => p.Pedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pedido__codigo_c__3C69FB99");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoProducto).HasName("PK__producto__105107A95F65D35D");

            entity.Property(e => e.PrecioProveedor).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Proveedor).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.GamaNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__producto__gama__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
