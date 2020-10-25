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
            var vm = new AuctionIndexViewModel
            {
                Auctions = context.Auctions.Include(a => a.Article).ToList(),
                Categories = context.Categories.ToList()
            };

            return View(vm);
        }

        public IActionResult CategoryFilter(int categoryId)
        {
            var vm = new AuctionIndexViewModel
            {
                Auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.CategoryId == categoryId).ToList(),
                Categories = context.Categories.ToList()
            };

            return View("Index", vm);
        }

        public IActionResult ConditionFilter(bool isNew)
        {
            var vm = new AuctionIndexViewModel
            {
                Categories = context.Categories.ToList()
            };

            if (isNew)
            {
                vm.Auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.IsNew).ToList();
                return View("Index", vm);
            }

            vm.Auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => !a.Article.IsNew).ToList();
            return View("Index", vm);
        }
        public IActionResult PriceFilter(float minp, float maxp)
        {
            var vm = new AuctionIndexViewModel
            {
                Categories = context.Categories.ToList(),
                Auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => (a.Article.Price >= minp && a.Article.Price <= maxp)).ToList()
            };

            return View("Index", vm);
        }

        public IActionResult Search(string search)
        {
            var vm = new AuctionIndexViewModel
            {
                Categories = context.Categories.ToList(),
                Auctions = context.Auctions.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.Name.Contains(search)).ToList()
            };

            return View("Index", vm);
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
                Price = auction.CurrentPrice
            };

            return View(result);
        }

        public IActionResult Join(int id)
        {
            //TO BE DEVELOPED
            var result = new AuctionViewModel
            {

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
                    Categories = context.Categories.ToList(),
                    Image = viewModel.Image
                };

                newViewModel.Auction.User = GetUser(User.Identity.Name); //returns null if user not found
                newViewModel.Auction.UserId = User.Identity.Name;
                newViewModel.Auction.CurrentPrice = viewModel.Auction.Article.Price;
                viewModel.Auction.Start = DateTime.Now;

                return View("NewAuction", newViewModel);
            }

            viewModel.Auction.User = GetUser(User.Identity.Name); //returns null if user not found
            viewModel.Auction.UserId = User.Identity.Name;
            viewModel.Auction.CurrentPrice = viewModel.Auction.Article.Price;
            viewModel.Auction.Start = DateTime.Now;
            viewModel.Auction.Article.Image = UploadFile(viewModel.Image);

            context.Auctions.Add(viewModel.Auction);//this already updates User and Article
            context.SaveChanges();

            return RedirectToAction("Index", "Auction");
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
    }
}

