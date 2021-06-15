using Klir.TechChallenge.Domain.Enums;
using Klir.TechChallenge.Domain.Models;
using KlirTechChallenge.Web.Api.Interfaces;
using System;

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

            item.PromotionId = (int)PromotionTypeEnum.ThreeFor10Euro;
            item.SetPromotion();
            return item;
        }
    }
}
