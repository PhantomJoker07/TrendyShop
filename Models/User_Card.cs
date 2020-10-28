using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrendyShop.Models
{
    public class User_Card
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Key, Column(Order = 1)]
        public string CardNumber { get; set; }

        public string NameOnCard { get; set; }
    }
}
