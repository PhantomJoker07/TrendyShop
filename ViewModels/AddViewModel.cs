using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;

namespace TrendyShop.ViewModels
{
    public class AddViewModel
    {
        public int Id { get; set; }

        public Article Article { get; set; }

        public string UserName { get; set; }

        public User User { get; set; }

        public int Amount { get; set; }

        public string AddDescription { get; set; }

        public bool AlreadyInCart { get; set; }
    }
}
