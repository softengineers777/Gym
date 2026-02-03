using Microsoft.EntityFrameworkCore;

namespace GuayabitosMvc.Models
{
    public class GuayabitosDbContext : DbContext
    {
        public GuayabitosDbContext(DbContextOptions<GuayabitosDbContext> options)
            : base(options)
        {
        }

        // Constructor sin parámetros (para migraciones)
        public GuayabitosDbContext()
        {
        }

        // Aquí irán tus DbSets (por ahora vacío)
        // public DbSet<Empleado> Empleados { get; set; }
        // public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
    }
}