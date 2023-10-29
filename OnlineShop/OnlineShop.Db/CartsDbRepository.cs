using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DatabaseContext _dbContext;

        public CartsDbRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Cart TryGetByUserId(string userId)
        {
            return _dbContext.Carts.Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userid)
        {
            var existingCart = TryGetByUserId(userid);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userid,
                };

                newCart.Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Amount = 1,
                            Product = product,
                            Cart = newCart
                        }
                    };
                _dbContext.Carts.Add(newCart);
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
                        Amount = 1,
                        Product = product,
                        Cart = existingCart
                    });
                }
            }
            _dbContext.SaveChanges();
        }

        public void DecreaseAmount(Guid productid, string userid)
        {
            var existingCart = TryGetByUserId(userid);
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
                if (existingCartItem.Amount == 0)
                {
                    existingCart.Items.Remove(existingCartItem);
                }
            }
            _dbContext.SaveChanges();
        }

        public void Clear(string userid)
        {
            var existingCart = TryGetByUserId(userid);
            _dbContext.Carts.Remove(existingCart);
            _dbContext.SaveChanges();
        }
    }
}
