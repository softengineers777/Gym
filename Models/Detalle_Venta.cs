using System;
using System.ComponentModel.DataAnnotations;

namespace GuayabitosMvc.Models
{
    public class Detalle_Venta
    {
        [Key]
        [Display(Name = "Consecutivo")]
        public int IdDetalleV { get; set; }
        [Display(Name = "Venta")]
        public int IdVenta { get; set; }
        [Display(Name = "Producto")]
        public DateTime IdProducto { get; set; }
        [Display(Name = "Cantidad")]
        public decimal Cantidad { get; set; }
        [Display(Name = "Precio Unitario")]
        public string precio_unitario { get; set; }

         [Display(Name = "Sub Total")]
        public string subTotal { get; set; }


    }
}