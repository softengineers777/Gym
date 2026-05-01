using System;
using System.ComponentModel.DataAnnotations;

namespace GuayabitosMvc.Models
{
    public class Clientes
    {
        [Key]
        [Display(Name = "Clientes")]
        public int IdCliente {get; set;}
        [Display(Name = "Nombre")]
        public string Nombre {get; set;}
        [Display(Name = "Telefono")]
        public string  Telefono {get; set;}
        [Display (Name = "Email")]
        public string email {get; set;}
        [Display(Name = "Fecha Registro")]
        public  DateTime fecha_registro {get;set;}


    }
}