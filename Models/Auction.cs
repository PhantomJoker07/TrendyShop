using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrendyShop.Models
{
    public class Auction
    {
        public int Id { get; set; }  //primary key
        
        public string Title { get; set; }
        
        public string Category { get; set; }
        
        public float StartPrice { get; set; }
        
        public string Description { get; set; }
        
        public bool IsNew { get; set; }
        
        public string Seller { get; set; }  //references to User.ci
        
        List<Bid> Bids { get; set; }
    }
}
