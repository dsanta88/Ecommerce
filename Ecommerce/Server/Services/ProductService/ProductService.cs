using Ecommerce.Server.Services.CategoryService;
using Ecommerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {

        private readonly ICategoryService _categoryService;

        public ProductService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return Products;
        }

        public async Task<Product> GetProduct(int id)
        {
            Product product = Products.FirstOrDefault(p=>p.Id==id);
            return product;
        }

        public async Task<List<Product>> GetProductByCategory(string categoryUrl)
        {
            Category category = await _categoryService.GetCategoryByUrl(categoryUrl);
            return Products.Where(p=>p.CategoryId==category.Id).ToList();
        }

  
        public List<Product> Products { get; set; } = new List<Product>
        {
              new Product
        {
            Id=1,
            CategoryId=1,
            Title="Galax 34",
            Description="Celular Sansung",
            Image="https://i.pinimg.com/236x/76/d9/80/76d98054151d08ac8c1e625deff00874.jpg",
            Price=9.99m,
            OriginalPrice=19.99m,
        },
              new Product
        {
            Id=1,
            CategoryId=1,
            Title="Iphone 12",
            Description="Iphone 12",
            Image="https://i.pinimg.com/236x/76/d9/80/76d98054151d08ac8c1e625deff00874.jpg",
            Price=8.19m,
            OriginalPrice=29.99m,
        }
        };
    }
}
