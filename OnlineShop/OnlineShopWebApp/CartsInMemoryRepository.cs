using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class CartsInMemoryRepository : ICartsRepository
    {
        private List<Cart> carts = new List<Cart>();

        public Cart TryGetBuUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(ProductViewModel product, string userid)
        {
            var existingCart = TryGetBuUserId(userid);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userid,
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            Product = product
                        }
                    }
                };
                carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        Product = product
                    });
                }
            }

        }

        public void DecreaseAmount(Guid productid, string userid)
        {
            var existingCart = TryGetBuUserId(userid);
            if (existingCart == null)
            {
                return;
            }
            else
            {
                var existingCartItem = existingCart?.Items?.FirstOrDefault(x => x.Product.Id == productid);
                if (existingCartItem == null)
                {
                    return;
                }

                existingCartItem.Amount -= 1;
                if(existingCartItem.Amount == 0)
                {
                    existingCart.Items.Remove(existingCartItem);
                }
            }
        }

        public void Clear(string userid)
        {
            var existingCart = TryGetBuUserId(userid);
            carts.Remove(existingCart);
        }
    }
}
