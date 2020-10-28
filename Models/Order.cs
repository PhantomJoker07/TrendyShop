using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrendyShop.Models
{
    public class Order
    {
        [Key,Column(Order = 0)]
        public DateTime Date { get; set; }

        //user who makes the order
        [Key, Column(Order = 1)]
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public User Customer { get; set; }

        //[Key, Column(Order = 2)]
        //public string SellerId { get; set; }

        //[ForeignKey("SellerId")]
        //public User Seller { get; set; }


        [Key, Column(Order = 3)]
        public int ArticleId { get; set; }

        //[ForeignKey("ArticleId")]
        //public Article Article { get; set; }

        [ForeignKey("ArticleId")]
        public Add Add { get; set; }

        public int Amount { get; set; }

        public string Address { get; set; }

        public float ShippingCharge { get; set; }

        //paid or pending
        public bool Paid { get; set; }
    }
}
