using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrendyShop.Data;
using TrendyShop.Models;
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
        public IActionResult GetPaymentMethod(string userId, int articleId, long orderDateTicks, float charge)
        {
            var cards = context.User_Cards.Where(c => c.UserId == userId).ToList();

            PaymentMethodViewModel pmvm = new PaymentMethodViewModel
            {
                UserId = userId,
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

            var nameOnCard = pmvm.NameOnCard;
            var cardNumber = pmvm.CardNumber;
            if (pmvm.NameOnCard == null || pmvm.CardNumber == null)
            {
                nameOnCard = context.User_Cards.Single(uc => uc.UserId == pmvm.UserId && uc.CardNumber == pmvm.SelectedCardNumber).NameOnCard;
                cardNumber = pmvm.SelectedCardNumber;
            }
            else
            {
                var user_card = new User_Card
                {
                    UserId = pmvm.UserId,
                    CardNumber = cardNumber,
                    NameOnCard = nameOnCard
                };
                context.User_Cards.Add(user_card);
                context.SaveChanges();
            }

            //descomentar cuando funcione lo del $
            //var validOperation = ValidatePayment(nameOnCard, cardNumber);

            //if(!validOperation)
            //{
            //    var cards = context.User_Cards.Where(c => c.UserId == pmvm.UserId).ToList();
            //    PaymentMethodViewModel newpmvm = new PaymentMethodViewModel
            //    {
            //        UserId = pmvm.UserId,
            //        SellerId = pmvm.SellerId,
            //        ArticleId = pmvm.ArticleId,
            //        DateTicks = pmvm.DateTicks,
            //        Charge = pmvm.Charge,
            //        Cards = cards,
            //        CardNumber = pmvm.CardNumber,
            //        NameOnCard = pmvm.NameOnCard,
            //        InvalidOperation = true
            //    };
            //    return View(newpmvm);
            //}
                       

            return RedirectToAction("CloseOrder", "Buy", new { userId = pmvm.UserId, articleId = pmvm.ArticleId, dateTicks = pmvm.DateTicks });
        }
    }
}