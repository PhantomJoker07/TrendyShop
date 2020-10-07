using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace TrendyShop.Models
{
    public class Add
    {
       public string UserId { get; set; }

        [ForeignKey("UserId"),Column(Order = 0)]  //previously UserId
        public User User { get; set; }

        public int ArticleId { get; set; }

        [Key,ForeignKey("ArticleId"), Column(Order = 1)]
        public Article Article { get; set; }

        [Display(Name = "Cantidad Disponible")]
        public int Amount { get; set; }//required?

        [Display(Name = "Comentario sobre el anuncio")]
        public string Description { get; set; } //Is this necessary??

        public DateTime LastModified { get; set; }

    }
}
