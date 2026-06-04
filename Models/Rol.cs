using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuayabitosMvc.Models
{
    public class Rol
    {
        [Key]
        [Display(Name ="Consecutivo")]
        public int IdRol {get; set;}
        [Display(Name ="Nombre")]
        public string Nombre {get; set;}
        [Display(Name ="Descripcion")]
        public string Descripcion {get; set;}
        [Display(Name ="Nivel_Acceso")]
        public int Nivel_Acceso {get; set;}

    }
}