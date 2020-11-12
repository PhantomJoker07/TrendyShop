using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrendyShop.ViewModels
{
    public class EditAccountViewModel
    {
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Phone]
        [Display(Name = "Teléfono")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Detalles")]
        public string Details { get; set; }

        [Display(Name = "Contraseña actual")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "Nueva contraseña")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("NewPassword",
                ErrorMessage = "La contraseña y la confirmación no coinciden.")]
        public string Confirmation { get; set; }

        [Display(Name = "Cambiar foto de perfil")]
        public IFormFile Image { get; set; }

        public string CurrentProfilePicture { get; set; }
    }
}
