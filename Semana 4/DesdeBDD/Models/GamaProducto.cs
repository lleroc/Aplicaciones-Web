using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DesdeBDD.Models;

[Table("gama_producto")]
public partial class GamaProducto
{
    [Key]
    [Column("gama")]
    [StringLength(50)]
    [Unicode(false)]
    public string Gama { get; set; } = null!;

    [Column("descripcion_texto", TypeName = "text")]
    public string? DescripcionTexto { get; set; }

    [Column("descripcion_html", TypeName = "text")]
    public string? DescripcionHtml { get; set; }

    [Column("imagen")]
    [StringLength(256)]
    [Unicode(false)]
    public string? Imagen { get; set; }

    [InverseProperty("GamaNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
