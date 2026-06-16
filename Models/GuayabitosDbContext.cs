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
        public DbSet<Detalle_Venta> Detalle_Venta { get; set; }
        public DbSet<Cabecera_Ventas> Cabecera_Ventas { get; set; }
        public DbSet<MovimientoInventario> MovimientoInventario { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Rol> Rol {get; set;}
        public DbSet<Rol_Permiso> Rol_Permiso {get; set;}


    



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
            });
            modelBuilder.Entity<Detalle_Venta>(entity =>
            {
                entity.HasKey(d => d.IdDetalleV);
                entity.HasKey(d => d.IdVenta);
                entity.HasKey(d => d.IdProducto);
                entity.HasKey(d => d.Cantidad);
                entity.HasKey(d => d.precio_unitario);
                entity.HasKey(d => d.subTotal);
            });
            modelBuilder.Entity<Cabecera_Ventas>(entity =>
            {
                entity.HasKey(c => c.IdVenta);
                entity.Property(c => c.Codigo_Venta);
                entity.Property(c => c.IdEmpleado);
                entity.Property(c => c.IdCliente);
                entity.Property(c => c.Fecha_Venta);
                entity.Property(c => c.SubTotal);
                entity.Property(c => c.Impuesto);
                entity.Property(c => c.forma_pago);
                entity.Property(c => c.estado);
            });
            modelBuilder.Entity<MovimientoInventario>(entity =>
            {
                entity.HasKey(m => m.IdInventarios);
                entity.Property(m => m.IdProducto);
                entity.Property(m => m.tipo_Movimiento);
                entity.Property(m => m.cantidad);
                entity.Property(m => m.precio_unitario);
                entity.Property(m => m.total);
                entity.Property(m => m.motivo);
                entity.Property(m => m.fechas_Movimiento);
                entity.Property(m => m.IdEmpleado);
                entity.Property(m => m.referencia);
            });
            modelBuilder.Entity<Usuarios>(entity =>
            {
               entity.HasKey(u=> u.IdUsuario);
               entity.Property(u => u.IdEmpleado); 
               entity.Property(u => u.NombreUsuario); 
               entity.Property(u => u.Contraseña_Hash); 
               entity.Property(u => u.Contraseña_salt); 
               entity.Property(u => u.Fecha_Creacion); 
               entity.Property(u => u.ultimo_Acceso); 
               entity.Property(u => u.Intentos_Fallidos); 
               entity.Property(u => u.Bloqueado); 
               entity.Property(u => u.debe_cambiar_contraseña); 
               entity.Property(u => u.expriracion_contraseña); 
               entity.Property(u => u.Activo); 
            });
            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.HasKey(p=>p.IdPermisos);
                entity.Property(p=>p.Nombre);
                entity.Property(p=>p.Codigo);
                entity.Property(p=>p.Descripcion);                
            });
            modelBuilder.Entity<Rol>(entity =>
            {
               entity.HasKey(r => r.IdRol);
               entity.Property(r => r.Nombre); 
               entity.Property(r => r.Descripcion); 
               entity.Property(r => r.Nivel_Acceso); 
            });
            modelBuilder.Entity <Rol_Permiso>(entity =>
            {
                entity.HasKey(rp => rp.IdRol_Permiso);
                entity.Property(rp => rp.IdRol);
                entity.Property(rp => rp.IdPermisos);
            });

        }
    }
}