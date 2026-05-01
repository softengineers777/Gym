using  System;
using System.ComponentModel.DataAnnotations;

namespace GuayabitosMvc.Models
{
    public class Proveedores
    {
        [Key]
        [Display(Name = "Proveedor")]
        public int IdProveedor {get; set;}

        [Display(Name = "Nombre")]
        public string Nombre {get; set;}

        [Display(Name = "Apellido")]
        public string Apellido {get; set;}

        [Display(Name = "Telefono")]
        public  string telefono {get; set;}

        [Display(Name = "Direccion")]
        public string direccion {get; set;}

        [Display(Name = "Fecha Registro")]

        public DateTime FechaRegistro {get; set;}
    }
}