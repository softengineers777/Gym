using System;
using System.ComponentModel.DataAnnotations;

namespace GuayabitosMvc.Models
{
    public class Compras
    {
        [Key]
        [Display(Name = "Consecutivo")]
        public int IdCompras { get; set; }
        [Display(Name = "Proveedor")]
        public int IdProveedor { get; set; }
        [Display(Name = "fechaCompra")]
        public DateTime fecha_compra { get; set; }
        [Display(Name = "Total Compra")]
        public decimal total {get; set;}
        [Display ( Name = "Estado")]
        public string estado {get; set;}
    }
}