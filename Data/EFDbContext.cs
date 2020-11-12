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

        public DbSet<ShoppingCar> ShoppingCars { get; set; }

        public DbSet<ShoppingList_Article> ShoppingList_Articles{ get; set; }

        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public DbSet<Add> Adds { get; set; }

        public DbSet<Auction> Auctions { get; set; }

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<AuctionOrder> AuctionOrders { get; set; }

        public DbSet<User_Card> User_Cards { get; set; }


        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options) { }

        public DbSet<Bid> Bids { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Add>().HasKey(a => a.ArticleId);
            modelBuilder.Entity<ShoppingList_Article>().HasKey(sla => new { sla.ShoppingListId, sla.ArticleId });
            modelBuilder.Entity<ShoppingCar>().HasKey(sc => sc.ShoppingListId);
            modelBuilder.Entity<Auction>().HasKey(a => a.ArticleId);
            modelBuilder.Entity<User_Card>().HasKey(uc => new { uc.UserId, uc.CardNumber});
            modelBuilder.Entity<Order>().HasKey(o => new { o.Date, o.CustomerId/*, o.SellerId*/, o.ArticleId });
            modelBuilder.Entity<AuctionOrder>().HasKey(o => new { o.Date, o.CustomerId/*, o.SellerId*/, o.ArticleId });
            modelBuilder.Entity<Bid>().HasKey(a => a.BidId);
        }
    }
}
    