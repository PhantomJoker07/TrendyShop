using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace TrendyShop.Models
{
    public class Add
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]  //previously UserId
        public User User { get; set; }
        
        [Key, Column(Order = 1)]
        public int ArticleId { get; set; }

        [ForeignKey("ArticleId")]
        public Article Article { get; set; }

        [Display(Name = "Cantidad Disponible")]
        public int Amount { get; set; }//required?

        [Display(Name = "Comentario sobre el anuncio")]
        public string Description { get; set; } //Is this necessary??

        public DateTime LastModified { get; set; }

    }
}
