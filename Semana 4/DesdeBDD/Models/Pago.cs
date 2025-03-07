using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DesdeBDD.Models;

[PrimaryKey("CodigoCliente", "IdTransaccion")]
[Table("pago")]
public partial class Pago
{
    [Key]
    [Column("codigo_cliente")]
    public int CodigoCliente { get; set; }

    [Column("forma_pago")]
    [StringLength(40)]
    [Unicode(false)]
    public string FormaPago { get; set; } = null!;

    [Key]
    [Column("id_transaccion")]
    [StringLength(50)]
    [Unicode(false)]
    public string IdTransaccion { get; set; } = null!;

    [Column("fecha_pago")]
    public DateOnly FechaPago { get; set; }

    [Column("total", TypeName = "numeric(15, 2)")]
    public decimal Total { get; set; }

    [ForeignKey("CodigoCliente")]
    [InverseProperty("Pagos")]
    public virtual Cliente CodigoClienteNavigation { get; set; } = null!;
}
