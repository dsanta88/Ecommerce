using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Ecommerce.Client.Services.ProductService;
using Ecommerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IToastService _toastService;
        private readonly IProductService _productService;

        public event Action OnChange;

        public CartService(
            ILocalStorageService  localStorage,
            IToastService toastService,
            IProductService productService
            )
        {
            _localStorage = localStorage;
            _toastService = toastService;
            _productService = productService;
        }

        public async Task AddToCart(ProductVariant productVariant)
        {
            var cart = await _localStorage.GetItemAsync<List<ProductVariant>>("cart");

            if(cart==null)
            {
                cart = new List<ProductVariant>();
            }

            cart.Add(productVariant);
            await _localStorage.SetItemAsync("cart",cart);

            var product = await _productService.GetProduct(productVariant.ProductId);
            _toastService.ShowSuccess(product.Title,"Add to cart:");

            OnChange.Invoke();

        }

        public async Task<List<CartItem>> GetCartItems()
        {
            List<CartItem> result = new List<CartItem>();
            var cart = await _localStorage.GetItemAsync<List<ProductVariant>>("cart");

            if (cart == null)
            {
                return result;
            }

            foreach (var item in cart)
            {
                try
                {
                    Product product = await _productService.GetProduct(1);
                    CartItem cartItem = new CartItem
                    {
                        ProductId = product.Id,
                        ProductTitle = product.Title,
                        Image = product.Image,
                        EditionId = item.EditionId
                    };

                    var variant = product.Variants.Find(v => v.EditionId == item.EditionId);
                    if (variant != null)
                    {
                        cartItem.EditionName = variant.Edition?.Name;
                        cartItem.Price = variant.Price;
                    }
                    result.Add(cartItem);
                }
                catch(Exception ex)
                {

                }
       
            }

            return result;
        }

        public async Task DeleteItem(CartItem item)
        {
            var cart = await _localStorage.GetItemAsync<List<ProductVariant>>("cart");
            if(cart==null)
            {
                return;
            }

            var cartItem = cart.Find(x=>x.ProductId==item.ProductId && x.EditionId==item.EditionId);
            cart.Remove(cartItem);

            await _localStorage.SetItemAsync("cart",cart);
            OnChange.Invoke();

        }
    }
}
