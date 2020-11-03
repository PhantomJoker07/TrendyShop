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

        public IActionResult BuyAddArticle(string uid, int aid)
        {
            var userName = User.Identity.Name;

            if (userName == null)
            {
                return RedirectToAction("Login", "User");
            }
            var userId = context.Users.Single(u => u.UserName == userName).Id;

            var add = context.Adds.Include(a => a.Article)
                .Include(a => a.User)
                .Single(a => a.UserId == uid && a.ArticleId == aid);

            var buyViewModel = new BuyAddArticleViewModel
            {
                Add = add,
                CustomerId = userId
            };

            return View(buyViewModel);
        }

        [HttpPost]
        public IActionResult EffectBuy(BuyAddArticleViewModel bvm)
        {
            var add = context.Adds.Include(a => a.Article).Single(a => a.ArticleId == bvm.Add.ArticleId && a.UserId == bvm.Add.UserId);

            if(bvm.AmountToBuy > bvm.Add.Amount)
            {
                ModelState.AddModelError("AmountToBuy", "La cantidad a comprar debe ser menor que la disponible en el anuncio.");
            }
            if (!ModelState.IsValid)
            {
                BuyAddArticleViewModel newBvw = new BuyAddArticleViewModel
                {
                    Add = add,
                    CustomerId = bvm.CustomerId,
                    AmountToBuy = bvm.AmountToBuy,
                    Address = bvm.Address
                };
                return View("BuyAddArticle", newBvw);
            }

            var newOrder = new Order
            {
                CustomerId = bvm.CustomerId,
                ArticleId = bvm.Add.ArticleId,
                Date = DateTime.Now,
                Amount = bvm.AmountToBuy,
                Address = bvm.Address,
                ShippingCharge = bvm.ShippingCharge
            };

            context.Orders.Add(newOrder);
            context.SaveChanges();

            var totalCharge = newOrder.Amount * bvm.Add.Article.Price + newOrder.ShippingCharge;

            return RedirectToAction("GetPaymentMethod", "PaymentGateway", new { userId = newOrder.CustomerId, articleId = newOrder.ArticleId, orderDateTicks = newOrder.Date.Ticks, charge = totalCharge });
        }

        public IActionResult BuyAuctionArticle(string uid, int aid)
        {
            var userName = User.Identity.Name;

            if (userName == null)
            {
                return RedirectToAction("Login", "User");
            }
            var userId = context.Users.Single(u => u.UserName == userName).Id;

            var auction = context.Auctions.Include(a => a.Article).Include(a => a.LastBid)
                .Include(a => a.User)
                .Single(a => a.UserId == uid && a.ArticleId == aid);


            if (auction.User.UserName == userName)
            {
                return RedirectToAction("Index", "Auction"); //Si nadie pujó en la subasta
            }

            var buyViewModel = new BuyAuctionArticleViewModel
            {
                Auction = auction,
                CustomerId = userId
            };

            return View(buyViewModel);
        }

        [HttpPost]
        public IActionResult EffectAuctionBuy(BuyAuctionArticleViewModel bvm)
        {
            var auction = context.Auctions.Include(a => a.Article).Include(a => a.LastBid)
                .Include(a => a.User)
                .Single(a => a.UserId == bvm.Auction.UserId && a.ArticleId == bvm.Auction.ArticleId);

            if (!ModelState.IsValid)
            {
                BuyAuctionArticleViewModel newBvw = new BuyAuctionArticleViewModel
                {
                    Auction = auction,
                    CustomerId = bvm.CustomerId,
                    Address = bvm.Address
                };
                return View("BuyAuctionArticle", newBvw);
            }

            var newOrder = new AuctionOrder
            {
                CustomerId = bvm.CustomerId,
                ArticleId = bvm.Auction.ArticleId,
                Date = DateTime.Now,
                Address = bvm.Address,
                ShippingCharge = bvm.ShippingCharge
            };

            context.AuctionOrders.Add(newOrder);
            context.SaveChanges();

            var totalCharge = auction.CurrentPrice + newOrder.ShippingCharge;

            return RedirectToAction("GetPaymentMethod", "PaymentGateway",
                new
                {
                    userId = newOrder.CustomerId,
                    articleId = newOrder.ArticleId,
                    orderDateTicks = newOrder.Date.Ticks,
                    charge = totalCharge,
                    forAuction = true
                });
        }

        public IActionResult CloseOrder(string userId, int articleId, long dateTicks, bool forAuction)
        {
            if (forAuction)
            {
                return CloseAuctionOrder(userId, articleId, dateTicks);
            }
            else
            {
                return CloseRegularOrder(userId, articleId, dateTicks);
            }
        }

        private IActionResult CloseRegularOrder(string userId, int articleId, long dateTicks)
        {
            var date = new DateTime(dateTicks);
            var order = context.Orders.Single(o => o.CustomerId == userId && o.ArticleId == articleId && o.Date == date);
            order.Paid = true;
            context.SaveChanges();//se deberia mandar un mensaje de completada su orden o anulada

            var add = context.Adds.Single(a => a.ArticleId == articleId);
            add.Amount -= order.Amount;
            context.SaveChanges();

            var seller = context.Users.Single(u => u.Id == add.UserId);
            seller.TotalSales += order.Amount;
            seller.Rating += 5;
            context.SaveChanges();

            //verificar que esto no joda todo
            var currentUserName = User.Identity.Name;
            var currentUser = context.Users.Single(u => u.UserName == currentUserName);
            currentUser.Rating += 1;
            context.SaveChanges();

            return RedirectToAction("Index", "Add");
        }

        private IActionResult CloseAuctionOrder(string userId, int articleId, long dateTicks)
        {
            var date = new DateTime(dateTicks);
            var order = context.AuctionOrders.Single(o => o.CustomerId == userId && o.ArticleId == articleId && o.Date == date);
            order.Paid = true;
            context.SaveChanges();//se deberia mandar un mensaje de completada su orden o anulada

            //auction Paid
            //var auction = context.Auctions.Include(a => a.Article).Include(a => a.LastBid)
            //    .Include(a => a.User)
            //    .Single(a => a.UserId == userId && a.ArticleId == articleId);

            var auction = context.Auctions.Find(order.ArticleId);
            auction.Paid = true;
            context.SaveChanges();

            var seller = context.Users.Single(u => u.Id == auction.UserId);
            seller.TotalSales += 1;
            seller.Rating += 10;
            context.SaveChanges();

            //verificar que esto no joda todo
            var currentUserName = User.Identity.Name;
            var currentUser = context.Users.Single(u => u.UserName == currentUserName);
            currentUser.Rating += 5;
            context.SaveChanges();

            return RedirectToAction("Index", "Auction");
        }

        public IActionResult CancelOrder(string userId, int articleID, long dateTicks, bool forAuction)
        {
            var date = new DateTime(dateTicks);
            if (forAuction)
            {//verificar paid en auction
                var order = context.AuctionOrders.Single(o => o.CustomerId == userId && o.ArticleId == articleID && o.Date == date);
                context.AuctionOrders.Remove(order);
                context.SaveChanges();
                return RedirectToAction("Index", "Auction");
            }
            else
            {
                var order = context.Orders.Single(o => o.CustomerId == userId && o.ArticleId == articleID && o.Date == date);
                context.Orders.Remove(order);
                context.SaveChanges();
                return RedirectToAction("Index", "Add");
            }
        }
    }
}