using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;

namespace TrendyShop.ViewModels
{
    public class BuyViewModel
    {
        //public int Id { get; set; }

        public Add Add { get; set; }

        public string CustomerId { get; set; }
        
        //[ForeignKey("CustomerId")]
        //public User Customer { get; set; }


        [Range(1,int.MaxValue, ErrorMessage ="Especifique una cantidad válida para su compra")]
        [Display(Name = "Cantidad a ordenar")]
        [Required(ErrorMessage ="Por favor especifique el número de artículos que desea adquirir")]
        public int AmountToBuy { get; set; }

        [Display(Name = "¿Utilizar dirección asociada a tarjeta?")]
        public bool ShippingToCardAddress { get; set; }

        [Display(Name = "Dirección de envio")]
        public string Address { get; set; }

        //En menos de una semana, en el proximo mes, blabla 
        [Display(Name = "Rapidez del envio requerida")]
        public int ShippingMode { get; set; }

        public float ShippingCharge { get; set; }

        ////[MinLength(11), MaxLength(11)]
        //[Range(1,99999999999,ErrorMessage ="Por favor inserte un número de trajeta válido")]
        //[Display(Name = "Número de tarjeta de crédito")]
        //[Required(ErrorMessage ="Es necesario que inserte una  tarjeta para efectuar la compra")]
        //public int Card { get; set; }
    }
}
