using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;

namespace TrendyShop.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }

        public IFormFile Image { get; set; }
    }
}
