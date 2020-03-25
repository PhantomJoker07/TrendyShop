using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;

namespace TrendyShop.ViewModels
{
    public class AuctionIndexViewModel
    {
        public IEnumerable<Auction> Auctions { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
