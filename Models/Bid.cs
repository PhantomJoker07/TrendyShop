using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrendyShop.Models
{
    public class Bid
    {
        [Key]
        public int BidId { get; set; }

        [ForeignKey("UserId"), Column(Order = 0)]
        public string UserId { get; set; }

        public User user { get; set; }

        [ForeignKey("ArticleId"), Column(Order = 1)]
        public int AuctionId { get; set; }

        public TimeSpan time { get; set; }

        public double amount { get; set; }
    }
}
