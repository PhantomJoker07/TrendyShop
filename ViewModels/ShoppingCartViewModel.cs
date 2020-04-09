using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.ViewModels;

namespace TrendyShop.ViewModels
{
    public class ShoppingCartViewModel
    {

        public string Id { get; set; }
        public string ShoppingListId { get; set; }

        public IEnumerable<ShoppingListViewModel> ShoppingList { get; set; }

        [Display(Name = "Nombre de la Lista")]
        public string ShoppListName { get; set; }



    }
}

