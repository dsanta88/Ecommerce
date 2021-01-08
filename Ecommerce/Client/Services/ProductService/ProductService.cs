using Ecommerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Client.Services.ProductService
{
    public class ProductService: IProductService
    {
        public List<Product> Products { get; set; }

        public void LoadProducts()
        {
            Products = new List<Product>
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
}
