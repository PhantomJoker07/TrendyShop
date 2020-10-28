using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;
using TrendyShop.ViewModels;
using TrendyShop.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TrendyShop.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private EFDbContext context;
        private IWebHostEnvironment webHostEnvironment;

        public UserController(UserManager<User> userManager,
                               SignInManager<User> signInManager, EFDbContext context, IWebHostEnvironment hostEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            webHostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Alias = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Description = model.Details,
                    ProfilePicture = UploadFile(model.Image)
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
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

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Login Fallido");
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Login Fallido");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccountDetails(string userName)
        {
            var account = userManager.Users.FirstOrDefault(e => e.UserName.Equals(userName));
            return View(account);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string userName)
        {
            userName = User.Identity.Name;
            var account = await userManager.FindByNameAsync(userName);
            var model = new EditAccountViewModel
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                Details = account.Description,
                PhoneNumber = account.PhoneNumber,
                CurrentProfilePicture = account.ProfilePicture
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = await userManager.FindByNameAsync(User.Identity.Name);
                account.UserName = User.Identity.Name;
                account.Email = model.Email;
                account.FirstName = model.FirstName;
                account.LastName = model.LastName;
                account.PhoneNumber = model.PhoneNumber;
                account.Description = model.Details;
                account.ProfilePicture = UploadFile(model.Image);
                var result = await userManager.UpdateAsync(account);

                if (result.Succeeded)
                {
                    if (model.NewPassword != null
                    || model.OldPassword != null
                    || model.Confirmation != null)
                    {
                        var change_result = await userManager.ChangePasswordAsync(account, model.OldPassword, model.NewPassword);
                        if (change_result.Succeeded)
                        {
                            return RedirectToAction("AccountDetails", new { userName = account.UserName });
                        }
                        else
                        {
                            foreach (var error in change_result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                            return View(model);
                        }
                    }
                    else
                    {
                        return View(model);
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}