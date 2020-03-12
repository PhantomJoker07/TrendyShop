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
        public IActionResult Index(string isNew, int categoryId = -1, int lprice = -1, int uprice = int.MaxValue)
        {
            //var ads = context.Adds.Include(a => a.User).Include(a => a.Article).ToList();

            //return View(ads);

            var ads = context.Adds.Include(a => a.User).Include(a => a.Article).ToList();

            if (categoryId != -1)
                ads = context.Adds.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.CategoryId == categoryId).ToList();

            if (isNew != null)
            {
                if (isNew == "true")
                    ads = context.Adds.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.IsNew).ToList();
                else if (isNew == "false")
                    ads = context.Adds.Include(a => a.Article).Include(a => a.User).Where(a => !a.Article.IsNew).ToList();
            }

            if (lprice != -1 || uprice != int.MaxValue)
                ads = context.Adds.Include(a => a.Article).Include(a => a.User).Where(a => (a.Article.Price >= lprice && a.Article.Price <= uprice)).ToList();

            var categories = context.Categories.ToList();
            var vm = new AddIndexViewModel
            {
                Adds = ads,
                Categories = categories
            };

            return View(vm);
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
            if (!ModelState.IsValid)
            {
                NewAddViewModel newViewModel = new NewAddViewModel
                {
                    Add = viewModel.Add,
                    Categories = context.Categories.ToList()
                }; 
                return View("NewAdd", newViewModel);
            }

            context.Adds.Add(viewModel.Add);//this already updates User and Article
            context.SaveChanges();

            return RedirectToAction("Index", "Add");
        }

        //[HttpPost]
        public ActionResult Edit(int aid, int uid)
        {
            var add = context.Adds.SingleOrDefault(a => a.ArticleId == aid && a.UserId == uid);
            context.Entry(add).Reference(a => a.Article).Load();

            if (add == null)
            {
                //return HttpNotFound();
            }

            var viewModel = new EditAddViewModel
            {
                Add = add,
                UserId = uid,
                Categories = context.Categories.ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult SaveEdition(EditAddViewModel editAddViewModel)
        {
            if (!ModelState.IsValid)
            {
                EditAddViewModel newEditAddViewModel = new EditAddViewModel
                {
                    UserId = editAddViewModel.Add.UserId,
                    Add = editAddViewModel.Add,
                    Categories = context.Categories.ToList()
                }; 
                return View("Edit", newEditAddViewModel);
            }

            //.Include(a => a.User).Include(a => a.Article)
            var addInDbContext = context.Adds.Include(a => a.Article)
                .SingleOrDefault(a => a.UserId == editAddViewModel.Add.UserId && a.ArticleId == editAddViewModel.Add.ArticleId);

            //update article
            addInDbContext.Article.Name = editAddViewModel.Add.Article.Name;
            addInDbContext.Article.Brand = editAddViewModel.Add.Article.Brand;
            addInDbContext.Article.Price = editAddViewModel.Add.Article.Price;
            addInDbContext.Article.Description = editAddViewModel.Add.Article.Description;
            addInDbContext.Article.Category = editAddViewModel.Add.Article.Category;
            addInDbContext.Article.IsNew = editAddViewModel.Add.Article.IsNew;
            
            //update add
            addInDbContext.Amount = editAddViewModel.Add.Amount;
            addInDbContext.Description = editAddViewModel.Add.Description;
            addInDbContext.LastModified = DateTime.Today;

            context.SaveChanges();

            return RedirectToAction("Index", "Add");
        }

        public ActionResult Delete(int aid, int uid)
        {
            var add = context.Adds.Include(a => a.Article).Include(a => a.User)
                .Single(a => a.UserId == uid && a.ArticleId == aid);

            context.Articles.Remove(add.Article);
            context.Adds.Remove(add);
            context.SaveChanges();

            return RedirectToAction("Index", "Add");
        }
    }
}