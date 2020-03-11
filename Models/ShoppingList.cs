using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrendyShop.Models
{
    public class ShoppingList
    {
        [Key]
        public int ShoppingListId { get; set; }

        public bool IsMainList { get; set; }
    }
}
