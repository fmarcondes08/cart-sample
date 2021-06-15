using Klir.TechChallenge.Domain.Enums;
using Klir.TechChallenge.Web.Api.Promotions;
using KlirTechChallenge.Web.Api.Interfaces;
using System;
using System.Collections.Generic;

namespace Klir.TechChallenge.Web.Api.Helper
{
    public static class Helpers
    {
        private static Dictionary<PromotionTypeEnum, IPromotionService> Applicators
        {
            get
            {
                var dict = new Dictionary<PromotionTypeEnum, IPromotionService>();
                dict.Add(PromotionTypeEnum.Buy1Get1Free, new GetFreeProduct());
                dict.Add(PromotionTypeEnum.ThreeFor10Euro, new GetThreeProducts());
                return dict;
            }
        }

        public static IPromotionService GetPromotionApplicator(PromotionTypeEnum promotionType)
        {
            IPromotionService applicator;

            Applicators.TryGetValue(promotionType, out applicator);

            if (applicator == null)
                throw new Exception("Promotion configuration not found");

            return applicator;
        }
    }
}
