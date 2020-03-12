using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.ViewModels;

namespace TrendyShop.Models
{
    public class AvailableAmount: ValidationAttribute
    {
        //public override bool IsValid(object value)
        //{
        //    return base.IsValid(value);
        //}
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var buyViewModel = (BuyViewModel)validationContext.ObjectInstance;

            if (buyViewModel.AmountToBuy > buyViewModel.Add.Amount) 
                return new ValidationResult("No puede adquirir más objetos de los que el anuncio marca como disponibles");
            else
                return ValidationResult.Success;
            //return base.IsValid(value, validationContext);
        }
    }
}
