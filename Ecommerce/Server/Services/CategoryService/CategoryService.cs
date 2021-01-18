using Ecommerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Server.Services.CategoryService
{
    public class CategoryService: ICategoryService
    {

        public List<Category> Categories { get; set; } = new List<Category>
            {
             new Category{ Id=1, Name="Libros", Url="books", Icon="book"},
             new Category{ Id=2, Name="Electronica", Url="electronics", Icon="camera-slr"},
             new Category{ Id=3, Name="Video Juegos", Url="video-games", Icon="aperture"}
            };

        public async Task<List<Category>> GetCategories()
        {
            return Categories;
        }
    }
}
