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


            //Como yo voy a ten

            var cartArt = (from a in context.ShoppingCars
                           join b in context.ShoppingLists on a.ShoppingListId equals b.ShoppingListId
                           join c in context.ShoppingList_Articles on b.ShoppingListId equals c.ShoppingListId
                           where b.IsMainList == true    //&& a.UserId==miUserId
                           select new { c.Article, c.Amount, b.ShoppingListId });   //Aqui


            List<ShoppingListViewModel> CartItems = new List<ShoppingListViewModel>();
            int sl = 0;


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



        public IActionResult AddToShoppCart(string uid, int aid)
        {
            var add = context.Adds.Include(a => a.Article)
                .Include(a => a.User)
                .Single(a => a.UserId == uid && a.ArticleId == aid);//just single nor singleOrDefault because this add already exist

            var addViewModel = new AddToSCViewModel
            {
                Add = add,
            };

            return View(addViewModel);
        }



        public IActionResult AddToCart(int aid, string uid, int amountToAdd)
        {
            var add = context.Adds.Include(a => a.Article).Include(a => a.User).Single(a => a.ArticleId == aid && a.UserId == uid);

            if (!ModelState.IsValid)
            {
                AddToSCViewModel avw = new AddToSCViewModel
                {
                    Add = add,
                    AmountToAdd = amountToAdd,

                };
                return View("AddToShoppCart", avw);
            }

            if (add.Amount < amountToAdd)
            {
                //mandar error
            }


            var sl = context.ShoppingLists.SingleOrDefault(s => s.IsMainList == true);

            if (sl == null)
            {
                ShoppingList sl1 = new ShoppingList
                {
                    IsMainList = true,
                    IsSaved = false


                };
                context.ShoppingLists.Add(sl1);


                context.SaveChanges();
            }


            var sl2 = context.ShoppingLists.SingleOrDefault(s => s.IsMainList == true);


            if (context.ShoppingCars.SingleOrDefault(c => (int.Parse(c.UserId) == 1 && c.ShoppingListId == sl2.ShoppingListId)) == null)
            {
                ShoppingCar sc = new ShoppingCar
                {
                    ShoppingListId = sl2.ShoppingListId,
                    ShoppingList = sl2,
                    UserId = "1",
                };

                context.ShoppingCars.Add(sc);
            }




            ShoppingList_Article sla = new ShoppingList_Article
            {
                ShoppingListId = sl2.ShoppingListId,
                ShoppingList = sl2,
                ArticleId = add.ArticleId,
                Article = add.Article,
                Amount = amountToAdd
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


        public IActionResult BuyCart()
        {
            var carItems = (from a in context.ShoppingCars
                            join b in context.ShoppingLists on a.ShoppingListId equals b.ShoppingListId
                            join c in context.ShoppingList_Articles on b.ShoppingListId equals c.ShoppingListId
                            where b.IsMainList == true
                            select new { c.Article, c.Amount }).ToList();


            foreach (var item in carItems)
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

            var sl = context.ShoppingLists.SingleOrDefault(c => c.IsMainList == true);

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
            var saved = (from l in context.ShoppingLists
                         where l.IsSaved == true
                         select l).ToList();


            return View(saved);
        }


        public IActionResult LoadShoppingList(int sid)
        {
            var currentsl = context.ShoppingLists.SingleOrDefault(c => c.IsMainList == true);
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





    }
}