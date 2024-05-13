using System;
using System.Collections.Generic;

namespace CRUDEXAM.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string? NombreCat { get; set; }

    public string? DescripcionCat { get; set; }

    public DateTime? FechaCreacionCat { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
