using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using GuayabitosMvc.Models;
using System.Security.Cryptography;
using System.Text;

namespace GuayabitosMvc.Services
{
    public class AuthService
    {
        private readonly GuayabitosDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public AuthService(GuayabitosDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        
        private string GenerarSalt()
        {
            var saltBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
        
        private string GenerarHash(string contrasenia, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var contraseniaConSalt = contrasenia + salt;
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseniaConSalt));
                return Convert.ToBase64String(bytes);
            }
        }
        
        private bool VerificarContrasenia(string contraseniaIngresada, string hashAlmacenado, string salt)
        {
            var hashCalculado = GenerarHash(contraseniaIngresada, salt);
            return hashCalculado == hashAlmacenado;
        }
        
        public async Task<(bool exito, string mensaje, Usuarios usuario)> LoginAsync(string nombreUsuario, string contrasenia)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
            
            if (usuario == null)
            {
                await Task.Delay(1000);
                return (false, "Usuario o contraseña incorrectos", null);
            }
            
            if (usuario.Activo == false || usuario.Activo == null)
                return (false, "Cuenta desactivada", null);
            
            if (usuario.Bloqueado == true)
                return (false, "Cuenta bloqueada", null);
            
            if (usuario.Intentos_Fallidos >= 5)
            {
                usuario.Bloqueado = true;
                await _context.SaveChangesAsync();
                return (false, "Cuenta bloqueada por intentos fallidos", null);
            }
            
            var contraseniaValida = VerificarContrasenia(contrasenia, usuario.Contraseña_Hash, usuario.Contraseña_salt);
            
            if (!contraseniaValida)
            {
                usuario.Intentos_Fallidos++;
                await _context.SaveChangesAsync();
                return (false, "Usuario o contraseña incorrectos", null);
            }
            
            usuario.Intentos_Fallidos = 0;
            usuario.ultimo_Acceso = DateTime.Now;
            await _context.SaveChangesAsync();
            
            _httpContextAccessor.HttpContext.Session.SetInt32("UserId", usuario.IdUsuario);
            _httpContextAccessor.HttpContext.Session.SetString("UserName", usuario.NombreUsuario);
            
            return (true, "Login exitoso", usuario);
        }
        
        public void Logout()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }
        
        public async Task<bool> HayUsuariosAsync()
        {
            return await _context.Usuarios.AnyAsync();
        }
        
        public async Task<Usuarios> GetUsuarioActualAsync()
        {
            var userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");
            if (userId == null) return null;
            return await _context.Usuarios.FindAsync(userId);
        }
    }
}