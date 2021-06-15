using Klir.TechChallenge.Domain.Enums;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Models;
using Klir.TechChallenge.Web.Api.Helper;
using KlirTechChallenge.Web.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Services
{
    public class CartService : ICartService
    {
        private readonly IProductPromotionRepository _productPromotionRepository;
        private readonly IProductRepository _productRepository;
        private readonly Helpers _helpers;

        public CartService(IProductPromotionRepository productPromotionRepository,
            IProductRepository productRepository, Helpers helpers)
        {
            _productPromotionRepository = productPromotionRepository;
            _productRepository = productRepository;
            _helpers = helpers;
        }

        public CartItem RecalculateItemPrice(CartItem item)
        {
            CalculateProductGrossPrice(item);
            var productPromotion = GetProductPromotion(item.ProductId);
            item.SetNoPromotion();

            if (productPromotion == null)
                return item;

            ApplyPromotion(item, productPromotion.PromotionId);

            return item;
        }

        private CartItem CalculateProductGrossPrice(CartItem item)
        {
            var product = _productRepository.GetProductById(item.ProductId);
            item.OriginalPrice = product.Price;
            item.FinalPrice = item.OriginalPrice * item.Amount;
            return item;
        }

        private ProductPromotion GetProductPromotion(int productId)
        {
            return _productPromotionRepository.GetProductPromotion(productId);
        }

        private CartItem ApplyPromotion(CartItem item, int promotionId)
        {
            var applicator = _helpers.GetPromotionApplicator((PromotionTypeEnum)promotionId);
            applicator.Apply(item);
            return item;
        }
    }
}
