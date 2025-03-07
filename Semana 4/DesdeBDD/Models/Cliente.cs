using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DesdeBDD.Models;

[Table("cliente")]
public partial class Cliente
{
    [Key]
    [Column("codigo_cliente")]
    public int CodigoCliente { get; set; }

    [Column("nombre_cliente")]
    [StringLength(50)]
    [Unicode(false)]
    public string NombreCliente { get; set; } = null!;

    [Column("nombre_contacto")]
    [StringLength(30)]
    [Unicode(false)]
    public string? NombreContacto { get; set; }

    [Column("apellido_contacto")]
    [StringLength(30)]
    [Unicode(false)]
    public string? ApellidoContacto { get; set; }

    [Column("telefono")]
    [StringLength(15)]
    [Unicode(false)]
    public string Telefono { get; set; } = null!;

    [Column("fax")]
    [StringLength(15)]
    [Unicode(false)]
    public string Fax { get; set; } = null!;

    [Column("linea_direccion1")]
    [StringLength(50)]
    [Unicode(false)]
    public string LineaDireccion1 { get; set; } = null!;

    [Column("linea_direccion2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LineaDireccion2 { get; set; }

    [Column("ciudad")]
    [StringLength(50)]
    [Unicode(false)]
    public string Ciudad { get; set; } = null!;

    [Column("region")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Region { get; set; }

    [Column("pais")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Pais { get; set; }

    [Column("codigo_postal")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CodigoPostal { get; set; }

    [Column("codigo_empleado_rep_ventas")]
    public int? CodigoEmpleadoRepVentas { get; set; }

    [Column("limite_credito", TypeName = "numeric(15, 2)")]
    public decimal? LimiteCredito { get; set; }

    [ForeignKey("CodigoEmpleadoRepVentas")]
    [InverseProperty("Clientes")]
    public virtual Empleado? CodigoEmpleadoRepVentasNavigation { get; set; }

    [InverseProperty("CodigoClienteNavigation")]
    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    [InverseProperty("CodigoClienteNavigation")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
