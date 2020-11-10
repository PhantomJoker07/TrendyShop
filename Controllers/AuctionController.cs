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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TrendyShop.Controllers
{
    public class AuctionController : Controller
    {
        private EFDbContext context;
        private IWebHostEnvironment webHostEnvironment;

        public AuctionController(EFDbContext ctx, IWebHostEnvironment hostEnvironment)
        {
            context = ctx;
            webHostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var date = DateTime.Now;
            var vm = new AuctionIndexViewModel
            {
                Auctions = context.Auctions.Include(a => a.Article).ToList().Where(a=> a.Start <= date && a.Start + a.Duration > date || a.Start > date),
                Categories = context.Categories.ToList(),
                UserIsAdmin = User.IsInRole("Admin")
            };

            return View(vm);
        }

        public IActionResult MyAuctions()
        {
            var currentUserName = User.Identity.Name;
            var userId = context.Users.Single(u => u.UserName == currentUserName).Id;

            var date = DateTime.Now;
            var vm = new AuctionIndexViewModel
            {
                Auctions = context.Auctions.Include(a => a.Article).Where(a => a.UserId == userId).ToList(),
                Categories = context.Categories.ToList()
            };

            return View(vm);
        }

        public IActionResult AllFilter(bool myAucts = false)
        {
            var vm = new AuctionIndexViewModel
            {
                Categories = context.Categories.ToList()
            };

            if (myAucts)
            {
                var userName = User.Identity.Name;
                var userId = context.Users.Single(u => u.UserName == userName).Id;
                vm.Auctions = context.Auctions.Include(a => a.Article).Where(a => a.UserId == userId).ToList();
                return View("MyAuctions",vm);
            }

            vm.Auctions = context.Auctions.Include(a => a.Article).ToList();
            return View("Index", vm);
        }
        
        public IActionResult CategoryFilter(int categoryId, bool myAucts = false)
        {
            var vm = new AuctionIndexViewModel
            {
                Categories = context.Categories.ToList()
            };

            if (myAucts)
            {
                var userName = User.Identity.Name;
                var userId = context.Users.Single(u => u.UserName == userName).Id;
                vm.Auctions = context.Auctions.Include(a => a.Article)
                                              .Include(a => a.User)
                                              .Where(a => a.Article.CategoryId == categoryId && a.UserId == userId)
                                              .ToList();
                return View("MyAuctions", vm);
            }

            vm.Auctions = context.Auctions.Include(a => a.Article)
                                          .Include(a => a.User)
                                          .Where(a => a.Article.CategoryId == categoryId)
                                          .ToList();
            return View("Index", vm);
        }

        public IActionResult ConditionFilter(bool isNew, bool myAucts = false)
        {
            var vm = new AuctionIndexViewModel
            {
                Categories = context.Categories.ToList()
            };

            IQueryable<Auction> auctions;
            if (isNew)
            {
                auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.IsNew);
            }
            else
            {
                auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => !a.Article.IsNew);
            }

            if (myAucts)
            {
                var userName = User.Identity.Name;
                if (userName != null)
                {
                    var userId = context.Users.Single(u => u.UserName == userName).Id;
                    vm.Auctions = auctions.Where(a => a.UserId == userId).ToList();
                    return View("MyAuctions", vm);
                }//else mandar error aqui y en todos los filtros
            }

            vm.Auctions = auctions.ToList();
            return View("Index", vm);
        }

        public IActionResult PriceFilter(float minp, float maxp, bool myAucts = false)
        {
            var vm = new AuctionIndexViewModel
            {
                Categories = context.Categories.ToList()
            };

            if (myAucts)
            {
                var userName = User.Identity.Name;
                var userId = context.Users.Single(u => u.UserName == userName).Id;
                vm.Auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => (a.Article.Price >= minp && a.Article.Price <= maxp) && a.UserId == userId).ToList();
                return View("MyAuctions", vm);
            }

            vm.Auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => (a.Article.Price >= minp && a.Article.Price <= maxp)).ToList();

            return View("Index", vm);
        }

        public IActionResult StateFilter(int state, bool myAucts = false)
        {
            var vm = new AuctionIndexViewModel
            {
                Categories = context.Categories.ToList()
            };

            var date = DateTime.Now;
            if (state == 1)//pasadas
            {
                vm.Auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).ToList().Where(a => a.Duration < date - a.Start);
            }
            else if (state == 2)//en curso
            {
                vm.Auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).ToList().Where(a => a.Start <= date && a.Start + a.Duration > date);

                //auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => a.Start <= date && a.Start + a.Duration > date);
            }
            else//pendientes
            {
                vm.Auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => a.Start > date).ToList();
            }

            if (myAucts)
            {
                var userName = User.Identity.Name;
                if (userName != null)
                {
                    var userId = context.Users.Single(u => u.UserName == userName).Id;
                    vm.Auctions = vm.Auctions.Where(a => a.UserId == userId);
                    return View("MyAuctions", vm);
                }//else mandar error aqui y en todos los filtros
            }

            return View("Index", vm);
        }

        public IActionResult Search(string search, bool myAucts = false)
        {
            var vm = new AuctionIndexViewModel
            {
                Categories = context.Categories.ToList()
            };

            if (myAucts)
            {
                var userName = User.Identity.Name;
                var userId = context.Users.Single(u => u.UserName == userName).Id;
                vm.Auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.Name.Contains(search) && a.UserId == userId).ToList();
                return View("MyAuctions", vm);
            }

            vm.Auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.Name.Contains(search)).ToList();
            return View("Index", vm);
        }

        public IActionResult Details(int id)
        {
            var auction = context.Auctions.Find(id);

            context.Entry(auction).Reference(a => a.User).Load();
            context.Entry(auction).Reference(a => a.Article).Load();
            context.Entry(auction).Reference(a => a.LastBid).Load();

            var winner = context.Users.Find(auction.LastBid.UserId);

            
            string deadline = (auction.Start + auction.Duration).ToString("yyyy-MM-dd hh:mm");
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
                IsFinished = auction.IsFinished,
                HasStarted = auction.HasStarted,
                Biders = auction.Biders,
                Min_Bid = auction.Min_Bid,
                Paid = auction.Paid,
                Winner = winner.UserName,
                Deadline = deadline
            };

            //Checks if the auction has started
            if (auction.Start <= DateTime.Now)
            {
                auction.HasStarted = true;
                result.HasStarted = true;
                context.SaveChanges();
            }
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
            context.Entry(auction).Reference(a => a.LastBid).Load();

            if (ModelState.IsValid)
            {
                double amount = viewModel.BidAmount;
                if (amount >= auction.CurrentPrice + auction.Min_Bid || (creator.Id == auction.LastBid.UserId && amount == auction.CurrentPrice))
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
                    auction.BidId = nbid.BidId;
                    auction.Biders = CheckBiders(auction);
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
                    Categories = context.Categories.ToList(),
                    Image = viewModel.Image
                };

                return View("NewAuction", newViewModel);
            }

            Bid nbid = new Bid
            {
                amount = viewModel.Auction.Article.Price,
                user = GetUser(User.Identity.Name),
                time = new TimeSpan(0)
            };

            viewModel.Auction.Min_Bid = 1; // Cantidad mínima para subir de precio por defecto

            viewModel.Auction.LastBid = nbid;
            viewModel.Auction.User = GetUser(User.Identity.Name);
            viewModel.Auction.UserId = User.Identity.Name;
            viewModel.Auction.CurrentPrice = viewModel.Auction.Article.Price;
            viewModel.Auction.Article.Image = UploadFile(viewModel.Image);
            viewModel.Auction.Biders = 0;
            viewModel.Auction.IsFinished = false;
            viewModel.Auction.HasStarted = false;

            if (viewModel.Auction.Start <= DateTime.Now)
            {
                viewModel.Auction.Start = DateTime.Now;
                viewModel.Auction.HasStarted = true;
            }

            context.Auctions.Add(viewModel.Auction);//this already updates User and Article
            context.SaveChanges();

            return RedirectToAction("MyAuctions", "Auction");
        }

        private string UploadFile(IFormFile image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
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

        public int CheckBiders(Auction auction)
        {
            int result = auction.Biders;
            foreach (var bid in context.Bids)
            {
                if (bid.user.UserName == User.Identity.Name && bid.AuctionId == auction.ArticleId)
                {
                    result -= 1;
                    break;
                }
            }
            result++;
            return result;
        }
        
        public ActionResult Delete(int aid, bool fromIndex)
        {
            var auction = context.Auctions.Include(a => a.Article)
                .Single(a=>a.ArticleId == aid);

            var date = DateTime.Now;
            if(auction.Start <= date && auction.Start + auction.Duration >= date)
            {
                return RedirectToAction("MyAuctions", "Auction");
            }
            context.Articles.Remove(auction.Article);
            context.Auctions.Remove(auction);
            context.SaveChanges();

            if(fromIndex)
                return RedirectToAction("Index", "Auction");

            return RedirectToAction("MyAuctions", "Auction");
        }
    }
}

