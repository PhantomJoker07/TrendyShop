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
using Microsoft.AspNetCore.Identity;

namespace TrendyShop.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(EFDbContext context, RoleManager<IdentityRole> _roleManager, UserManager<User> userManager)
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await _roleManager.RoleExistsAsync("Customer"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            if(context.Users.Find("defaultAdmin") == null)
            {
                var user = new User { UserName = "defaultAdmin" };
                var result = await userManager.CreateAsync(user, "def@ultP@ssw0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
           
        }
       
    }
}
