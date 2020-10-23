using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;
using System.Diagnostics;

namespace TrendyShop.ViewModels
{
    public class AuctionViewModel
    {
        public int Id { get; set; }

        public Article Article { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public User User { get; set; }

        public string AuctionDescription { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime Start { get; set; }

        public bool IsFinished { get; set; }

        public double Price { get; set; }

        public double BidAmount { get; set; }

        public List<Bid> Bids { get; set; }


        // public Auction Auction { get; set; }

        //public AuctionViewModel()
        //{

        //}

    }
}
