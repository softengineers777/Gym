using System;
using System.ComponentModel.DataAnnotations;

namespace GuayabitosMvc.Models
{
    public class Pedidos_Cabecera
    {
        [Key]
        [Display(Name = "Consecutivo")]
        public int IdPedidos { get; set; }
        [Display(Name = "Mesa")]
        public int IdMesa { get; set; }
        [Display(Name ="Empleado")]
        public int IdEmpleado { get; set; }
        [Display(Name ="Cliente")]
        public int  IdCliente {get; set;}
        [Display(Name = "Fecha pedido")]
        public DateTime FechaPedido {get; set;}
        [Display(Name ="Estado")]
        public string? Estado {get; set;}
        [Display(Name ="Total")]
        public decimal Total {get; set;}
        [Display(Name ="Observaciones")]
        public string? Observaciones {get; set;}
        [Display(Name ="Activo")]
        public bool Activo {get; set;}

    }
}