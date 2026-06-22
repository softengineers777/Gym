using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GuayabitosMvc.Models;


namespace GuayabitosMvc.Models
{
    public class Mesas
    {
        [Key]
        [Display(Name = "Consecutivo")]
        public int IdMesa {get; set;}
        [Display(Name = "Numero Mesa")]
        public string NumeroMesa {get; set;}
        [Display(Name = "Capacidad")]
        public int  Capacidad {get; set;}
        [Display(Name = "Estado")]
        public string? Estado {get; set;}
        [Display(Name = "Activo")]
        public bool? Activo {get; set;}


    }



}