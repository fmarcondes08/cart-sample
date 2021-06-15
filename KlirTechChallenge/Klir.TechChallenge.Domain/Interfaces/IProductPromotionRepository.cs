using Klir.TechChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface IProductPromotionRepository
    {
        IEnumerable<ProductPromotion> GetProductPromotions();
        ProductPromotion GetProductPromotion(int productId);
    }
}
