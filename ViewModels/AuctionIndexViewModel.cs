using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;

namespace TrendyShop.ViewModels
{
    public class AuctionIndexViewModel
    {
        public IEnumerable<Auction> Auctions { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public bool UserIsAdmin { get; set; }

        [Required]
        [Display(Name = "Nueva Categoría")]
        public string CategoryName { get; set; }
    }
}
