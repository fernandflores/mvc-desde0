using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
namespace WebApplication1.Controllers
{

    public class ProductosController:Controller
    {
        private IProductoRepository _repoProducto;
        public ProductosController()
        {
            _repoProducto = new ProductoRepository();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var listaProductos= _repoProducto.ListarProdcutos();
            return View(listaProductos);
        }
        [HttpGet]
        public IActionResult CrearProducto()
        {
            
               return View(); // me lleva a la vista de crearProducto (el formulario)      +
        }
        [HttpPost]
        public IActionResult CrearProducto(Productos producto)
        {
                _repoProducto.CrearProducto(producto);  // actua en el repositorio
                return RedirectToAction("Index"); // redirige a la vista de index
        }
        [HttpGet]
        public IActionResult ModificarProducto(int id)
        {
            var producto = _repoProducto.ObtenerProductoPorId(id);
            return View(producto);
        }
        [HttpPost]
        public IActionResult ModificarProducto(Productos producto)
        {
            _repoProducto.ModificarProducto(producto.IdProducto, producto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EliminarProducto(int id)
        {
            return View(id);
        }
        [HttpGet] //get porque es una etiqueta <a> y espera un get, siempre que sea un link espera un get, en cambio el formulario espera un post por el method="post"
        public IActionResult ConfirmarEliminarProducto(int id)
        {
          
                if (_repoProducto.ObtenerProductoPorId(id) == null) return NotFound();
                _repoProducto.EliminarPorId(id);
                return RedirectToAction("Index");
           
        }
    }

}
