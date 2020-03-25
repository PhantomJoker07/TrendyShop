using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrendyShop.Models
{
    public class Auction
    {
        public int Id { get; set; }  //primary key
        
        public string Title { get; set; }
        
        public bool IsNew { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId"), Column(Order = 0)]
        public User User { get; set; }

        public int ArticleId { get; set; }

        [Key, ForeignKey("ArticleId"), Column(Order = 1)]
        public Article Article { get; set; }

        public TimeSpan Duration { get; set; }

        List<Bid> Bids { get; set; }
    }
}
