using TrendyShop.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TrendyShop.ViewModels
{
    public class AddsViewModel
    {
        public IEnumerable<Add> Adds { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public bool UserIsAdmin{ get; set; }

        [Display(Name = "Nueva Categoría")]
        public string CategoryName { get; set; }
    }
}
