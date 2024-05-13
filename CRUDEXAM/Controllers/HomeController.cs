using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDEXAM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CRUDEXAM.Models.ViewModels;


namespace CRUDEXAM.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbexamPupoContext _DBContext;
        //Inyectamos el DbexamPupoContext
        public HomeController(DbexamPupoContext DBContext)
        {
            _DBContext = DBContext;
        }

        public IActionResult Index()
        {
            List<Producto> lista = _DBContext.Productos.Include(c => c.oCategoria).ToList();
            return View(lista);
        }

        public IActionResult Privacy()
        {
            List<Categorium> lista = _DBContext.Categoria.ToList();
            return View(lista);
        }

        //Inyeccion para Producto Detalle
        [HttpGet]
        public IActionResult Producto_Detalle(int idProducto)
        {
            ProductoVM oProductoVM = new ProductoVM()
            {
                oProducto = new Producto() 
            };

            if(idProducto != 0)
            {
                oProductoVM.oProducto = _DBContext.Productos.Find(idProducto);
            }
            return View(oProductoVM);
        }

        [HttpPost]
        public IActionResult Producto_Detalle(ProductoVM oProductoVM)
        {
            if (oProductoVM.oProducto.IdProducto == 0)
            {
                _DBContext.Productos.Add(oProductoVM.oProducto);
            }
            else
            {
                _DBContext.Productos.Update(oProductoVM.oProducto);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        //Inyeccion para Categoria Detalle
        [HttpGet]
        public IActionResult Categorium_Detalle(int idCategoria)
        {
            CategoriaVM oCategoriaVM = new CategoriaVM()
            {
               oCategorium  = new Categorium() 
               
            };

            if(idCategoria != 0)
            {
                oCategoriaVM.oCategorium = _DBContext.Categoria.Find(idCategoria);
            }
            return View(oCategoriaVM);
        }

        [HttpPost]
        public IActionResult Categorium_Detalle(CategoriaVM oCategoriaVM)
        {
            if (oCategoriaVM.oCategorium.IdCategoria == 0)
            {
                _DBContext.Categoria.Add(oCategoriaVM.oCategorium);
            }
            else
            {
                _DBContext.Categoria.Update(oCategoriaVM.oCategorium);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("Privacy", "Home");
        }

        //Inyeccion para Eliminar Producto
        [HttpGet]
        public IActionResult Eliminar(int idProducto)
        {
            Producto oProducto = _DBContext.Productos.Where(e => e.IdProducto == idProducto).FirstOrDefault();
            return View(oProducto);
        }

        [HttpPost]
        public IActionResult Eliminar(Producto oProducto)
        {
            _DBContext.Productos.Remove(oProducto);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        //Inyeccion para Eliminar Categoria
        [HttpPost]
        public IActionResult EliminarCa(int idCategoria)
        {
            Categorium oCategorium = _DBContext.Categoria.Where(e => e.IdCategoria == idCategoria).FirstOrDefault();
            return View(oCategorium);
        }
        [HttpPost]
        public IActionResult EliminarCa(Categorium oCategorium)
        {
            _DBContext.Categoria.Remove(oCategorium);
            _DBContext.SaveChanges();

            return RedirectToAction("Privacy", "Home");   
        }

       

       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
