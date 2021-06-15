using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Klir.TechChallenge.Infrastructure.Repositories
{
    public class ProductPromotionRepository : IProductPromotionRepository
    {
        public ProductPromotionRepository()
        {

        }

        public IEnumerable<ProductPromotion> GetProductPromotions()
        {
            return AppDbContext.ProductPromotions;
        }

        public ProductPromotion GetProductPromotion(int productId)
        {
            return AppDbContext.ProductPromotions.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
