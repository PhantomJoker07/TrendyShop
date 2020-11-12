using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;

namespace TrendyShop.ViewModels
{
    public class EditAddViewModel
    {
        public Add Add { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
