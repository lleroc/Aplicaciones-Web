using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DesdeBDD.Models;

[PrimaryKey("CodigoPedido", "CodigoProducto")]
[Table("detalle_pedido")]
public partial class DetallePedido
{
    [Key]
    [Column("codigo_pedido")]
    public int CodigoPedido { get; set; }

    [Key]
    [Column("codigo_producto")]
    [StringLength(15)]
    [Unicode(false)]
    public string CodigoProducto { get; set; } = null!;

    [Column("cantidad")]
    public int Cantidad { get; set; }

    [Column("precio_unidad", TypeName = "numeric(15, 2)")]
    public decimal PrecioUnidad { get; set; }

    [Column("numero_linea")]
    public short NumeroLinea { get; set; }

    [ForeignKey("CodigoPedido")]
    [InverseProperty("DetallePedidos")]
    public virtual Pedido CodigoPedidoNavigation { get; set; } = null!;

    [ForeignKey("CodigoProducto")]
    [InverseProperty("DetallePedidos")]
    public virtual Producto CodigoProductoNavigation { get; set; } = null!;
}
