using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;


namespace TrendyShop.ViewModels
{
    public class SLDetailsViewModel
    {
        public string Id { get; set; }

        public string ShoppingListId { get; set; }

        public string ShoppingListName { get; set; }


        public IEnumerable<ShoppingList_Article> List { get; set; }



    }

}
