using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrendyShop.Data;
using TrendyShop.ViewModels;
using TrendyShop.Models;
using TrendyShop.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace TrendyShop.Controllers
{
    [Authorize]
    public class AddController : Controller
    {
        private EFDbContext context;
        private IWebHostEnvironment webHostEnvironment;

        public AddController(EFDbContext ctx, IWebHostEnvironment hostEnvironment)
        {
            webHostEnvironment = hostEnvironment;
            context = ctx;
        }
        
        [AllowAnonymous]
        public IActionResult Index()
        {
            var vm = new AddsViewModel
            {
                Categories = context.Categories.ToList(),
                Adds = context.Adds.Include(a => a.User).Include(a => a.Article).Where(a => a.Amount > 0).ToList()
            };

            return View(vm);
        }

        public IActionResult MyAdds()
        {
            string currentUserName = User.Identity.Name;
            var userId = context.Users.Single(u => u.UserName == currentUserName).Id;
            var avm = new AddsViewModel
            {
                Categories = context.Categories.ToList(),
                Adds = context.Adds.Include(a => a.User).Include(a => a.Article).Where(a => a.UserId == userId && a.Amount > 0).ToList(),
                UserIsAdmin = User.IsInRole("Admin")
            };

            return View(avm);
        }

        public IActionResult ConditionFilter(bool isNew, bool myAdds = false)
        {
            var vm = new AddsViewModel
            {
                Categories = context.Categories.ToList()
            };

            IQueryable<Add> adds;
            if (isNew)
            {
                adds = context.Adds.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.IsNew);
            }
            else
            {
                adds = context.Adds.Include(a => a.Article).Include(a => a.User).Where(a => !a.Article.IsNew);
            }

            if (myAdds)
            {
                var userName = User.Identity.Name;
                if (userName != null)
                {
                    var userId = context.Users.Single(u => u.UserName == userName).Id;
                    vm.Adds = adds.Where(a => a.UserId == userId).ToList();
                    return View("MyAdds", vm);
                }//else mandar error aqui y en todos los filtros
            }

            vm.Adds = adds.ToList();

            return View("Index", vm);
        }

        public IActionResult CategoryFilter(int categoryId, bool myAdds = false)
        {
            var vm = new AddsViewModel
            {
                Categories = context.Categories.ToList()
            };

            if (myAdds)
            {
                var userName = User.Identity.Name;
                var userId = context.Users.Single(u => u.UserName == userName).Id;
                vm.Adds = context.Adds.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.CategoryId == categoryId && a.UserId == userId).ToList();
                return View("MyAdds", vm);
            }

            vm.Adds = context.Adds.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.CategoryId == categoryId).ToList();
            return View("Index", vm);
        }

        public IActionResult PriceFilter(float minp, float maxp, bool myAdds = false)
        {
            var vm = new AddsViewModel
            {
                Categories = context.Categories.ToList()
            };

            if (myAdds)
            {
                var userName = User.Identity.Name;
                var userId = context.Users.Single(u => u.UserName == userName).Id;
                vm.Adds = context.Adds.Include(a => a.Article).Include(a => a.User).Where(a => (a.Article.Price >= minp && a.Article.Price <= maxp) && a.UserId == userId).ToList();
                return View("MyAdds", vm);
            }

            vm.Adds = context.Adds.Include(a => a.Article).Include(a => a.User).Where(a => (a.Article.Price >= minp && a.Article.Price <= maxp)).ToList();
            return View("Index", vm);
        }

        public IActionResult Search(string search, bool myAdds = false)
        {
            var vm = new AddsViewModel
            {
                Categories = context.Categories.ToList()
            };

            if (myAdds)
            {
                var userName = User.Identity.Name;
                var userId = context.Users.Single(u => u.UserName == userName).Id;
                vm.Adds = context.Adds.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.Name.Contains(search) && a.UserId == userId).ToList();
                return View("MyAdds", vm);
            }

            vm.Adds = context.Adds.Include(a => a.Article).Include(a => a.User).Where(a => a.Article.Name.Contains(search)).ToList();
            return View("Index", vm);
        }

        public IActionResult AllFilter(bool myAdds = false)
        {
            var vm = new AddsViewModel
            {
                Categories = context.Categories.ToList()
            };

            if (myAdds)
            {
                var userName = User.Identity.Name;
                var userId = context.Users.Single(u => u.UserName == userName).Id;
                vm.Adds = context.Adds.Include(a => a.User).Include(a => a.Article).Where(a => a.UserId == userId).ToList();
                return View("MyAdds", vm);
            }

            vm.Adds = context.Adds.Include(a => a.User).Include(a => a.Article).ToList();
            return View("Index", vm);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            bool alreadyInCart = false;
           

               
                var add = context.Adds.Find(id);
                context.Entry(add).Reference(a => a.User).Load();
                context.Entry(add).Reference(a => a.Article).Load();

            if (User.Identity == null)
            {
                var mySl = (from sc in context.ShoppingCars
                            join l in context.ShoppingLists
                            on sc.ShoppingListId equals l.ShoppingListId
                            where sc.UserId == GetUser(User.Identity.Name).Id && l.IsMainList == true
                            select new { l.ShoppingListId }).ToList();

                var sl2 = new ShoppingList();

                if (mySl.Count() > 0)
                {
                    foreach (var item in mySl)
                    {
                        sl2 = context.ShoppingLists.Find(item.ShoppingListId);
                    }
                }

                if ((context.ShoppingList_Articles.SingleOrDefault(a => a.ShoppingListId == sl2.ShoppingListId && a.ArticleId == add.ArticleId)) != null)
                {
                    alreadyInCart = true;
                }
            }

            var result = new AddViewModel
            {
                Article = add.Article,
                UserName = add.User.Alias,
                Amount = add.Amount,
                AddDescription = add.Description,
                User = add.User,
                AlreadyInCart = alreadyInCart
            };

            return View(result);
        }

        public ViewResult NewAdd()
        {
            var categories = context.Categories.ToList();
            var model = new NewAddViewModel
            {
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
                newViewModel.Add.User = GetUser(User.Identity.Name); //returns null if user not found
                newViewModel.Add.UserId = User.Identity.Name;
                return View("NewAdd", newViewModel);
            }
            viewModel.Add.User = GetUser(User.Identity.Name); //returns null if user not found
            viewModel.Add.UserId = User.Identity.Name;

            viewModel.Add.Article.Image = UploadedFile(viewModel.Image);
            context.Adds.Add(viewModel.Add);//this already updates User and Article
            context.SaveChanges();

            return RedirectToAction("MyAdds", "Add");
        }

        private string UploadedFile(IFormFile image)
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

        //[HttpPost]    
        public ActionResult Edit(int aid, string uid)
        {
            var add = context.Adds.Include(a => a.Article).SingleOrDefault(a => a.ArticleId == aid && a.UserId == uid);

            //I dont understand the purpose of this line and it was throwing an error so i commented it to be able to work on the view
            //context.Entry(add).Reference(a => a.Article).Load();

            if (add == null)
            {
                return RedirectToAction("Index");
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

            return RedirectToAction("MyAdds", "Add");
        }

        public ActionResult Delete(int aid, string uid)
        {
            var add = context.Adds.Include(a => a.Article).Include(a => a.User)
                .Single(a => a.UserId == uid && a.ArticleId == aid);

            context.Articles.Remove(add.Article);
            context.Adds.Remove(add);
            context.SaveChanges();

            return RedirectToAction("MyAdds", "Add");
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