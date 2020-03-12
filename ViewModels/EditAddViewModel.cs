using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;

namespace TrendyShop.ViewModels
{
    public class EditAddViewModel
    {
        public int Id { get; set; }

        //public Article Article { get; set; }

        public Add Add { get; set; }

        public int UserId { get; set; }

        public IEnumerable<Category> Categories { get; set; }

    }
}
