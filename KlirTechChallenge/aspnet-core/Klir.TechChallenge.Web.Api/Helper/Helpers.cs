using Klir.TechChallenge.Domain.Enums;
using Klir.TechChallenge.Web.Api.Promotions;
using KlirTechChallenge.Web.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Helper
{
    public class Helpers
    {
        private Dictionary<PromotionTypeEnum, IPromotionService> Applicators
        {
            get
            {
                var dict = new Dictionary<PromotionTypeEnum, IPromotionService>();
                dict.Add(PromotionTypeEnum.Buy1Get1Free, new GetFreeProduct());
                dict.Add(PromotionTypeEnum.ThreeFor10Euro, new GetThreeProducts());
                return dict;
            }
        }

        public IPromotionService GetPromotionApplicator(PromotionTypeEnum promotionType)
        {
            IPromotionService applicator;

            Applicators.TryGetValue(promotionType, out applicator);

            if (applicator == null)
                throw new Exception("Promotion configuration not found");

            return applicator;
        }
    }
}
