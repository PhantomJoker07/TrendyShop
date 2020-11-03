using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrendyShop.ViewModels
{
    public class ChangePasswordViewModel
    {
        
        [Display(Name ="Contraseña actual")]
        public string CurrentPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La contraseña debe contener al menos {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NewPassword { get; set; }

        public string UserId { get; set; }
        public bool WrongPassword { get; set; }
    }
}
