using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DesdeBDD.Models;

[Table("empleado")]
public partial class Empleado
{
    [Key]
    [Column("codigo_empleado")]
    public int CodigoEmpleado { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("apellido1")]
    [StringLength(50)]
    [Unicode(false)]
    public string Apellido1 { get; set; } = null!;

    [Column("apellido2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Apellido2 { get; set; }

    [Column("extension")]
    [StringLength(10)]
    [Unicode(false)]
    public string Extension { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("codigo_oficina")]
    [StringLength(10)]
    [Unicode(false)]
    public string CodigoOficina { get; set; } = null!;

    [Column("codigo_jefe")]
    public int? CodigoJefe { get; set; }

    [Column("puesto")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Puesto { get; set; }

    [InverseProperty("CodigoEmpleadoRepVentasNavigation")]
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    [ForeignKey("CodigoJefe")]
    [InverseProperty("InverseCodigoJefeNavigation")]
    public virtual Empleado? CodigoJefeNavigation { get; set; }

    [ForeignKey("CodigoOficina")]
    [InverseProperty("Empleados")]
    public virtual Oficina CodigoOficinaNavigation { get; set; } = null!;

    [InverseProperty("CodigoJefeNavigation")]
    public virtual ICollection<Empleado> InverseCodigoJefeNavigation { get; set; } = new List<Empleado>();
}
