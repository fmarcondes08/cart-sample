using Klir.TechChallenge.Domain.Models;
using System.Collections.Generic;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface IProductPromotionRepository
    {
        IEnumerable<ProductPromotion> GetProductPromotions();
        ProductPromotion GetProductPromotion(int productId);
    }
}
