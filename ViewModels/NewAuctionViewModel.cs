using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;

namespace TrendyShop.ViewModels
{
    public class NewAuctionViewModel
    {
        public int Id { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public Auction Auction { get; set; }

        [Display(Name ="Imagen")]
        public IFormFile Image { get; set; }
    }
}