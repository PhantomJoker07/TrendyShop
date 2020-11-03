using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrendyShop.ViewModels
{
    public class AddCategoryViewModel
    {
        [Display(Name ="Nueva Categoría")]
        public string CategoryName { get; set; }
    }
}
