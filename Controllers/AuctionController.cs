using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrendyShop.Data;

namespace TrendyShop.Controllers
{
    public class AuctionController : Controller
    {
        private EFDbContext context;

        public AuctionController(EFDbContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var auctions = context.Auctions.ToList();

            return View(auctions);
        }

        public IActionResult Details(int id)
        {
            var auction = context.Auctions.Find(id);

            return View(auction);
        }

        public IActionResult NewAuction()
        {
            return View();
        }

    }
}