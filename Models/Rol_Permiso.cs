using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace GuayabitosMvc.Models
{
    public class Rol_Permiso
    {
        [Key]
        [Display(Name = "Consecutivo")]
         public int  IdRol_Permiso   {get; set;}
         [Display(Name = "Rol")]
         public int  IdRol   {get; set;}
         [Display(Name = "Permisos")]
         public int  IdPermisos   {get; set;}
    }
}