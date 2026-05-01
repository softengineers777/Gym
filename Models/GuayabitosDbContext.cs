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
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Productos> Productos { get; set; }

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

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.HasKey(c => c.IdProveedor);
                entity.Property(c => c.Nombre);
                entity.Property(c => c.Apellido);
                entity.Property(c => c.telefono);
                entity.Property(c => c.direccion);
                entity.Property(c => c.FechaRegistro);
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(c => c.IdEmpleado);
                entity.Property(c => c.Codigo);
                entity.Property(c => c.nombre);
                entity.Property(c => c.IdRol);
                entity.Property(c => c.puesto);
                entity.Property(c => c.Usuario_Login);
                entity.Property(c => c.Contraseña_hash);
                entity.Property(c => c.telefono);
                entity.Property(c => c.email);
                entity.Property(c => c.fecha_contratacion);
                entity.Property(c => c.salario);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(p => p.IdProductos);
                entity.Property(p => p.nombre);
                entity.Property(p => p.categoria);
                entity.Property(p => p.precio);
                entity.Property(p => p.fecha_registro);
            }
            );
        }
    }
}