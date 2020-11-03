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
        [Display(Name ="Título")]
        public string Title { get; set; }
        
        public bool IsNew { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId"), Column(Order = 0)]
        public User User { get; set; }

        public int ArticleId { get; set; }

        [Key, ForeignKey("ArticleId"), Column(Order = 1)]
        public Article Article { get; set; }

        public double CurrentPrice { get; set; }

        [Display(Name = "Duración")]
        public TimeSpan Duration { get; set; }

        [Display(Name = "Fecha de inicio")]
        public DateTime Start { get; set; }

        public bool IsFinished { get; set; }

        public bool HasStarted { get; set; }

        [ForeignKey("BidId"), Column(Order = 2)]
        public int BidId { get; set; }

        public Bid LastBid { get; set; }

        public int Biders{ get; set; }

        public double Min_Bid { get; set; }
    }
}
