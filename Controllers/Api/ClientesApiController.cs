using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuayabitosMvc.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace GuayabitosMvc.Controllers.Api
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ClientesApiController : ControllerBase
    {
        private readonly GuayabitosDbContext _context;

        public ClientesApiController(GuayabitosDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            try
            {
                var clientes = await _context.Clientes.ToListAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error Interno: {ex.Message}");
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetCliente(int id)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return NotFound($"No exiate cliente con ID: {id}");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Clientes>> PostCliente(Clientes cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (cliente.fecha_registro == default)
                {
                    cliente.fecha_registro = DateTime.Now;
                }
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCliente), new { id = cliente.IdCliente }, cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Clientes cliente)
        {
            try
            {
                if (id != cliente.IdCliente)
                {
                    return BadRequest($"El ID {id} no coincide con el Cliente");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.Entry(cliente).State = EntityState.Modified;
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound($"No existe cliente con ID {id}");
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar  el ID {id} por {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteCliente(int id)
        {
            try
            {
                var  cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return NotFound($"No existe el ID {id}");
                }
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode (500,$"Error al eliminar: {ex.Message}");                
            }            
        }

        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<Clientes>>> BuscarClientes([FromQuery] string nombre)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    return await _context.Clientes.ToListAsync();
                }
                 var clientes = await _context.Clientes
                .Where(c => c.Nombre.Contains(nombre))
                .ToListAsync();

                return Ok(clientes);                
            }
            catch (Exception ex)
            {
                return StatusCode (500, $"Error al Buscar: {ex.Message}");
            }           
        }

        private bool ClienteExists (int id)
        {
            return _context.Clientes.Any (e =>e.IdCliente == id);
        }


    }

}
