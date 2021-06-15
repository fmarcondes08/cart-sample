using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Klir.TechChallenge.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        public IEnumerable<Product> GetProducts()
        {
            return AppDbContext.Products;
        }

        public Product GetProductById(int id)
        {
            return AppDbContext.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
