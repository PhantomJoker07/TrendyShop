using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;

namespace TrendyShop.ViewModels
{
    public class NewAddViewModel
    {
        public int Id { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public Add Add { get; set; }

        [Display(Name ="Imagen")]
        public IFormFile Image { get; set; }
    }
}
