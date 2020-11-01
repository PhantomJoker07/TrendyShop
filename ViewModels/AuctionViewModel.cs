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

        public int ArticleId { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public User User { get; set; }

        public string AuctionDescription { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime Start { get; set; }

        public bool IsFinished { get; set; }

        public bool HasStarted { get; set; }

        public int Biders { get; set; }

        public double Price { get; set; }

        public double BidAmount { get; set; }

        public Bid LastBid { get; set; }

        public double Min_Bid { get; set; }
    }
}
