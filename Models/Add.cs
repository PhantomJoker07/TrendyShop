using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace TrendyShop.Models
{
    public class Add
    {
        [Key]
        public int ArticleId { get; set; }

        [ForeignKey("ArticleId")]
        public Article Article { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }        

        [Display(Name = "Cantidad Disponible")]
        public int Amount { get; set; }

        [Display(Name = "Comentario sobre el anuncio")]
        public string Description { get; set; }

        public DateTime LastModified { get; set; }

    }
}
