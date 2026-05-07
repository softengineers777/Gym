using System;
using System.ComponentModel.DataAnnotations;

namespace GuayabitosMvc.Models
{
    public class Permisos
    {
        [Key]
        [Display(Name = "Consecutivo")]
        public int IdPermisos { get; set; }
        [Display(Name = "Nombre")]
        public int Nombre { get; set; }
        [Display(Name = "Codigo")]
        public int Codigo { get; set; }
        [Display(Name = "Descripcion")]
        public int Descripcion { get; set; }

    }
}