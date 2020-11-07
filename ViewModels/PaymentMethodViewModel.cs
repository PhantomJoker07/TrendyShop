using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;

namespace TrendyShop.ViewModels
{
    public class PaymentMethodViewModel
    {
        public string UserId { get; set; }
        public string SellerId { get; set; }
        public int ArticleId { get; set; }
        public long DateTicks { get; set; }
        public double Charge { get; set; }
        public IList<User_Card> Cards { get; set; }
        //public bool ForAuction { get; set; }
        public int OrderType { get; set; }

        [Display(Name = "Número de tarjeta")]
        public string SelectedCardNumber { get; set; }

        [Display(Name = "Número de tarjeta")]
        [StringLength(18, MinimumLength = 13, ErrorMessage = "La tarjeta debe contener de 13 a 18 dígitos.")]
        public string CardNumber { get; set; }

        [Display(Name = "Nombre de la nueva tarjeta")]
        public string NameOnCard { get; set; }
    }
}
