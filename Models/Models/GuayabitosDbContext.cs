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
        public DbSet<Compras> Compras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Telefono).HasMaxLength(50);
                entity.Property(e => e.email).HasMaxLength(100);
                entity.Property(e => e.fecha_registro).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Compras>(entity =>
            {
                entity.HasKey(c => c.IdCompras);
                entity.Property(c => c.IdProveedor);
                entity.Property(c => c.fecha_compra).IsRequired();
                entity.Property(c => c.total);
                entity.Property(c => c.estado).IsRequired();
            });
        }
    }
}