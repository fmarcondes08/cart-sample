using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Domain.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public PromotionTypeEnum PromotionType { get; set; }
    }
}
