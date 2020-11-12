using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrendyShop.Models;
using TrendyShop.ViewModels;
using TrendyShop.Data;
using Microsoft.AspNetCore.Authorization;

namespace TrendyShop.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private EFDbContext context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(EFDbContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var adds = (from add in context.Adds
                           join article in context.Articles
                           on add.ArticleId equals article.ArticleId
                           orderby add.LastModified descending
                           select new { add.ArticleId,add.Description, article.Name}).Take(10).ToList();

            List<HomeViewModel> recentAdds = new List<HomeViewModel>();

            foreach (var add in adds)
            {
                recentAdds.Add(
                    new HomeViewModel
                    {
                        AddId = add.ArticleId,
                        ArticleName = add.Name,
                        AddDescription = add.Description
                    }
                    );
            }

            return View(recentAdds);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
