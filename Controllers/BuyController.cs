using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrendyShop.Data;
using Microsoft.EntityFrameworkCore;
using TrendyShop.ViewModels;


namespace TrendyShop.Controllers
{
    public class BuyController : Controller
    {
        private EFDbContext context;

        public BuyController(EFDbContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Buy(int uid, int aid)
        {
            var add = context.Adds.Include(a => a.Article)
                .Include(a => a.User)
                .Single(a => a.UserId == uid && a.ArticleId == aid);//just single nor singleOrDefault because this add already exist

            var buyViewModel = new BuyViewModel
            {
                Add = add,
            };

            return View(buyViewModel);
        }

        [HttpPost]//this is required so no get request will modify the database
        public IActionResult EffectBuy(int aid, int uid, int card, int amountToBuy)
        {
            var add = context.Adds.Single(a => a.ArticleId == aid && a.UserId == uid);

            if (!ModelState.IsValid)
            {
                BuyViewModel bvw = new BuyViewModel
                {
                    Add = add,
                    AmountToBuy = amountToBuy,
                    Card = card
                };
                return View("Buy", bvw);
            }
            
            if(add.Amount < amountToBuy)
            {
                //mandar error
            }
            add.Amount -= amountToBuy;

            context.SaveChanges();

            return RedirectToAction("Index","Add");
        }
    }
}