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
            context.Entry(auction).Reference(a => a.LastBid).Load();

            var result = new AuctionViewModel
            {
                UserName = auction.User.UserName,
                User = GetUser(auction.User.UserName),
                Duration = auction.Duration,
                Start = auction.Start,
                Article = auction.Article,
                ArticleId = auction.ArticleId,
                Name = auction.Title,
                AuctionDescription = auction.Article.Description,
                Price = auction.CurrentPrice,
                LastBid = auction.LastBid,
                IsFinished = auction.IsFinished
            };

            //Checks if the auction is over
            if (auction.Duration < DateTime.Now - auction.Start)
            {
              auction.IsFinished = true;
              result.IsFinished = true;
              context.SaveChanges();
            }  
            return View(result);
        }

        public IActionResult Bid(AuctionViewModel viewModel)
        {
            var auction = context.Auctions.Find(viewModel.ArticleId);
            var creator = context.Users.Find(auction.UserId);

           // throw new Exception("User " + us.UserName + " is maja");

            if (ModelState.IsValid)
            {
                double amount = viewModel.BidAmount;

                if (amount > auction.CurrentPrice)
                {
                    auction.CurrentPrice = amount;

                    Bid nbid = new Bid
                    {
                        amount = amount,
                        user = GetUser(User.Identity.Name),
                        time = DateTime.Now - auction.Start,
                    };

                    if (string.Compare(nbid.user.UserName, creator.UserName) == 0) //The auction creator cant bid
                    {
                        return RedirectToAction("Index", "Auction");
                    }

                    nbid.UserId = nbid.user.Id;
                    nbid.AuctionId = viewModel.ArticleId;
                    auction.LastBid = nbid;
                    auction.CurrentPrice = amount;
                    auction.LastBid = nbid;
                    auction.BidId = nbid.BidId;
                    context.Bids.Add(nbid);
                    context.SaveChanges();

                }
            }
            return RedirectToAction("Details", "Auction", new { id = viewModel.ArticleId }, null);
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

            viewModel.Auction.User = GetUser(User.Identity.Name); //returns null if user not found
            viewModel.Auction.UserId = User.Identity.Name;
            viewModel.Auction.CurrentPrice = viewModel.Auction.Article.Price;
            viewModel.Auction.Start = DateTime.Now;
            viewModel.Auction.IsFinished = false;

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

