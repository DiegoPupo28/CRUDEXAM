using System;
using System.Collections.Generic;

namespace CRUDEXAM.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? NombreProd { get; set; }

    public string? DescripcionProd { get; set; }

    public int? Stock { get; set; }

    public int? Precio { get; set; }

    public DateTime? FechaCreacionProd { get; set; }

    public int? IdCategoria { get; set; }

    public virtual Categorium? oCategoria { get; set; }

    //Cambie el nombre a oCategoria por que se me facilita mas verlo. Donde debo modificar en el contexto tambien el nombre 
}
