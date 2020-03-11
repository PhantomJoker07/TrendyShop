using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrendyShop.Data;
using TrendyShop.ViewModels;
using TrendyShop.Models;
using Microsoft.EntityFrameworkCore;

namespace TrendyShop.Controllers
{
    public class AddController : Controller
    {
        private EFDbContext context;
        
        public AddController(EFDbContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var ads = context.Adds.Include(a => a.User).Include(a => a.Article).ToList();

            return View(ads);
        }

        public IActionResult Details(int id)
        {
            var add = context.Adds.Find(id);

            context.Entry(add).Reference(a => a.User).Load();
            context.Entry(add).Reference(a => a.Article).Load();

            var result = new AddViewModel
            {
                Article = add.Article,
                UserName = add.User.Name,
                UserId = add.User.UserId,
                Amount = add.Amount,
                AddDescription = add.Description
            };

            return View(result);
        }

        public IActionResult NewAdd()
        {
            return View();
        }
    }
}