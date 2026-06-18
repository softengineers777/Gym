using System.Data;
using System.Threading.Tasks;
using GuayabitosMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuayabitosMvc.Controllers
{
    public class Pedidos_DetalleController: Controller
    {
        private readonly GuayabitosDbContext _context;
        private readonly IConfiguration _configuration;

        public  Pedidos_DetalleController(GuayabitosDbContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            return View (await _context.Pedidos_Detalle.ToListAsync());
        }
        public async Task <IActionResult>Details(int?  id)
        {
            if(id== null || _context.Pedidos_Detalle == null)
            {
                return  NotFound();
            }
            var pedidos_detalle = await _context.Pedidos_Detalle
            .FirstOrDefaultAsync(pd =>pd.IdDetallePedido== id);
            if(pedidos_detalle == null)
            {
                return NotFound();
            }
            return View(pedidos_detalle);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> CreateMultiple(List<Pedidos_Detalle>pedidos_detalle)
        {
            try
            {
                if (pedidos_detalle == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                Console.WriteLine($"Pedido detall no es  null {pedidos_detalle.Count}");
                for (int i = 0; i <pedidos_detalle.Count; i++)
                {
                    var pd= pedidos_detalle[i];
                    // Console.WriteLine()
                }
                var 
            }
        }
    }
}
