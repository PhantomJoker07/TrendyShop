using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrendyShop.Controllers;
using TrendyShop.Data;
using TrendyShop.ViewModels;
using TrendyShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TrendyShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private EFDbContext context;

        public ShoppingCartController(EFDbContext ctx)
        {
            context = ctx;
        }




        public IActionResult Index()
        {
            var userid = GetUser(User.Identity.Name).Id;

            var cartArt = (from a in context.ShoppingCars
                           join b in context.ShoppingLists on a.ShoppingListId equals b.ShoppingListId
                           join c in context.ShoppingList_Articles on b.ShoppingListId equals c.ShoppingListId
                           where b.IsMainList == true && a.UserId == userid
                           select new { c.Article, c.Amount, b.ShoppingListId });   


            List<ShoppingListViewModel> CartItems = new List<ShoppingListViewModel>();
            int sl = 0;
            float TotalPrice = 0;
            foreach (var item in cartArt)
            {

                sl = item.ShoppingListId;
                CartItems.Add(new ShoppingListViewModel
                {
                    Article = item.Article,
                    ArticleId = item.Article.ArticleId,
                    Amount = item.Amount,
                    Price = (int)item.Article.Price * item.Amount
                });
                TotalPrice += (int)item.Article.Price * item.Amount;
            }

            var shoppingCartItem = new ShoppingCartViewModel
            {
                ShoppingList = CartItems,
                ShoppingListId = sl
            };

            return View(shoppingCartItem);
        }

        [HttpPost]
        public IActionResult AddToCart(int aid, string uid, int amountToBuy)
        {

            if (amountToBuy <= 0)
                return RedirectToAction("Index", "Add");


            uid = GetUser(uid).Id;
            var add = context.Adds.Include(a => a.Article).Include(a => a.User).Single(a => a.ArticleId == aid && a.UserId == uid);

            var mySl = (from sc in context.ShoppingCars
                        join l in context.ShoppingLists
                        on sc.ShoppingListId equals l.ShoppingListId
                        where sc.UserId == GetUser(User.Identity.Name).Id && l.IsMainList == true
                        select new { l.ShoppingListId }).ToList();

       
            var sl2 = new ShoppingList();
            if (mySl.Count() == 0)
            {
                ShoppingList sl1 = new ShoppingList
                {
                    IsMainList = true,
                    IsSaved = false
                };
                context.ShoppingLists.Add(sl1);


                context.SaveChanges();
                sl2 = context.ShoppingLists.SingleOrDefault(l => context.ShoppingCars.Any(c => c.ShoppingListId == l.ShoppingListId) == false);

            }
            else
            {
                foreach (var item in mySl)
                {
                    sl2 = context.ShoppingLists.Find(item.ShoppingListId);
                }
            }

            if (context.ShoppingCars.SingleOrDefault(c => (c.UserId == GetUser(User.Identity.Name).Id && c.ShoppingListId == sl2.ShoppingListId)) == null)
            {
                ShoppingCar sc = new ShoppingCar
                {
                    UserId = User.Identity.Name,
                    User = GetUser(User.Identity.Name),
                    ShoppingListId = sl2.ShoppingListId,
                    ShoppingList = sl2

                };

                context.ShoppingCars.Add(sc);
                context.SaveChanges();

            }


            ShoppingList_Article sla = new ShoppingList_Article
            {
                ShoppingListId = sl2.ShoppingListId,
                ShoppingList = sl2,
                ArticleId = add.ArticleId,
                Article = add.Article,
                Amount = amountToBuy
            };


            if ((context.ShoppingList_Articles.SingleOrDefault(a => a.ShoppingListId == sla.ShoppingListId && a.ArticleId == sla.ArticleId)) == null)
            {
                context.ShoppingList_Articles.Add(sla);

            }


            context.SaveChanges();

            return RedirectToAction("Index", "Add");
        }


        public IActionResult BuyCart()
        {
            var notBought = new List<Article>();
            bool notB = false;
            var userid = GetUser(User.Identity.Name).Id;

            var cartItems = (from a in context.ShoppingCars
                             join b in context.ShoppingLists on a.ShoppingListId equals b.ShoppingListId
                             join c in context.ShoppingList_Articles on b.ShoppingListId equals c.ShoppingListId
                             where b.IsMainList == true && a.UserId == userid
                             select new { c.Article, c.Amount }).ToList();   
            if(cartItems.Count ==0)
                return RedirectToAction("Index", "ShoppingCart");


            foreach (var item in cartItems)
            {
                var ad = context.Adds.SingleOrDefault(b => b.ArticleId == item.Article.ArticleId);
                context.Entry(ad).Reference(a => a.User).Load();

                if (ad.Amount >= item.Amount)
                {

                    ad.Amount -= item.Amount;
                    ad.User.TotalSales++;

                }
                else
                {
                    notB = true;
                    notBought.Add(ad.Article);
                }
               
            }

            var mySl = (from sc in context.ShoppingCars
                        join l in context.ShoppingLists
                        on sc.ShoppingListId equals l.ShoppingListId
                        where sc.UserId == userid && l.IsMainList == true
                        select new { l.ShoppingListId }).ToList();

            var sl = new ShoppingList();

            foreach (var item in mySl)
            {
                sl = context.ShoppingLists.Find(item.ShoppingListId);
            }


            if (sl != null)
            {

                if (sl.IsSaved)
                {
                    sl.IsMainList = false;
                }
                else
                {
                    context.ShoppingLists.Remove(sl);
                }
            }
            context.SaveChanges();

            if (notB)
            {
                return View("NoBuy", notBought);
            }

            return RedirectToAction("Index", "Add");
        }



        public IActionResult DeleteArticle(int slid, int aid)
        {
            var art = context.ShoppingList_Articles.Single(a => (a.ShoppingListId == slid && a.ArticleId == aid));
            context.ShoppingList_Articles.Remove(art);
            var sl = context.ShoppingList_Articles.Where(a => a.ShoppingListId == slid);
            if(sl.Count() == 0)
            {
                var l = context.ShoppingLists.Find(slid);
                context.ShoppingLists.Remove(l);
                context.SaveChanges();
            }


            context.SaveChanges();
            return RedirectToAction("Index", "ShoppingCart");
        }




        
        public IActionResult SaveShoppingList(ShoppingCartViewModel shoppingCartViewModel)
        {
            var sl = context.ShoppingLists.SingleOrDefault(s => s.ShoppingListId == shoppingCartViewModel.ShoppingListId);
            if(sl != null) 
            {
                sl.IsSaved = true;
                sl.Name = shoppingCartViewModel.ShoppListName;
                context.SaveChanges();
            }
            return RedirectToAction("Index", "ShoppingCart");
        }


        public IActionResult SavedLists()
        {
            var userid = GetUser(User.Identity.Name).Id;
            var saved = (from sc in context.ShoppingCars
                         join l in context.ShoppingLists
                         on sc.ShoppingListId equals l.ShoppingListId
                         where sc.UserId == userid && l.IsSaved == true
                         select l).ToList();

            return View(saved);
        }


        public IActionResult LoadShoppingList(int sid)
        {

            var mySl = (from sc in context.ShoppingCars
                        join l in context.ShoppingLists
                        on sc.ShoppingListId equals l.ShoppingListId
                        where sc.UserId == GetUser(User.Identity.Name).Id && l.IsMainList == true
                        select new { l.ShoppingListId }).ToList();

            var currentsl = new ShoppingList();


            foreach (var item in mySl)
            {
                currentsl = context.ShoppingLists.Find(item.ShoppingListId);
            }


            if (currentsl != null)
            {
                currentsl.IsMainList = false;
            }

            var sl = context.ShoppingLists.Find(sid);
            sl.IsMainList = true;

            context.SaveChanges();
            return RedirectToAction("Index", "ShoppingCart");

        }


        public IActionResult DeleteListIndex(int sid)
        {
            var list = context.ShoppingLists.SingleOrDefault(s =>s.ShoppingListId == sid);
            if(list != null)
            {
                if (list.IsSaved)
                {
                    list.IsMainList = false;
                }
                else
                {
                    DeleteShoppingList(sid);
                }
            }
            return RedirectToAction("Index", "ShoppingCart");
        }

        public IActionResult DeleteShoppingList(int sid)
        {
            var sl = context.ShoppingLists.Find(sid);
            context.ShoppingLists.Remove(sl);
            context.SaveChanges();
            return RedirectToAction("Index", "ShoppingCart");
        }

        public IActionResult Details(int sid)
        {
            var sl = context.ShoppingLists.Find(sid);

            var slart = context.ShoppingList_Articles.Include(a => a.Article).Where(a => a.ShoppingListId == sid);

            var viewmodel = new SLDetailsViewModel
            {
                ShoppingListId = sl.ShoppingListId,
                ShoppingListName = sl.Name,
                List = slart
            };


            return View(viewmodel);
        }



        public User GetUser(string UserId)
        {
            var users = context.Users;
            foreach (var u in users)
            {
                if (string.Compare(u.UserName, UserId) == 0)
                {
                    return u;
                }
            }
            throw new Exception("User " + UserId + " not found");
        }

    }
}