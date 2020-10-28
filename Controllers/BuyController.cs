using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrendyShop.Data;
using Microsoft.EntityFrameworkCore;
using TrendyShop.ViewModels;
using TrendyShop.Models;

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

        public IActionResult Buy(string uid, int aid)
        {
            var userName = User.Identity.Name;

            if(userName == null)
            {
                return RedirectToAction("Login", "User");
            }
            var userId = context.Users.Single( u => u.UserName == userName).Id;
            
            var add = context.Adds.Include(a => a.Article)
                .Include(a => a.User)
                .Single(a => a.UserId == uid && a.ArticleId == aid);//just single nor singleOrDefault because this add already exist

            var buyViewModel = new BuyViewModel
            {
                Add = add,
                CustomerId = userId
            };

            return View(buyViewModel);
        }

        [HttpPost]//this is required so no get request will modify the database
        //public IActionResult EffectBuy(int aid, string uid, int card, int amountToBuy)
        public IActionResult EffectBuy(BuyViewModel bvm)
        {
            var add = context.Adds.Include(a => a.Article).Single(a => a.ArticleId == bvm.Add.ArticleId && a.UserId == bvm.Add.UserId);

            if (!ModelState.IsValid)
            {
                BuyViewModel newBvw = new BuyViewModel
                {
                    Add = add,
                    CustomerId = bvm.CustomerId,
                    AmountToBuy = bvm.AmountToBuy,
                };
                return View("Buy", newBvw);
            }

            //add.Amount -= amountToBuy;
            //if (add.Amount == 0)
            //{
            //    context.Articles.Remove(add.Article);
            //    context.Remove(add);
            //}

            //context.SaveChanges();

            var newOrder = new Order
            {   
                CustomerId = bvm.CustomerId,
                //SellerId = bvm.Add.UserId,
                ArticleId = bvm.Add.ArticleId,
                Date = DateTime.Now,
                Amount = bvm.AmountToBuy,
                Address= bvm.Address,
                //Shipping mode...
                ShippingCharge = bvm.ShippingCharge,
                Paid = false//no hace falta realmente, por default es false
            };

            context.Orders.Add(newOrder);
            context.SaveChanges();

            //var orderId = context.Orders()

            var totalCharge = newOrder.Amount * bvm.Add.Article.Price + newOrder.ShippingCharge;

            return RedirectToAction("GetPaymentMethod", "PaymentGateway", new { userId = newOrder.CustomerId/*, sellerId = newOrder.SellerId*/,articleId = newOrder.ArticleId, orderDateTicks = newOrder.Date.Ticks, charge = totalCharge });
        }

        public IActionResult CloseOrder(string userId, string sellerId, int articleID, long dateTicks)//address to deliver the order and shipping speed required
        {
            var date = new DateTime(dateTicks);
            var order = context.Orders.Single(o => o.CustomerId == userId /*&& o.SellerId == sellerId*/ && o.ArticleId == articleID && o.Date == date);
            order.Paid = true;
            context.SaveChanges();//se deberia mandar un mensaje de completada su orden o anulada

            var add = context.Adds.Single(a => a.ArticleId == articleID && a.UserId == sellerId);
            add.Amount-= order.Amount;
            context.SaveChanges();

            var seller = context.Users.Single(u => u.Id == sellerId);
            seller.TotalSales+= order.Amount;
            context.SaveChanges();

            return RedirectToAction("Index", "Add");
        }

        public IActionResult CancelOrder(string userId, int articleID, long dateTicks)//address to deliver the order and shipping speed required
        {
            var date = new DateTime(dateTicks);
            var order = context.Orders.Single(o => o.CustomerId == userId && o.ArticleId == articleID && o.Date == date);
            context.Orders.Remove(order);
            context.SaveChanges();//se deberia mandar un mensaje de completada su orden o anulada

            return RedirectToAction("Index", "Add");
        }
    }
}