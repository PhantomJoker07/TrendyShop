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
            //context.Database.Migrate();
            context.Database.EnsureCreated();
            Fill_Categories(context);
        }

        public static void Fill_Categories (EFDbContext context)
        {
            Category[] categories =
            {
                new Category { Name = "Unknown"},
                new Category { Name = "Laptop" },
                new Category { Name = "Celular" },
                new Category { Name = "PC de escritorio" },
                new Category { Name = "Componente" },
            };


            if (!context.Categories.Any())
            {
                foreach (var cat in categories) context.Categories.Add(cat);
                context.SaveChanges();
            }
        }
    }
}
