using Ecommerce.Server.Data;
using Ecommerce.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Server.Services.CategoryService
{
    public class CategoryService: ICategoryService
    {

        private readonly DataContext _db;

        public CategoryService(DataContext db)
        {
            _db = db;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByUrl(string categoryUrl)
        {
            return await _db.Categories.FirstOrDefaultAsync(c=>c.Url.ToLower().Equals(categoryUrl.ToLower()));
        }
    }
}
