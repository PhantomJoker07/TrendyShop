using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;

namespace TrendyShop.ViewModels
{
    public class AddToSCViewModel
    {
        public int Id { get; set; }

        public Add Add { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "No es posible realizar una compra tan grande")]
        [Display(Name = "Número de artículos a agregar a su carrito de compra")]
        [Required(ErrorMessage = "Por favor especifique el número de artículos que desea adquirir")]
        public int AmountToAdd { get; set; }


    }
}
