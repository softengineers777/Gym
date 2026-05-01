using System.Data;
using GuayabitosMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuayabitosMvc.Controllers
{
    public class ProductosController : Controller
    {
        public readonly GuayabitosDbContext _context;
        public readonly IConfiguration _configuration;

        public ProductosController(GuayabitosDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task <IActionResult> Index()
        {
            return View(await _context.Productos.ToListAsync());
        }

        public async Task <IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }
            var productos = await _context.Productos
            .FirstOrDefaultAsync(p => p.IdProductos == id);
            if(productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }
        [HttpGet]
        public IActionResult Create ()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMultiple(List<Productos> productos)
        {
            try
            {
                if(productos == null)
                {
                    Console.WriteLine($"los datos han sido cargados ");
                    return RedirectToAction(nameof(Index));
                }
                var productosValidos = productos.Where(p => !string.IsNullOrEmpty(p.nombre)).ToList();
                if (productosValidos.Any())
                {
                    foreach(var producto in productosValidos)
                    {
                        if(producto.fecha_registro == default)
                        {
                            producto.fecha_registro = DateTime.Now;
                        }
                        _context.Productos.Add(producto);
                    }
                    await _context.SaveChangesAsync();
                }
                else
                {
                    TempData["Error"] = "Los Datos no estan cargados";
                }
            }
            catch( Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine($"detalle: {ex.StackTrace}");
                TempData["Error"] = $"Error =  {ex.Message}";
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound ();
            }
            var producto = await _context.Productos.FindAsync(id);
            if(producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int id, [Bind("IdProductos, nombre,categoria,precio,fecha_registro")]Productos productos)
        {
            if( id != productos.IdProductos)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(productos);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(productos.IdProductos))
                    {
                        return NotFound();
                    }
                }

              
            }
            return RedirectToAction(nameof(Index));
        }
        public bool ProductoExists (int id)
        {
            return _context.Productos.Any(p =>p.IdProductos == id);
        }

        [HttpGet]
        public  async Task<IActionResult> Deleted (int? id)
        {
             if( id == null)
            {
                 return NotFound();
            }
            var  producto = await  _context.Productos
            .FirstOrDefaultAsync (p => p.IdProductos == id);
            if  (producto == null)
            {
                return NotFound();
            }
            return View (producto);

        } 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult>DeletedConfirmed(int id)
        {
            var  productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            _context.Productos.Remove(productos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        

    }

}