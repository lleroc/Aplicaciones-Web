using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DesdeBDD.Models;

[Table("producto")]
public partial class Producto
{
    [Key]
    [Column("codigo_producto")]
    [StringLength(15)]
    [Unicode(false)]
    public string CodigoProducto { get; set; } = null!;

    [Column("nombre")]
    [StringLength(70)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("gama")]
    [StringLength(50)]
    [Unicode(false)]
    public string Gama { get; set; } = null!;

    [Column("dimensiones")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Dimensiones { get; set; }

    [Column("proveedor")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Proveedor { get; set; }

    [Column("descripcion", TypeName = "text")]
    public string? Descripcion { get; set; }

    [Column("cantidad_en_stock")]
    public short CantidadEnStock { get; set; }

    [Column("precio_venta", TypeName = "numeric(15, 2)")]
    public decimal PrecioVenta { get; set; }

    [Column("precio_proveedor", TypeName = "numeric(15, 2)")]
    public decimal? PrecioProveedor { get; set; }

    [InverseProperty("CodigoProductoNavigation")]
    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    [ForeignKey("Gama")]
    [InverseProperty("Productos")]
    public virtual GamaProducto GamaNavigation { get; set; } = null!;
}
