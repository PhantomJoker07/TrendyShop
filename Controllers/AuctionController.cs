using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrendyShop.Data;
using TrendyShop.ViewModels;
using TrendyShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace TrendyShop.Controllers
{
    public class AuctionController : Controller
    {
        private EFDbContext context;

        public AuctionController(EFDbContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(string isNew, int categoryId = -1, int lprice = -1, int uprice = int.MaxValue)
        {
            var aucs = context.Auctions.Include(a => a.User).Include(a => a.Article).ToList();

            if (categoryId != -1)
                aucs = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.CategoryId == categoryId).ToList();

            if (isNew != null)
            {
                if (isNew == "true")
                    aucs = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.IsNew).ToList();
                else if (isNew == "false")
                    aucs = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => !a.Article.IsNew).ToList();
            }
          
            if (lprice != -1 || uprice != int.MaxValue)
                aucs = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => (a.Article.Price >= lprice && a.Article.Price <= uprice)).ToList();

            var categories = context.Categories.ToList();
            var vm = new AuctionIndexViewModel
            {
                Auctions = aucs,
                Categories = categories
            };

            return View(vm);
        }

        public IActionResult Details(string id)
        {
            var auction = context.Auctions.Find(id);

            context.Entry(auction).Reference(a => a.User).Load();
            context.Entry(auction).Reference(a => a.Article).Load();

            var result = new AuctionViewModel
            {
                UserName = auction.User.UserName,
                UserId = auction.User.Id,
                Duration = auction.Duration,
                AuctionDescription = auction.Article.Description,  
                Price = auction.Article.Price
            };

            return View(result);
        }

        public IActionResult NewAuction()
        {
            var categories = context.Categories.ToList();
            var model = new NewAuctionViewModel
            {
                Auction = new Auction(),
                Categories = categories
            };
            return View(model);

        }

        public IActionResult CreateNewAuction(NewAuctionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NewAuctionViewModel newViewModel = new NewAuctionViewModel
                {
                    Auction = viewModel.Auction,
                    Categories = context.Categories.ToList()
                };
                return View("NewAuction", newViewModel);
            }

            context.Auctions.Add(viewModel.Auction);//this already updates User and Article
            context.SaveChanges();

            return RedirectToAction("Index", "Auction");
        }


        public ActionResult Cancel(string aid, string uid)
        {
            var auction = context.Auctions.Include(a => a.Article).Include(a => a.User)
                .Single(a => a.UserId == uid && a.ArticleId == aid);

            context.Articles.Remove(auction.Article);
            context.Auctions.Remove(auction);
            context.SaveChanges();

            return RedirectToAction("Index", "Auction");
        }
    }
}

