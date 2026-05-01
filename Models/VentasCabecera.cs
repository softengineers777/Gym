using System;
using System.ComponentModel.DataAnnotations;

namespace GuayabitosMvc.Models
{
    public class VentasCabecera
    {
        [Key]
        [Display (Name = "Consecutivo")]
        public int IdVenta {get; set;}
        [Display (Name = "CodigoVenta")]
        public string Codigo_Venta {get; set;}
        [Display (Name = "Empleado")]
        public int IdEmpleado {get; set;}
        

    }
}