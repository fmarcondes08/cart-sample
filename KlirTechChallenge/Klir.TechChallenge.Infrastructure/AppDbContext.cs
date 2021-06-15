using Klir.TechChallenge.Domain.Enums;
using Klir.TechChallenge.Domain.Models;
using System.Collections.Generic;

namespace Klir.TechChallenge.Infrastructure
{
    public static class AppDbContext
    {
        public static IEnumerable<Product> Products
        {
            get
            {
                var items = new List<Product>();

                items.Add(new Product() { Id = 1, Name = "Product A", Price = 20 });
                items.Add(new Product() { Id = 2, Name = "Product B", Price = 4 });
                items.Add(new Product() { Id = 3, Name = "Product C", Price = 2 });
                items.Add(new Product() { Id = 4, Name = "Product D", Price = 4 });

                return items;
            }
        }

        public static IEnumerable<Promotion> Promotions
        {
            get
            {
                var items = new List<Promotion>();

                items.Add(new Promotion() { Id = 1, PromotionType = PromotionTypeEnum.Buy1Get1Free });
                items.Add(new Promotion() { Id = 2, PromotionType = PromotionTypeEnum.ThreeFor10Euro });

                return items;
            }
        }

        public static IEnumerable<ProductPromotion> ProductPromotions
        {
            get
            {
                var items = new List<ProductPromotion>();

                items.Add(new ProductPromotion() { Id = 1, ProductId = 1, PromotionId = 1 });
                items.Add(new ProductPromotion() { Id = 2, ProductId = 2, PromotionId = 2 });
                items.Add(new ProductPromotion() { Id = 3, ProductId = 4, PromotionId = 2 });

                return items;
            }
        }
    }
}
