using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DesdeBDD.Models;

[Table("oficina")]
public partial class Oficina
{
    [Key]
    [Column("codigo_oficina")]
    [StringLength(10)]
    [Unicode(false)]
    public string CodigoOficina { get; set; } = null!;

    [Column("ciudad")]
    [StringLength(30)]
    [Unicode(false)]
    public string Ciudad { get; set; } = null!;

    [Column("pais")]
    [StringLength(50)]
    [Unicode(false)]
    public string Pais { get; set; } = null!;

    [Column("region")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Region { get; set; }

    [Column("codigo_postal")]
    [StringLength(10)]
    [Unicode(false)]
    public string CodigoPostal { get; set; } = null!;

    [Column("telefono")]
    [StringLength(20)]
    [Unicode(false)]
    public string Telefono { get; set; } = null!;

    [Column("linea_direccion1")]
    [StringLength(50)]
    [Unicode(false)]
    public string LineaDireccion1 { get; set; } = null!;

    [Column("linea_direccion2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LineaDireccion2 { get; set; }

    [InverseProperty("CodigoOficinaNavigation")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
