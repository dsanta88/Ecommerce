using Ecommerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Server.Services.ProductService
{
   public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductByCategory(string categoryUrl);
        Task<Product> GetProduct(int id);

    }
}
