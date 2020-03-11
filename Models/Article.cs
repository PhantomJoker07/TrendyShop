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

        [Display(Name = "Artículo a ofertar")]
        public string Name { get; set; }

        [Display(Name = "Categoría")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        [Display(Name = "Marca")]
        public string Brand { get; set; }

        [Display(Name = "Precio")]
        public double Price { get; set; }

        //photos not implemeted yet!!!

        [Display(Name = "Descripción del artículo")]
        public string Description { get; set; }

        [Display(Name = "Nuevo")]
        public bool IsNew { get; set; }
    }
}
