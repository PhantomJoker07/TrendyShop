using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrendyShop.Models
{
    public class ShoppingList_Article
    {
        public int ShoppingListId { get; set; }

        [Key, ForeignKey("ShoppingListId"), Column(Order = 0)]
        public ShoppingList ShoppingList { get; set; }

        public int ArticleId { get; set; }

        [Key, ForeignKey("ArticleId"), Column(Order = 1)]
        public Article Article { get; set; }

        public int Amount { get; set; }

    }
}
