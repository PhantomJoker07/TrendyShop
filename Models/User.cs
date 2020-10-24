using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TrendyShop.Models
{
    public class User : IdentityUser
    {   
        //[Key]
        //[Required(ErrorMessage = "Debe especificar su ID")]
        //public string UserId { get; set; }
        
        //[Display(Name ="Nombre de Usuario")]
        //[Required(ErrorMessage = "Debe ingresar su nombre")]
        //[StringLength(255)]
        //public string Name { get; set; }
        public string Alias { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        //primary key is userName knowns as name

        public string Description { get; set; }
        
        public string Card { get; set; } //Required? Lists of cards?

       // public string FirstName { get; set; }  
       // public string LastName { get; set; }

        [Phone]
        [Display(Name = "Teléfono")]
        override public string PhoneNumber { get; set; }

        [EmailAddress]
        [Display(Name ="Correo")]
        override public string Email { get; set; }

        public float Rating { get; set; }

        public int TotalSales { get; set; }

        public string ProfilePicture { get; set; }

    }
}
