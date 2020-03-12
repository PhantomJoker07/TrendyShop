using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrendyShop.Models
{
    public class User
    {   
        [Key]
        [Required(ErrorMessage = "Debe especificar su ID")]
        public int UserId { get; set; }
        
        [Display(Name ="Nombre de Usuario")]
        [Required(ErrorMessage = "Debe ingresar su nombre")]
        [StringLength(255)]
        public string Name { get; set; }
        
        //public string LastName { get; set; }

        public string Description { get; set; }
        
        public string Card { get; set; }//Required? Lists of cards?

        [Phone]
        [Display(Name = "Teléfono")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Display(Name ="Correo")]
        public string Email { get; set; }

        public float Rating { get; set; }

        public int TotalSales { get; set; }

    }
}
