using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace TrendyShop.Models
{
    public class Auction
    {
        public int Id { get; set; }  //old primary key
        
        public string Title { get; set; }
        
        public bool IsNew { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId"), Column(Order = 0)]
        public User User { get; set; }

        public int ArticleId { get; set; }

        [Key, ForeignKey("ArticleId"), Column(Order = 1)]
        public Article Article { get; set; }

        public double CurrentPrice { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime Start { get; set; }

        public bool IsFinished { get; set; }

        List<Bid> Bids { get; set; }
    }
}
