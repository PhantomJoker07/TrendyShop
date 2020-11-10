using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrendyShop.ViewModels
{
    public class ShoppingListArticuleViewModel
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get { return Amount * Price; } }
    }
}
