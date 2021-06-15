using Klir.TechChallenge.Domain.Models;
using KlirTechChallenge.Web.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [ApiController]
    [Route("cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("itemprice")]
        public IActionResult ItemPrice(CartItem item)
        {
            var recalculatedItem = _cartService.RecalculateItemPrice(item);

            return Ok(recalculatedItem);
        }
    }
}
