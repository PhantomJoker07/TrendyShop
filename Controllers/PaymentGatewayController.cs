using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrendyShop.Data;
using TrendyShop.ViewModels;

namespace TrendyShop.Controllers
{
    public class PaymentGatewayController : Controller
    {
        private EFDbContext context;

        public PaymentGatewayController(EFDbContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        //En este caso, como la pasarela está integrada a la plataforma, ya tenemos datos del login del usuario
        public IActionResult GetPaymentMethod(string userId/*, string sellerId*/, int articleId, long orderDateTicks, float charge)
        {
            //var user = context.Users.Single(u => u.Id == userId);
            var cards = context.User_Cards.Where(c => c.UserId == userId).ToList();

            PaymentMethodViewModel pmvm = new PaymentMethodViewModel
            {
                UserId = userId,
                //SellerId = sellerId,
                ArticleId = articleId,
                DateTicks = orderDateTicks,
                Charge = charge,
                Cards = cards
            };
            return View(pmvm);
        }

        private bool ValidatePayment(string nameOnCard, string cardNumber)
        {
            var random = new Random();
            var validOperation = random.Next(1, 5);

            if (validOperation == 1)
                return false;

            return true;
        }

        [HttpPost]
        public IActionResult FinishPayment(PaymentMethodViewModel pmvm)
        {
            if (!ModelState.IsValid)
            {
                //var user = context.Users.Single(u => u.Id == pmvm.User.UserName);
                var cards = context.User_Cards.Where(c => c.UserId == pmvm.UserId).ToList();
                PaymentMethodViewModel newpmvm = new PaymentMethodViewModel
                {
                    UserId = pmvm.UserId,
                    SellerId = pmvm.SellerId,
                    ArticleId = pmvm.ArticleId,
                    DateTicks = pmvm.DateTicks,
                    Charge = pmvm.Charge,
                    Cards = cards,
                    CardNumber = pmvm.CardNumber,
                    NameOnCard = pmvm.NameOnCard,
                };
                return View(newpmvm);
            }

            var validOperation = ValidatePayment(pmvm.NameOnCard, pmvm.CardNumber);

            if(!validOperation)
            {
                var cards = context.User_Cards.Where(c => c.UserId == pmvm.UserId).ToList();
                PaymentMethodViewModel newpmvm = new PaymentMethodViewModel
                {
                    UserId = pmvm.UserId,
                    SellerId = pmvm.SellerId,
                    ArticleId = pmvm.ArticleId,
                    DateTicks = pmvm.DateTicks,
                    Charge = pmvm.Charge,
                    Cards = cards,
                    CardNumber = pmvm.CardNumber,
                    NameOnCard = pmvm.NameOnCard,
                    InvalidOperation = true
                };
                return View(newpmvm);
            }

            //Deberia registrarse esta transaccion
            return RedirectToAction("CloseOrder", "Buy", new { userId = pmvm.UserId/*, sellerId = pmvm.SellerId*/, articleId = pmvm.ArticleId, dateTicks = pmvm.DateTicks });
        }
    }
}