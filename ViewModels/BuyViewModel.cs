using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;

namespace TrendyShop.ViewModels
{
    public class BuyViewModel
    {
        public int Id { get; set; }

        public Add Add { get; set; }

        [Range(1,int.MaxValue, ErrorMessage ="No es posible realizar una compra tan grande")]
        [Display(Name = "Número de artículos a comprar")]
        [Required(ErrorMessage ="Por favor especifique el número de artículos que desea adquirir")]
        public int AmountToBuy { get; set; }

        //[MinLength(11), MaxLength(11)]
        [Range(1,99999999999,ErrorMessage ="Por favor inserte un número de trajeta válido")]
        [Display(Name = "Número de tarjeta de crédito")]
        [Required(ErrorMessage ="Es necesario que inserte una  tarjeta para efectuar la compra")]
        public int Card { get; set; }
    }
}
