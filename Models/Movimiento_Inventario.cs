using System;
using System.ComponentModel.DataAnnotations;

namespace GuayabitosMvc.Models
{
    public class MovimientoInventario
    {
        [Key]
        [Display(Name = "Consecutivo")]
        public int IdInventarios { get; set; }
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }
        [Display(Name = "Tipo Movimiento")]
        public string tipo_Movimiento { get; set; }

        [Display(Name = "cantidad")]
        public int cantidad { get; set; }
        [Display(Name = "Precio Unitario")]
        public decimal precio_unitario { get; set; }
        [Display(Name = "Total")]
        public decimal total { get; set; }
        [Display(Name = "Motivo")]
        public decimal motivo { get; set; }
        [Display(Name = "Fechas Movimiento")]
        public decimal fechas_Movimiento { get; set; }
        [Display(Name = "Empleado")]
        public decimal IdEmpleado { get; set; }
        [Display(Name = "Referencia")]
        public decimal referencia { get; set; }


    }
}