using System.Data;
using System.Threading.Tasks;
using GuayabitosMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuayabitosMvc.Controllers
{
    public class ClientesController : Controller
    {
        private readonly GuayabitosDbContext _context;
        private readonly IConfiguration _configuration;

        public ClientesController(GuayabitosDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMultiple(List<Clientes> clientes)
        {
            try
            {
                if (clientes == null)
                {
                    Console.WriteLine("Si llego el contenido  clientes");
                    TempData["Error"] = "No se recibieron  datos del  formulario";
                    return RedirectToAction(nameof(Index));
                }
                Console.WriteLine($"Clientes no es  null. cantidad: {clientes.Count}");
                for (int i = 0; i < clientes.Count; i++)
                {
                    var c = clientes[i];
                    Console.WriteLine($"Cliente {i}: Nombre = '{c?.Nombre}',telefono= '{c?.Telefono}', email = '{c?.email}',");
                }

                var clientesValidos = clientes.Where(c => !String.IsNullOrEmpty(c.Nombre)).ToList();

                if (clientesValidos.Any())
                {
                    foreach (var cliente in clientesValidos)
                    {
                        if (cliente.fecha_registro == default)
                        {
                            cliente.fecha_registro = DateTime.Now;
                        }
                        _context.Clientes.Add(cliente);
                    }
                    await _context.SaveChangesAsync();
                }
                else
                {
                    TempData["Error"] = "Nose recibieron clientes validos para  guardar";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                Console.WriteLine($"detalle:{ex.StackTrace}");
                TempData["Error"] = $"Error: {ex.Message}";
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,Nombre,Telefono,email,fecha_registro")] Clientes clientes)
        {
            if (id != clientes.IdCliente)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.IdCliente))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clientes);
        }
        public bool ClientesExists(int id)
        {
            return _context.Clientes.Any(m => m.IdCliente == id);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clientes = await _context.Clientes
            .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ImportarExcel(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                TempData["Error"] = "Debe seleccionar un archivo";
                return RedirectToAction(nameof(Index));
            }

            var clientes = new List<Clientes>();

            using (var reader = new StreamReader(archivo.OpenReadStream()))
            {
                // Leer CSV o Excel
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    var values = line.Split(',');

                    var cliente = new Clientes
                    {
                        Nombre = values[0],
                        Telefono = values[1],
                        email = values[2],
                        fecha_registro = DateTime.Now
                    };
                    clientes.Add(cliente);
                }
            }

            _context.Clientes.AddRange(clientes);
            await _context.SaveChangesAsync();

            TempData["Success"] = $"{clientes.Count} clientes importados";
            return RedirectToAction(nameof(Index));
        }
    }
}