using System;
using  System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace GuayabitosMvc.Models
{
    public class Login
    {
        [Key]
        [Display(Name = "Consecutivo")]
        public int UserId {get; set;}
        [Display(Name = "nombreUsuario")]
        public string nombreUsuario {get; set;}
        [Display(Name ="Contraseña")]
        public  string contraseña {get; set;}
        
    }
}