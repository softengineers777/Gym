using System;
using System.ComponentModel.DataAnnotations;
namespace GuayabitosMvc.Models
{
    public class Pedidos_Detalle
    {
        [Key]
        [Display(Name = "Consecutio")]
        public int IdDetallePedido { get; set; }
        [Display(Name = "Pedido")]
        public int IdPedido { get; set; }
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
        [Display(Name = "Precio Unitario")]
        public decimal PrecioUnitario { get; set; }
        [Display(Name = "SubTotal")]
        public decimal SubTotal { get; set; }
         [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }
         [Display(Name = "Estado")]
        public string? Estado { get; set; }






    }
}