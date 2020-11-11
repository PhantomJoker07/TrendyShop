using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrendyShop.Models
{
    public class AuctionOrder
    {
        [Key, Column(Order = 0)]
        public DateTime Date { get; set; }

        [Key, Column(Order = 1)]
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public User Customer { get; set; }

        [Key, Column(Order = 2)]
        public int ArticleId { get; set; }

        [ForeignKey("ArticleId")]
        public Auction Auction { get; set; }

        public string Address { get; set; }
        public float ShippingCharge { get; set; }
        public bool Paid { get; set; }
    }
}
