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
                           select new { c.Article, c.Amount, b.ShoppingListId });   //Aqui


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

            if (CartItems.Count == 0)
            {
                var list = context.ShoppingLists.SingleOrDefault(s => s.IsMainList == true);
                if (list != null)
                {
                    context.ShoppingLists.Remove(list);
                    context.SaveChanges();
                }

            }

            var shoppingCartItem = new ShoppingCartViewModel
            {
                ShoppingList = CartItems,
                ShoppingListId = sl
            };

            return View(shoppingCartItem);
        }



        public IActionResult AddToShoppCart(int aid, string uid)
        {


            var user = GetUser(uid);
            var add = context.Adds.Include(a => a.Article)
                .Include(a => a.User)
                .Single(a => a.UserId == user.Id && a.ArticleId == aid);//just single nor singleOrDefault because this add already exist

            var addViewModel = new AddToSCViewModel
            {
                Add = add,
            };

            return View(addViewModel);
        }


        [HttpPost]
        public IActionResult AddToCart(int aid, string uid, int amountToBuy)
        {

            if (amountToBuy <= 0)
                return RedirectToAction("Index", "Add");


            uid = GetUser(uid).Id;
            var add = context.Adds.Include(a => a.Article).Include(a => a.User).Single(a => a.ArticleId == aid && a.UserId == uid);



            if (add.Amount < amountToBuy)
            {
                //mandar error
            }


            //var loggedUserId = GetUser(User.Identity.Name).Id;

            var mySl = (from sc in context.ShoppingCars
                        join l in context.ShoppingLists
                        on sc.ShoppingListId equals l.ShoppingListId
                        where sc.UserId == GetUser(User.Identity.Name).Id && l.IsMainList == true
                        select new { l.ShoppingListId }).ToList();

            //var sl = context.ShoppingLists.SingleOrDefault(s => s.IsMainList == true);
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


            //var sl2 = context.ShoppingLists.SingleOrDefault(s => s.IsMainList == true);




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
            else
            {
                //Retonar q ya esta en el carrito
            }

            context.SaveChanges();

            return RedirectToAction("Index", "Add");
        }


        public IActionResult BuyCart(ShoppingCartViewModel shoppingCartViewModel)
        {


            var userid = GetUser(User.Identity.Name).Id;

            var cartItems = (from a in context.ShoppingCars
                             join b in context.ShoppingLists on a.ShoppingListId equals b.ShoppingListId
                             join c in context.ShoppingList_Articles on b.ShoppingListId equals c.ShoppingListId
                             where b.IsMainList == true && a.UserId == userid
                             select new { c.Article, c.Amount }).ToList();   //Aqui

            foreach (var item in cartItems)
            {
                var ad = context.Adds.SingleOrDefault(b => b.ArticleId == item.Article.ArticleId);
                context.Entry(ad).Reference(a => a.User).Load();

                if (ad.Amount < item.Amount)
                {
                    //Return Algo q no se
                }
                else
                {
                    ad.Amount -= item.Amount;
                    ad.User.TotalSales++;

                    if (ad.Amount == 0)
                    {
                        context.Articles.Remove(ad.Article);
                        context.Remove(ad);
                    }

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

            return RedirectToAction("Index", "Add");
        }



        public IActionResult DeleteArticle(int slid, int aid)
        {
            //Eliminarlo de la tabla Shplarticle
            var art = context.ShoppingList_Articles.Single(a => (a.ShoppingListId == slid && a.ArticleId == aid));
            context.ShoppingList_Articles.Remove(art);
            context.SaveChanges();
            return RedirectToAction("Index", "ShoppingCart");
        }




        // [HttpPost]
        public IActionResult SaveShoppingList(/*int sid,string n */ ShoppingCartViewModel shoppingCartViewModel)
        {
            var sl = context.ShoppingLists.Find(shoppingCartViewModel.ShoppingListId);

            //sl.IsMainList = false;
            sl.IsSaved = true;
            sl.Name = shoppingCartViewModel.ShoppListName;
            context.SaveChanges();

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





        [HttpPost]
        public IActionResult UpdateQuantity(ShoppingListViewModel slart, int quantity)
        {
            slart.Amount = quantity;

            return RedirectToAction("Index", "ShoppingCart");
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