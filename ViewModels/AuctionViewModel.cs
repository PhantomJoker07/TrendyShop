using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;

namespace TrendyShop.ViewModels
{
    public class AuctionViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string UserPhoneNumber { get; set; }

        public string UserId { get; set; }

        public string AuctionDescription { get; set; }

        public TimeSpan Duration { get; set; }

        public double Price { get; set; }

        public bool IsNew { get; set; }

        //  public Category Category { get; set; }

        public int CategoryId { get; set; }

    }
}
