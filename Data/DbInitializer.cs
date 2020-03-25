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
namespace TrendyShop.Data
{
    public class DbInitializer
    {
        public static void Initialize(EFDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
