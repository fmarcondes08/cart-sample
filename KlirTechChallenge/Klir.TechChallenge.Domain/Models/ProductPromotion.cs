using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Domain.Models
{
    public class ProductPromotion
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PromotionId { get; set; }
    }
}
