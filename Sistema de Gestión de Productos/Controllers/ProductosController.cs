using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> ListaProductosIndex()
        {
            var productos = await _context.Productos
                .OrderByDescending(p => p.CreacionFecha).ToListAsync();

            return View(productos);
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




        [HttpGet]
        public async Task<IActionResult> Editar(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(Id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int Id, Producto producto)
        {
            if (Id != producto.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(producto);
            }

            var productoExistente = await _context.Productos.FindAsync(Id);

            if (productoExistente == null)
            {
                return NotFound();
            }

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.Precio = producto.Precio;
            productoExistente.Cantidad = producto.Cantidad;

            await _context.SaveChangesAsync();

            TempData["Mensaje"] = "Producto actualizado correctamente.";

            return RedirectToAction(nameof(ListaProductosIndex));
        }


    }
}