using System;
using System.ComponentModel.DataAnnotations;

namespace GuayabitosMvc.Models
{
    public class Cabecera_Ventas
    {
        [Key]
        [Display(Name = "Consecutivo")]
        public int IdVenta { get; set; }
        [Display(Name = "Codigo Venta")]
        public int Codigo_Venta { get; set; }
        [Display(Name = "Empleado")]
        public int IdEmpleado { get; set; }

        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }
        [Display(Name = "Fecha Venta")]
        public int Fecha_Venta { get; set; }
        [Display(Name = "SubTotal")]
        public int SubTotal { get; set; }
        [Display(Name = "Impuesto")]
        public int Impuesto { get; set; }
        [Display(Name = "Total")]
        public int Total { get; set; }
        [Display(Name = "forma pago")]
        public int forma_pago { get; set; }
        [Display(Name = "forma pago")]
        public int estado { get; set; }
    }
}