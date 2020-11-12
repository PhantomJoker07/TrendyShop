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

        public IActionResult GetPaymentMethod(string userId, int articleId, long orderDateTicks, double charge, int orderType = 3)
        {
            var cards = context.User_Cards.Where(c => c.UserId == userId).ToList();

            PaymentMethodViewModel pmvm = new PaymentMethodViewModel
            {
                UserId = userId,
                ArticleId = articleId,
                DateTicks = orderDateTicks,
                Charge = charge,
                Cards = cards,
                OrderType = orderType
            };
            return View(pmvm);
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
                    OrderType = pmvm.OrderType
                };
                return RedirectToAction("GetPaymentMethod", newpmvm);
            }

            var nameOnCard = pmvm.NameOnCard;
            var cardNumber = pmvm.CardNumber;
            if (pmvm.NameOnCard == null || pmvm.CardNumber == null)
            {
                nameOnCard = context.User_Cards.Single(uc => uc.UserId == pmvm.UserId 
                && uc.CardNumber == pmvm.SelectedCardNumber).NameOnCard;
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
                var cardInDb = context.User_Cards
                    .SingleOrDefault(uc => uc.UserId == user_card.UserId && uc.CardNumber == user_card.CardNumber);
                if (cardInDb == null)
                {
                    context.User_Cards.Add(user_card);
                    context.SaveChanges();
                }
            }
          
            //aqui es donde se deberia hacer las transacciones entre las cuentas del comprador y el o los vendedores
            return RedirectToAction("CloseOrder", "Buy", 
                new { userId = pmvm.UserId, articleId = pmvm.ArticleId, dateTicks = pmvm.DateTicks,
                    orderType = pmvm.OrderType});
        }
    }
}