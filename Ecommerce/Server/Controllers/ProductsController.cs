using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Server.Services.ProductService;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
         {
            return Ok( await  _productService.GetAllProducts());
         }

        [HttpGet("Category/{categoryUrl}")]
        public async Task<ActionResult<List<Product>>> GetAllProductsByCategory(string categoryUrl)
        {
            return Ok(await _productService.GetProductByCategory(categoryUrl));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProduct (int id)
        {
            return Ok(await _productService.GetProduct(id));
        }

    }
}
