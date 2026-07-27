using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestión_de_Productos.Data;
using Sistema_de_Gestión_de_Productos.Models;


namespace SistemaGestiondeProductos_JeremyRubio.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View(producto);
            }

            producto.CreacionFecha = DateTime.Now;

            _context.Productos.Add(producto);
            _context.SaveChanges();

            TempData["Mensaje"] = "Producto creado correctamente.";

            return RedirectToAction(nameof(Create));
        }
    }
}