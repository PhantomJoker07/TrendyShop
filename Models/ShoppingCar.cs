using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrendyShop.Models
{
    public class ShoppingCar
    {
        public string UserId { get; set; }

        [ForeignKey("UserId"), Column(Order = 0)]
        public User User { get; set; }

        public int ShoppingListId { get; set; }

        [Key, ForeignKey("ShoppingListId"), Column(Order = 1)]
        public ShoppingList ShoppingList { get; set; }

    }
}
