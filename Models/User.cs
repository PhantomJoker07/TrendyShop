using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrendyShop.Models
{
    public class User
    {   
        [Key]
        public int UserId { get; set; }
        
        public string Name { get; set; }
        
        //public string LastName { get; set; }

        public string Description { get; set; }
        
        public string Card { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public float Rating { get; set; }

        public int TotalSales { get; set; }

    }
}
