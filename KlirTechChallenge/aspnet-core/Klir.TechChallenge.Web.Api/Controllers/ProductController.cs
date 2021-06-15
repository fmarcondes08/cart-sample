using Klir.TechChallenge.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productRepository.GetProducts();

            return Ok(products);
        }
    }
}
