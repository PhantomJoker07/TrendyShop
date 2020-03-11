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

        public ViewResult NewAdd()
        {
            var categories = context.Categories.ToList();
            var model = new NewAddViewModel {
                Add = new Add(),
                Categories = categories
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateNewAdd(NewAddViewModel viewModel)
        {
            context.Adds.Add(viewModel.Add);//this already updates User and Article
            context.SaveChanges();

            return RedirectToAction("Index", "Add");
        }

        [HttpPost]
        public IActionResult EditAdd(int aid, int uid)
        {
            var add = context.Adds.SingleOrDefault(a => a.ArticleId == aid && a.UserId == uid);

            if (add == null)
            {
                //return HttpNotFound();
            }
                


            return View("NewAdd", add);
        }
    }
}