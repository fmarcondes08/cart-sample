using Klir.TechChallenge.Domain.Models;
using System.Collections.Generic;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
    }
}
