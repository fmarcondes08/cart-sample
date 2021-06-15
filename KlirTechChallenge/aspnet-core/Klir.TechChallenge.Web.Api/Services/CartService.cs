using Klir.TechChallenge.Domain.Enums;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Models;
using Klir.TechChallenge.Web.Api.Helper;
using KlirTechChallenge.Web.Api.Interfaces;

namespace Klir.TechChallenge.Web.Api.Services
{
    public class CartService : ICartService
    {
        private readonly IProductPromotionRepository _productPromotionRepository;
        private readonly IProductRepository _productRepository;

        public CartService(IProductPromotionRepository productPromotionRepository,
            IProductRepository productRepository)
        {
            _productPromotionRepository = productPromotionRepository;
            _productRepository = productRepository;
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
            var applicator = Helpers.GetPromotionApplicator((PromotionTypeEnum)promotionId);
            applicator.Apply(item);
            return item;
        }
    }
}
