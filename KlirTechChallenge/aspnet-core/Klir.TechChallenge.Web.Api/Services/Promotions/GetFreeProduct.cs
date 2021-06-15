using Klir.TechChallenge.Domain.Models;
using KlirTechChallenge.Web.Api.Interfaces;
using System;

namespace Klir.TechChallenge.Web.Api.Promotions
{
    public class GetFreeProduct : IPromotionService
    {
        public CartItem Apply(CartItem item)
        {
            if (item.Amount == 1m)
                return item;

            var timesToChargeByPromotion = Math.Truncate(item.Amount / 2);
            var timesToChargeFullPrice = item.Amount % 2;

            if (timesToChargeByPromotion > 0)
            {
                item.SetPromotion();
                item.FinalPrice = item.OriginalPrice * timesToChargeByPromotion;
            }

            if (timesToChargeFullPrice > 0)
                item.FinalPrice += item.OriginalPrice * timesToChargeFullPrice;

            return item;
        }
    }
}
