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
        public float Charge { get; set; }
        public IList<User_Card> Cards { get; set; }
        public bool InvalidOperation { get; set; }

        [Display(Name = "Número de tarjeta")]
        public string CardNumber { get; set; }

        [Display(Name = "Nombre de la tarjeta")]
        public string NameOnCard { get; set; }
    }
}
