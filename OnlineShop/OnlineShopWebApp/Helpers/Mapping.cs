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
                ImagePath = product.ImagePath,

            };
        }
        public static List<ProductViewModel> productViewModels(List<Product> products)
        {
            if (products == null || products.Count == 0)
                return new List<ProductViewModel>();
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
        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(UserDeliveryInfo userDeliveryInfo)
        {
            if (userDeliveryInfo == null)
            {
                return null;
            }
            var userDeliveryInfoViewModel = new UserDeliveryInfoViewModel
            {
                Address = userDeliveryInfo.Address,
                Email = userDeliveryInfo.Email,
                Name = userDeliveryInfo.Name,
                Phone = userDeliveryInfo.Phone,
            };
            return userDeliveryInfoViewModel;
        }
        public static OrderViewModel ToOrderViewModel(Order order)
        {
            if (order == null)
            {
                return null;
            }
            var orderViewModel = new OrderViewModel
            {
                Id = order.Id,
                CreateDateTime = order.CreateDateTime,
                Statuses = (OrderStatusesViewModel)(int)order.Status,
                Items = ToCartItemViewModels(order.Items),
                User = ToUserDeliveryInfoViewModel(order.User)
            };
            return orderViewModel;
        }
        public static List<OrderViewModel> ToOrderViewModels(List<Order> orders)
        {
            var orderViewModels = new List<OrderViewModel>();
            foreach (var orderDb in orders)
            {
                var orderViewModel = new OrderViewModel
                {
                    Id = orderDb.Id,
                    CreateDateTime = orderDb.CreateDateTime,
                    Items = ToCartItemViewModels(orderDb.Items),
                    Statuses = (OrderStatusesViewModel)(int)orderDb.Status,
                    User = ToUserDeliveryInfoViewModel(orderDb.User)
                };
                orderViewModels.Add(orderViewModel);
            }
            return orderViewModels;
        }
        public static UserDeliveryInfo ToUserDeliveryInfo(UserDeliveryInfoViewModel userDeliveryInfoView)
        {
            var userDeliveryInfo = new UserDeliveryInfo
            {
                Address = userDeliveryInfoView.Address,
                Email = userDeliveryInfoView.Email,
                Name = userDeliveryInfoView.Name,
                Phone = userDeliveryInfoView.Phone,
            };
            return userDeliveryInfo;
        }
    }
}

