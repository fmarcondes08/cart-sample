using Klir.TechChallenge.Domain.Models;

namespace KlirTechChallenge.Web.Api.Interfaces
{
    public interface ICartService
    {
        CartItem RecalculateItemPrice(CartItem item);
    }
}
