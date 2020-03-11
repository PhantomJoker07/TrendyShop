using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrendyShop.Data;

namespace TrendyShop.Controllers
{
    public class UserController : Controller
    {
        private EFDbContext context;

        public UserController(EFDbContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var user = context.Users.Find(id);

            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}