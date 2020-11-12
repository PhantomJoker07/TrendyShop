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
            var add = context.Adds.Include(a => a.Article)
                .Single(a => a.ArticleId == bvm.Add.ArticleId && a.UserId == bvm.Add.UserId);

            if (bvm.AmountToBuy > bvm.Add.Amount)
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

            return RedirectToAction("GetPaymentMethod", "PaymentGateway",
                new { userId = newOrder.CustomerId, articleId = newOrder.ArticleId,
                    orderDateTicks = newOrder.Date.Ticks, charge = totalCharge });
        }

        public IActionResult BuySCArticles()
        {
            var userName = User.Identity.Name;
            var userId = context.Users.Single(u => u.UserName == userName).Id;

            var carItems = (from a in context.ShoppingCars
                            join b in context.ShoppingLists on a.ShoppingListId equals b.ShoppingListId
                            join c in context.ShoppingList_Articles on b.ShoppingListId equals c.ShoppingListId
                            where b.IsMainList == true && a.UserId == userId
                            select new { c.Article, c.Amount }).ToList();

            if (carItems.Count == 0)
                return RedirectToAction("Index", "ShoppingCart");

            var buyViewModel = new BuySCArticleViewModel
            {
                CustomerId = userId,
                Total = 0
            };

            List<ShoppingListArticuleViewModel> articlesToBuy = new List<ShoppingListArticuleViewModel>();

            foreach (var item in carItems)
            {
                var ad = context.Adds.Include(a => a.User).SingleOrDefault(b => b.ArticleId == item.Article.ArticleId);

                ShoppingListArticuleViewModel slArticle = new ShoppingListArticuleViewModel
                {
                    ArticleId = item.Article.ArticleId,
                    Name = item.Article.Name,
                    Price = item.Article.Price
                };

                if (ad.Amount >= item.Amount)//si hay disponible la ctdad necesaria compralo todo
                {
                    slArticle.Amount = item.Amount;
                    articlesToBuy.Add(slArticle);
                    buyViewModel.Total += slArticle.TotalPrice;
                }
                else//sino comprar todo lo que queda y reportar que no se pudo obtener todo, a no ser que se haya agotado.
                {
                    if (ad.Amount > 0)
                    {
                        slArticle.Amount = ad.Amount;
                        articlesToBuy.Add(slArticle);
                    }
                    buyViewModel.Incomplete = true;
                    buyViewModel.Total += slArticle.TotalPrice;
                }
            }

            buyViewModel.SCArticles = articlesToBuy;

            return View(buyViewModel);
        }

        [HttpPost]
        public IActionResult EffectSCBuy(BuySCArticleViewModel bvm)
        {
            if (!ModelState.IsValid)
            {
                BuySCArticleViewModel newBvm = new BuySCArticleViewModel
                {
                    CustomerId = bvm.CustomerId,
                    Total = bvm.Total,
                    Incomplete = bvm.Incomplete,
                    Address = bvm.Address,
                    SCArticles = bvm.SCArticles
                };
                return View("BuySCArticles", newBvm);
            }
            var date = DateTime.Now;
            foreach (var article in bvm.SCArticles)
            {
                var newOrder = new Order
                {//poner un booleano o algo que represente que la entrega fue de shopping car, por tanto el cobro por esta es en general
                    CustomerId = bvm.CustomerId,
                    ArticleId = article.ArticleId,
                    Date = date,
                    Amount = article.Amount,
                    Address = bvm.Address,
                    ShippingCharge = bvm.ShippingCharge,
                    SharedOrder = true
                };

                context.Orders.Add(newOrder);
                context.SaveChanges();
            }


            var totalCharge = bvm.Total + bvm.ShippingCharge;

            return RedirectToAction("GetPaymentMethod", "PaymentGateway", new { userId = bvm.CustomerId, articleId = -1, orderDateTicks = date.Ticks, charge = totalCharge, orderType = 1 });
        }

        public IActionResult BuyAuctionArticle(int aid)
        {
            var userName = User.Identity.Name;

            if (userName == null)
            {
                return RedirectToAction("Login", "User");
            }
            var userId = context.Users.Single(u => u.UserName == userName).Id;

            var auction = context.Auctions.Include(a => a.Article).Include(a => a.LastBid)
                .Include(a => a.User)
                .Single(a => a.ArticleId == aid);
            
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
                    orderType = 2
                });
        }

        public IActionResult CloseOrder(string userId, int articleId, long dateTicks, int orderType)
        {
            if (orderType == 1)
            {
                return CloseShoppingCartOrders(userId, dateTicks);
            }
            else if (orderType == 2)
            {
                return CloseAuctionOrder(userId, articleId, dateTicks);
            }
            else
            {
                return CloseRegularOrder(userId, articleId, dateTicks);
            }
        }

        private void closeRegularOrder(string userId, int articleId, long dateTicks) 
        {
            var date = new DateTime(dateTicks);
            var order = context.Orders.Single(o => o.CustomerId == userId && o.ArticleId == articleId && o.Date == date);
            order.Paid = true;
            context.SaveChanges();

            var add = context.Adds.Single(a => a.ArticleId == articleId);
            add.Amount -= order.Amount;
            context.SaveChanges();

            var seller = context.Users.Single(u => u.Id == add.UserId);
            seller.TotalSales += order.Amount;
            seller.Rating += 5;
            context.SaveChanges();

            var currentUserName = User.Identity.Name;
            var currentUser = context.Users.Single(u => u.UserName == currentUserName);
            currentUser.Rating += 1;
            context.SaveChanges();
        }

        private IActionResult CloseShoppingCartOrders(string userId, long dateTicks)
        {
            var date = new DateTime(dateTicks);
            var orders = context.Orders.Where(o => o.CustomerId == userId && o.Date == date).ToList();

            foreach (var order in orders)
            {
                closeRegularOrder(userId, order.ArticleId, date.Ticks);
            }

            if (orders.Count > 1)
            {
                var currentUserName = User.Identity.Name;
                var currentUser = context.Users.Single(u => u.UserName == currentUserName);
                currentUser.Rating += orders.Count;//un punto adicional por cada objeto comprado por ser una compra por catdad
                context.SaveChanges();
            }

            var mySl = (from sc in context.ShoppingCars
                        join sl in context.ShoppingLists
                        on sc.ShoppingListId equals sl.ShoppingListId
                        where sc.UserId == userId && sl.IsMainList == true
                        select new { sl.ShoppingListId }).ToList();
            
            var shoppingList = context.ShoppingLists.SingleOrDefault(sl => sl.ShoppingListId == mySl.First().ShoppingListId);

            if (shoppingList != null)
            {
                if (shoppingList.IsSaved)
                {
                    shoppingList.IsMainList = false;
                }
                else
                {
                    context.ShoppingLists.Remove(shoppingList);
                }
            }
            context.SaveChanges();
            
            return RedirectToAction("Index", "Add");
        }

        private IActionResult CloseRegularOrder(string userId, int articleId, long dateTicks)
        {
            closeRegularOrder(userId, articleId, dateTicks);
            
            return RedirectToAction("Index", "Add");
        }

        private IActionResult CloseAuctionOrder(string userId, int articleId, long dateTicks)
        {
            var date = new DateTime(dateTicks);
            var order = context.AuctionOrders.Single(o => o.CustomerId == userId && o.ArticleId == articleId && o.Date == date);
            order.Paid = true;
            context.SaveChanges();

            var auction = context.Auctions.Find(order.ArticleId);
            auction.Paid = true;
            context.SaveChanges();

            var seller = context.Users.Single(u => u.Id == auction.UserId);
            seller.TotalSales += 1;
            seller.Rating += 10;
            context.SaveChanges();

            var currentUserName = User.Identity.Name;
            var currentUser = context.Users.Single(u => u.UserName == currentUserName);
            currentUser.Rating += 5;
            context.SaveChanges();

            return RedirectToAction("Index", "Auction");
        }

        public IActionResult CancelOrder(string userId, int articleID, long dateTicks, int orderType)
        {
            var date = new DateTime(dateTicks);
            if(orderType == 1)
            {
                var orders = context.Orders.Where(o => o.CustomerId == userId && o.Date == date).ToList();

                foreach (var order in orders)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
                return RedirectToAction("Index", "Add");
            }
            else if (orderType == 2)
            {
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