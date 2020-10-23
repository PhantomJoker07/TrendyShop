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
        public int Id { get; set; } 

        public string UserId { get; set; }

        [ForeignKey("UserId"), Column(Order = 0)]

        public User User { get; set; }

        public TimeSpan Time { get; set; }

        public double Amount { get; set; }
    }
}
