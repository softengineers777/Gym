using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GuayabitosMvc.Models
{
    public class Usuarios
    {
        [Key]
        [Display(Name ="Consecutivo")]
        public int IdUsuario {get; set;}
        [Display(Name ="Empleado")]
        public int? IdEmpleado {get; set;}
        [Display(Name ="Nombre Usuario")]
        [Required(ErrorMessage ="El nombre del usuario es  obligatorio")]
        public string NombreUsuario {get; set;}
         [Display(Name ="Contraseña_hash")]
         [Required]
        public string Contraseña_Hash {get; set;}
         [Display(Name ="Contraseña_salt")]
        public string Contraseña_salt {get; set;}
         [Display(Name ="Fecha Creacion")]
        public DateTime Fecha_Creacion {get; set;}
        [Display(Name ="ultimo Acceso")]
        public DateTime? ultimo_Acceso {get; set;}
        [Display(Name ="Intentos Fallidos")]
        public int Intentos_Fallidos {get; set;}
        [Display(Name ="Bloqueado")]
        public bool Bloqueado {get; set;}
        [Display(Name ="Cambiar contraseña")]
        public bool debe_cambiar_contraseña {get; set;}
        [Display(Name ="Expriracion contraseña")]
        public DateTime? expriracion_contraseña {get; set;}
         [Display(Name = "Activo")]
        public bool? Activo { get; set; } = true; 
        
    }
}