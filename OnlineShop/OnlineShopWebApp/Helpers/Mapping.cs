using OnlineShop.Db;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Color = product.Color,
                Cost = product.Cost,
                Description = product.Description,
                Manufactured = product.Manufactured,

            };
        }
        public static List<ProductViewModel> productViewModels(List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }
        public static CartViewModel ToCartItemViewModel(Cart cart)
        {
            if (cart == null)
            {
                return null;
            }
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemViewModels(cart.Items)
            };
        }
        public static List<CartItemViewModel> ToCartItemViewModels(List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach (var cartDbItem in cartDbItems)
            {
                var cartItemViewModel = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
                cartItems.Add(cartItemViewModel);
            }
            return cartItems;
        }
    }
}
