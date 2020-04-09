using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrendyShop.Models;

namespace TrendyShop.Data
{
    public class EFDbContext : IdentityDbContext<User>
    {
        public DbSet<Article> Articles { get; set; }

      //  public DbSet<User> Users { get; set; }

        public DbSet<ShoppingCar> ShoppingCars { get; set; }

        public DbSet<ShoppingList_Article> ShoppingList_Articles{ get; set; }

        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public DbSet<Add> Adds { get; set; }

        public DbSet<Auction> Auctions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Add>().HasKey(c => c.ArticleId);
            modelBuilder.Entity<ShoppingList_Article>().HasKey(sla => new { sla.ShoppingListId, sla.ArticleId });
            modelBuilder.Entity<ShoppingCar>().HasKey(sc => sc.ShoppingListId);
        }
    }
}
