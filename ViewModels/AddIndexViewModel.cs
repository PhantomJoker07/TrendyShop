using TrendyShop.Models;
using System.Collections.Generic;

namespace TrendyShop.ViewModels
{
    public class AddIndexViewModel
    {
        public IEnumerable<Add> Adds { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
