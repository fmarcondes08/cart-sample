using Klir.TechChallenge.Domain.Enums;

namespace Klir.TechChallenge.Domain.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public PromotionTypeEnum PromotionType { get; set; }
    }
}
