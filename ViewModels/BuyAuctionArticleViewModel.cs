using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;

namespace TrendyShop.ViewModels
{
    public class BuyAuctionArticleViewModel
    {
        public Auction Auction { get; set; }

        public string CustomerId { get; set; }
        
        [Display(Name = "¿Utilizar dirección asociada a tarjeta?")]
        public bool ShippingToCardAddress { get; set; }

        [Display(Name = "Dirección de envio")]
        public string Address { get; set; }

        [Display(Name = "Rapidez del envio requerida")]
        [Required(ErrorMessage = "Especifique una dirección para el envío")]
        public int ShippingMode { get; set; }

        public float ShippingCharge { get; set; }
    }
}
