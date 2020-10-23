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
using System.Diagnostics;

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

        public IActionResult Details(int id)
        {
            var auction = context.Auctions.Find(id);

            context.Entry(auction).Reference(a => a.User).Load();
            context.Entry(auction).Reference(a => a.Article).Load();

            var result = new AuctionViewModel
            {
                UserName = auction.User.UserName,
                User = GetUser(auction.User.UserName),
                Duration = auction.Duration,
                Start = auction.Start,
                Article = auction.Article,
                Name = auction.Title,
                AuctionDescription = auction.Article.Description,  
                Price = auction.CurrentPrice,
                Bids = auction.Bids,
            };

            return View(result);
        }

        public IActionResult Bid(AuctionViewModel viewModel)
        {
            //TO BE DEVELOPED
          //  if (string.Compare(User.Identity.Name,viewModel.User.UserName) != 0 && !viewModel.IsFinished)
            {
                double amount = viewModel.BidAmount;

                if (amount > viewModel.Price)
                {
                    viewModel.Price = amount;

                    Bid nbid = new Bid
                    {
                        Amount = amount,
                        User = GetUser (User.Identity.Name),
                        Time = viewModel.Duration,
                    };

                    nbid.UserId = nbid.User.Id;
                    viewModel.Bids.Add(nbid);
                }

            }

            return View(viewModel);
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
                newViewModel.Auction.User = GetUser(User.Identity.Name); //returns null if user not found
                newViewModel.Auction.UserId = User.Identity.Name;
                newViewModel.Auction.CurrentPrice = viewModel.Auction.Article.Price;
                newViewModel.Auction.Start = DateTime.Now;
                newViewModel.Auction.IsFinished = false;
              //  Bid b2 = new Bid { User = GetUser(User.Identity.Name) };
              //  newViewModel.Auction.Bids.Add(b2);

                return View("NewAuction", newViewModel);
            }

            viewModel.Auction.User = GetUser(User.Identity.Name); //returns null if user not found
            viewModel.Auction.UserId = User.Identity.Name;
            viewModel.Auction.CurrentPrice = viewModel.Auction.Article.Price;
            viewModel.Auction.Start = DateTime.Now;
            viewModel.Auction.IsFinished = false;
            // Bid b = new Bid { User = GetUser(User.Identity.Name) };
            //  viewModel.Auction.Bids.Add(b);

            context.Auctions.Add(viewModel.Auction);//this already updates User and Article
            context.SaveChanges();

            return RedirectToAction("Index", "Auction");
        }


        public ActionResult Cancel(int aid, string uid)
        {
            var auction = context.Auctions.Include(a => a.Article).Include(a => a.User)
                .Single(a => a.UserId == uid && a.ArticleId == aid);

            context.Articles.Remove(auction.Article);
            context.Auctions.Remove(auction);
            context.SaveChanges();

            return RedirectToAction("Index", "Auction");
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

