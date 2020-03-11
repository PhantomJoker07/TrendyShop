using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrendyShop.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }	//primary key

        public string Name { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public string Brand { get; set; }

        public double Price { get; set; }
     
        //photos not implemeted yet!!!
        
        public string Description { get; set; }

        public bool IsNew { get; set; }
    }
}
