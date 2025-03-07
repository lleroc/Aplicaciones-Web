using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DesdeBDD.Models;

[Table("pedido")]
public partial class Pedido
{
    [Key]
    [Column("codigo_pedido")]
    public int CodigoPedido { get; set; }

    [Column("fecha_pedido")]
    public DateOnly FechaPedido { get; set; }

    [Column("fecha_esperada")]
    public DateOnly FechaEsperada { get; set; }

    [Column("fecha_entrega")]
    public DateOnly? FechaEntrega { get; set; }

    [Column("estado")]
    [StringLength(15)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [Column("comentarios", TypeName = "text")]
    public string? Comentarios { get; set; }

    [Column("codigo_cliente")]
    public int CodigoCliente { get; set; }

    [ForeignKey("CodigoCliente")]
    [InverseProperty("Pedidos")]
    public virtual Cliente CodigoClienteNavigation { get; set; } = null!;

    [InverseProperty("CodigoPedidoNavigation")]
    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
}
