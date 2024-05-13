using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUDEXAM.Models.ViewModels
{
    //Para renderizar el modelo dentro de la vista
    public class ProductoVM
    {

        public Producto oProducto { get; set; }

        public List<SelectListItem> oListaCategoria { get; set; }
    }
}
