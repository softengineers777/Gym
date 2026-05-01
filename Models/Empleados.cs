using System;
using System.ComponentModel.DataAnnotations;

namespace GuayabitosMvc.Models
{
    public class Empleados
    {
        [Key]
        [Display(Name = "Empleado")]
        public int IdEmpleado { get; set; }

        [Display(Name = "Codigo")]
        public string Codigo { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Rol")]
        public int IdRol { get; set; }
        [Display(Name = "puesto")]
        public string puesto { get; set; }
        [Display(Name = "Usuario")]
        public string Usuario_Login { get; set; }
        [Display(Name = "Contraseña")]
        public string Contraseña_hash { get; set; }
        [Display(Name ="telefono")]
        public string telefono { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Fecha Contratacion")]
        public DateTime fecha_contratacion { get; set; }
        [Display(Name = "Salario")]
        public decimal salario { get; set; }

    }
}