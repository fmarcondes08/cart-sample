using Klir.TechChallenge.Domain.Models;
using KlirTechChallenge.Web.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Promotions
{
    public class GetThreeProducts : IPromotionService
    {
        public CartItem Apply(CartItem item)
        {
            if (item.Amount < 3m)
                return item;

            var timesToApplyPromotion = Math.Truncate(item.Amount / 3);
            var timesToChargeFullPrice = item.Amount % 3;

            item.FinalPrice = (timesToApplyPromotion * 10m) + (timesToChargeFullPrice * item.OriginalPrice);

            item.SetPromotion();
            return item;
        }
    }
}
