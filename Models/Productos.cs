using  System;
using System.ComponentModel.DataAnnotations;

namespace GuayabitosMvc.Models
{
    public class Productos
    {
        [Key]
        [Display(Name = "Consecutivo")]
         public int IdProductos {get; set;}
         [Display(Name = "Nombre")]
         public string nombre {get; set;}
         [Display (Name = "Categoria")]
         public  string categoria {get; set;}
         [Display (Name = "Precio")]
            public decimal precio {get; set;}
        [Display(Name = "Stock")]
        public int stock {get; set;}
        [Display(Name ="Fecha registro")]
        public DateTime fecha_registro {get; set;}
    }
}